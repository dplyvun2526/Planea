using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoDeskstop
{
    // DTOs que reflejan los modelos de Planea_Api (JSON en camelCase).
    public class ApiUsuario { public int IdUser { get; set; } public string NameUser { get; set; } public string LastnameUser { get; set; } public string MailUser { get; set; } public int IdRoles { get; set; } public string NameRoles { get; set; } }
    public class ApiProyecto { public int IdProject { get; set; } public string NameProject { get; set; } public string DescriptionProject { get; set; } public DateTime DateStartProject { get; set; } public DateTime DateSubmit { get; set; } }
    public class ApiTarea { public int IdTask { get; set; } public string Title { get; set; } public string DescriptionTask { get; set; } public int Priority { get; set; } public DateTime StateDate { get; set; } public DateTime DueDate { get; set; } public int IdProject { get; set; } public int IdState { get; set; } }
    public class ApiEstado { public int IdState { get; set; } public string NameState { get; set; } }
    public class ApiRol { public int IdRoles { get; set; } public string NameRoles { get; set; } }
    public class ApiAsignacion { public int IdUser { get; set; } public int IdTask { get; set; } }
    public class ApiProyectoUsuarioRol { public int IdRoles { get; set; } public int IdUsers { get; set; } public int IdProject { get; set; } }
    public class ApiHoras { public DateTime Date { get; set; } public int IdUser { get; set; } public int IdTask { get; set; } public string Descriptions { get; set; } public decimal Hours { get; set; } }

    public class ApiException : Exception
    {
        public ApiException(string mensaje) : base(Idiomas.T(mensaje)) { }
    }

    // Cliente HTTP de Planea_Api. La URL base se puede cambiar con la variable de entorno PLANEA_API_URL.
    public static class Api
    {
        private static readonly HttpClient http = new HttpClient
        {
            BaseAddress = new Uri(Environment.GetEnvironmentVariable("PLANEA_API_URL") ?? "http://localhost:5097/"),
            Timeout = TimeSpan.FromSeconds(10)
        };

        private static readonly JsonSerializerOptions json = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private static string Enviar(HttpMethod metodo, string ruta, object cuerpo = null)
        {
            try
            {
                using (HttpRequestMessage req = new HttpRequestMessage(metodo, ruta))
                {
                    if (cuerpo != null)
                    {
                        req.Content = new StringContent(JsonSerializer.Serialize(cuerpo, json), Encoding.UTF8, "application/json");
                    }
                    using (HttpResponseMessage resp = http.SendAsync(req).GetAwaiter().GetResult())
                    {
                        string texto = resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        if (!resp.IsSuccessStatusCode)
                        {
                            throw new ApiException(string.IsNullOrWhiteSpace(texto) ? "Error " + (int)resp.StatusCode : texto.Trim('"'));
                        }
                        return texto;
                    }
                }
            }
            catch (HttpRequestException)
            {
                throw new ApiException(Idiomas.T("No se puede conectar con la API ({0}). ¿Está arrancada?", http.BaseAddress));
            }
            catch (TaskCanceledException)
            {
                throw new ApiException("La API no responde (tiempo de espera agotado).");
            }
        }

        public static List<T> Lista<T>(string ruta)
        {
            return JsonSerializer.Deserialize<List<T>>(Enviar(HttpMethod.Get, ruta), json) ?? new List<T>();
        }

        // POST que devuelve un objeto (p. ej. el usuario del login).
        public static T Enviar<T>(string ruta, object cuerpo)
        {
            return JsonSerializer.Deserialize<T>(Enviar(HttpMethod.Post, ruta, cuerpo), json);
        }

        public static int Crear(string ruta, object cuerpo)
        {
            // Al crear, la API devuelve { id_xxx, mensaje }: se lee el primer entero.
            // En las tablas de relación (asignaciones, roles de proyecto) devuelve solo un texto: se devuelve 0.
            string respuesta = Enviar(HttpMethod.Post, ruta, cuerpo);
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(respuesta))
                {
                    if (doc.RootElement.ValueKind == JsonValueKind.Object)
                    {
                        foreach (JsonProperty p in doc.RootElement.EnumerateObject())
                        {
                            if (p.Value.ValueKind == JsonValueKind.Number) return p.Value.GetInt32();
                        }
                    }
                }
            }
            catch (JsonException) { }
            return 0;
        }

        public static void Borrar(string ruta)
        {
            Enviar(HttpMethod.Delete, ruta);
        }

        public static void Actualizar(string ruta, object cuerpo)
        {
            Enviar(HttpMethod.Put, ruta, cuerpo);
        }
    }

    // Carga los datos de la API y los convierte a los modelos que usa la interfaz (Datos.Proyectos / Datos.Tareas).
    public static class Servicio
    {
        // Ids de estado de la BD por nombre de estado de la interfaz.
        public static Dictionary<string, int> IdEstado = new Dictionary<string, int>();
        public static int IdUsuario;
        public static List<ApiUsuario> Usuarios = new List<ApiUsuario>();

        // ASUNCIÓN: 1 = Baja, 2 = Media, 3 = Alta. Confirmar con el equipo de la API.
        public static string PrioridadTexto(int p) { return p >= 3 ? "Alta" : (p == 2 ? "Media" : "Baja"); }
        public static int PrioridadNumero(string t) { return t == "Alta" ? 3 : (t == "Media" ? 2 : 1); }

        private static string NormalizarEstado(string nombre)
        {
            string n = (nombre ?? "").ToLowerInvariant();
            if (n.Contains("pend") || n.Contains("todo") || n.Contains("por hacer")) return "Pendiente";
            if (n.Contains("prog") || n.Contains("curso")) return "En progreso";
            if (n.Contains("bloq") || n.Contains("block")) return "Bloqueada";
            if (n.Contains("fin") || n.Contains("compl") || n.Contains("hecha") || n.Contains("done") || n.Contains("cerr")) return "Finalizada";
            return nombre;
        }

        private static string Fecha(DateTime f)
        {
            if (f.Date == DateTime.Today) return "Hoy";
            return f.ToString("d MMM", Idiomas.Cultura());
        }

        public static void Cargar()
        {
            List<ApiProyecto> proyectos = Api.Lista<ApiProyecto>("api/Projects");
            List<ApiTarea> tareas = Api.Lista<ApiTarea>("api/Tasks");
            List<ApiEstado> estados = Api.Lista<ApiEstado>("api/StateTasks");
            List<ApiUsuario> usuarios = Api.Lista<ApiUsuario>("api/Users");
            List<ApiAsignacion> asignaciones = Api.Lista<ApiAsignacion>("api/TaskAssignments");
            List<ApiHoras> horas = Api.Lista<ApiHoras>("api/HourEntries");
            List<ApiProyectoUsuarioRol> pur = Api.Lista<ApiProyectoUsuarioRol>("api/ProjectUserRoles");
            List<ApiRol> roles = Api.Lista<ApiRol>("api/Roles");

            // Cada usuario solo ve los proyectos en los que está en el equipo, con todas sus tareas.
            HashSet<int> misProyectos = new HashSet<int>(pur.Where(r => r.IdUsers == IdUsuario).Select(r => r.IdProject));
            proyectos = proyectos.Where(p => misProyectos.Contains(p.IdProject)).ToList();
            tareas = tareas.Where(t => misProyectos.Contains(t.IdProject)).ToList();
            horas = horas.Where(h => tareas.Any(t => t.IdTask == h.IdTask)).ToList();

            Usuarios = usuarios;
            IdEstado = new Dictionary<string, int>();
            Dictionary<int, string> nombreEstado = new Dictionary<int, string>();
            foreach (ApiEstado e in estados)
            {
                string n = NormalizarEstado(e.NameState);
                nombreEstado[e.IdState] = n;
                if (!IdEstado.ContainsKey(n)) IdEstado[n] = e.IdState;
            }

            Dictionary<int, string> nombreUsuario = usuarios.ToDictionary(u => u.IdUser, u => (u.NameUser + " " + u.LastnameUser).Trim());
            Func<int, string> usuario = id => nombreUsuario.ContainsKey(id) ? nombreUsuario[id] : "—";

            List<Tarea> listaTareas = new List<Tarea>();
            foreach (ApiTarea t in tareas.OrderBy(x => x.DueDate))
            {
                ApiProyecto p = proyectos.FirstOrDefault(x => x.IdProject == t.IdProject);
                ApiAsignacion a = asignaciones.FirstOrDefault(x => x.IdTask == t.IdTask);
                decimal h = horas.Where(x => x.IdTask == t.IdTask).Sum(x => x.Hours);
                listaTareas.Add(new Tarea
                {
                    Id = t.IdTask,
                    IdProyecto = t.IdProject,
                    Original = t,
                    Titulo = t.Title,
                    Proyecto = p != null ? p.NameProject : "—",
                    Responsable = a != null ? usuario(a.IdUser) : "—",
                    Estado = nombreEstado.ContainsKey(t.IdState) ? nombreEstado[t.IdState] : "Pendiente",
                    Prioridad = PrioridadTexto(t.Priority),
                    HorasTotales = h,
                    Horas = h > 0 ? h.ToString("0.##", Idiomas.Cultura()) + " h" : "—",
                    Fecha = Fecha(t.DueDate)
                });
            }

            List<Proyecto> listaProyectos = new List<Proyecto>();
            foreach (ApiProyecto p in proyectos)
            {
                List<Tarea> deP = listaTareas.Where(t => t.IdProyecto == p.IdProject).ToList();
                int total = deP.Count;
                int fin = deP.Count(t => t.Estado == "Finalizada");
                int enProg = deP.Count(t => t.Estado == "En progreso");
                decimal horasReales = horas.Where(x => deP.Any(t => t.Id == x.IdTask)).Sum(x => x.Hours);

                // Responsable: usuario con un rol de dirección en el proyecto; si no, el primero asignado.
                ApiProyectoUsuarioRol resp = pur.FirstOrDefault(r => r.IdProject == p.IdProject && EsRolDireccion(roles, r.IdRoles))
                                             ?? pur.FirstOrDefault(r => r.IdProject == p.IdProject);
                string responsable = resp != null ? usuario(resp.IdUsers) : "—";

                // La API no guarda un estado de proyecto: se deduce del avance de sus tareas.
                string estado = total > 0 && fin == total ? "En revisión" : (fin > 0 || enProg > 0 ? "En progreso" : "Planificado");

                listaProyectos.Add(new Proyecto
                {
                    Id = p.IdProject,
                    Nombre = p.NameProject,
                    Descripcion = p.DescriptionProject,
                    Responsable = responsable,
                    Inicial = string.IsNullOrEmpty(p.NameProject) ? "?" : p.NameProject.Substring(0, 1).ToUpper(),
                    Estado = estado,
                    Entrega = Fecha(p.DateSubmit),
                    Completadas = fin,
                    Total = total,
                    HorasReales = horasReales,
                    HorasEstimadas = 0 // la API no guarda horas estimadas
                });
            }

            Datos.Proyectos = listaProyectos;
            Datos.Tareas = listaTareas;
            Datos.HorasRegistradasTotal = (double)horas.Sum(x => x.Hours);
            Datos.HorasMes = (double)horas.Where(x => x.Date.Year == DateTime.Today.Year && x.Date.Month == DateTime.Today.Month).Sum(x => x.Hours);
            Datos.HorasEstimadasTotal = 0;
        }

        private static bool EsRolDireccion(List<ApiRol> roles, int idRol)
        {
            ApiRol r = roles.FirstOrDefault(x => x.IdRoles == idRol);
            if (r == null) return false;
            string n = (r.NameRoles ?? "").ToLowerInvariant();
            return n.Contains("admin") || n.Contains("jefe") || n.Contains("respons") || n.Contains("manager") || n.Contains("lider") || n.Contains("líder");
        }

        // Login: la API (POST api/Users/login) comprueba el correo y la contraseña y devuelve el usuario con su rol.
        // Lanza ApiException con "Correo o contraseña incorrectos." si no coinciden.
        public static bool IniciarSesion(string email, string contrasena)
        {
            ApiUsuario u = Api.Enviar<ApiUsuario>("api/Users/login", new { MailUser = email.Trim(), PasswordUser = contrasena });
            if (u == null) return false;
            IdUsuario = u.IdUser;
            Datos.Nombre = (u.NameUser + " " + u.LastnameUser).Trim();
            Datos.Email = u.MailUser;
            Datos.Rol = u.NameRoles == "Administrador" ? "Administrador" : "Usuario";
            return true;
        }

        public static void Registrar(string nombre, string apellidos, string email, string contrasena)
        {
            if (Api.Lista<ApiUsuario>("api/Users").Any(u => string.Equals(u.MailUser, email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ApiException("Ya existe un usuario con ese correo.");
            }
            // La API guarda solo el hash de la contraseña.
            Api.Crear("api/Users", new { NameUser = nombre, LastnameUser = apellidos, MailUser = email, PasswordUser = contrasena });
        }

        public static void CrearProyecto(string nombre, string descripcion, DateTime inicio, DateTime entrega)
        {
            if (Datos.Rol != "Administrador")
            {
                throw new ApiException("Solo los administradores pueden crear proyectos.");
            }
            int id = Api.Crear("api/Projects", new ApiProyecto { NameProject = nombre, DescriptionProject = descripcion, DateStartProject = inicio, DateSubmit = entrega });
            // Quien crea el proyecto entra en su equipo como Administrador.
            ApiRol admin = Api.Lista<ApiRol>("api/Roles").FirstOrDefault(r => r.NameRoles == "Administrador");
            if (id > 0 && admin != null && IdUsuario > 0)
            {
                Api.Crear("api/ProjectUserRoles", new ApiProyectoUsuarioRol { IdRoles = admin.IdRoles, IdUsers = IdUsuario, IdProject = id });
            }
        }

        public static void CambiarEstado(Tarea t, string estado)
        {
            int idEstado;
            if (!IdEstado.TryGetValue(estado, out idEstado))
            {
                throw new ApiException(Idiomas.T("No existe el estado '{0}' en la base de datos.", estado));
            }
            ApiTarea o = t.Original;
            o.IdState = idEstado;
            o.StateDate = DateTime.Today;
            Api.Actualizar("api/Tasks/" + t.Id, o);
        }

        // Deja las horas totales de una tarea en la cifra indicada. La base de datos guarda un registro
        // por día, usuario y tarea: si suben, la diferencia se apunta hoy; si bajan, se descuenta de los más recientes.
        public static void GuardarHoras(Tarea t, decimal total)
        {
            List<ApiHoras> registros = Api.Lista<ApiHoras>("api/HourEntries").Where(x => x.IdTask == t.Id).ToList();
            decimal diferencia = total - registros.Sum(x => x.Hours);

            if (diferencia > 0)
            {
                ApiHoras hoy = registros.FirstOrDefault(x => x.Date.Date == DateTime.Today && x.IdUser == IdUsuario);
                if (hoy != null)
                {
                    hoy.Hours += diferencia;
                    Api.Actualizar(RutaHoras(hoy), hoy);
                    return;
                }
                // La fecha tiene que existir en la tabla DATE; si ya existe, la API lo rechaza y no pasa nada.
                try { Api.Crear("api/Dates", new { Date = DateTime.Today }); }
                catch (ApiException) { }
                Api.Crear("api/HourEntries", new ApiHoras { Date = DateTime.Today, IdUser = IdUsuario, IdTask = t.Id, Descriptions = "", Hours = diferencia });
                return;
            }

            decimal sobrante = -diferencia;
            foreach (ApiHoras r in registros.OrderByDescending(x => x.Date))
            {
                if (sobrante <= 0) break;
                if (r.Hours <= sobrante)
                {
                    sobrante -= r.Hours;
                    Api.Borrar(RutaHoras(r));
                }
                else
                {
                    r.Hours -= sobrante;
                    sobrante = 0;
                    Api.Actualizar(RutaHoras(r), r);
                }
            }
        }

        private static string RutaHoras(ApiHoras r)
        {
            return "api/HourEntries/" + r.Date.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "/" + r.IdUser + "/" + r.IdTask;
        }

        public static void CrearTarea(string titulo, int idProyecto, string prioridad, DateTime limite, int idResponsable)
        {
            int idEstado;
            if (!IdEstado.TryGetValue("Pendiente", out idEstado))
            {
                throw new ApiException("No existe un estado 'Pendiente' en la base de datos.");
            }
            int id = Api.Crear("api/Tasks", new ApiTarea
            {
                Title = titulo,
                DescriptionTask = "",
                Priority = PrioridadNumero(prioridad),
                StateDate = DateTime.Today,
                DueDate = limite,
                IdProject = idProyecto,
                IdState = idEstado
            });
            if (id > 0 && idResponsable > 0)
            {
                Api.Crear("api/TaskAssignments", new ApiAsignacion { IdUser = idResponsable, IdTask = id });
            }
        }

        public static void EliminarTarea(Tarea t)
        {
            GuardarHoras(t, 0); // se borran sus horas registradas
            // Primero se quitan las asignaciones; si tiene horas registradas la API responde con un conflicto.
            foreach (ApiAsignacion a in Api.Lista<ApiAsignacion>("api/TaskAssignments").Where(x => x.IdTask == t.Id))
            {
                Api.Borrar("api/TaskAssignments/" + a.IdUser + "/" + a.IdTask);
            }
            Api.Borrar("api/Tasks/" + t.Id);
        }
    }
}
