using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProyectoDeskstop
{
    // Textos de la aplicación en castellano, catalán e inglés.
    // La clave es el texto en castellano; el valor tiene las tres traducciones en ese orden.
    public static class Idiomas
    {
        private static readonly Dictionary<string, string[]> D = new Dictionary<string, string[]>
        {
            // Menú y cabecera
            { "Inicio", new[] { "Inicio", "Inici", "Home" } },
            { "Proyectos", new[] { "Proyectos", "Projectes", "Projects" } },
            { "Tareas", new[] { "Tareas", "Tasques", "Tasks" } },
            { "Resumen", new[] { "Resumen", "Resum", "Summary" } },
            { "Ajustes", new[] { "Ajustes", "Configuració", "Settings" } },
            { "Buscar en Planea...", new[] { "Buscar en Planea...", "Cerca a Planea...", "Search in Planea..." } },
            { "Usuario", new[] { "Usuario", "Usuari", "User" } },
            { "Administrador", new[] { "Administrador", "Administrador", "Administrator" } },

            // Estados y prioridades
            { "Pendiente", new[] { "Pendiente", "Pendent", "Pending" } },
            { "Pendientes", new[] { "Pendientes", "Pendents", "Pending" } },
            { "En progreso", new[] { "En progreso", "En progrés", "In progress" } },
            { "En revisión", new[] { "En revisión", "En revisió", "In review" } },
            { "Planificado", new[] { "Planificado", "Planificat", "Planned" } },
            { "Bloqueada", new[] { "Bloqueada", "Bloquejada", "Blocked" } },
            { "Bloqueadas", new[] { "Bloqueadas", "Bloquejades", "Blocked" } },
            { "Finalizada", new[] { "Finalizada", "Finalitzada", "Completed" } },
            { "Finalizadas", new[] { "Finalizadas", "Finalitzades", "Completed" } },
            { "Todos", new[] { "Todos", "Tots", "All" } },
            { "Todas", new[] { "Todas", "Totes", "All" } },
            { "Alta", new[] { "Alta", "Alta", "High" } },
            { "Media", new[] { "Media", "Mitjana", "Medium" } },
            { "Baja", new[] { "Baja", "Baixa", "Low" } },
            { "Hoy", new[] { "Hoy", "Avui", "Today" } },

            // Inicio
            { "Buenos días", new[] { "Buenos días", "Bon dia", "Good morning" } },
            { "Buenas tardes", new[] { "Buenas tardes", "Bona tarda", "Good afternoon" } },
            { "Buenas noches", new[] { "Buenas noches", "Bona nit", "Good evening" } },
            { "Aquí tienes una visión general del trabajo de tu equipo.", new[] { "Aquí tienes una visión general del trabajo de tu equipo.", "Aquí tens una visió general del treball del teu equip.", "Here is an overview of your team's work." } },
            { "Horas este mes", new[] { "Horas este mes", "Hores aquest mes", "Hours this month" } },
            { "Proyectos activos", new[] { "Proyectos activos", "Projectes actius", "Active projects" } },
            { "Tareas pendientes", new[] { "Tareas pendientes", "Tasques pendents", "Pending tasks" } },
            { "Proyectos recientes", new[] { "Proyectos recientes", "Projectes recents", "Recent projects" } },
            { "Progreso de los proyectos en los que participas", new[] { "Progreso de los proyectos en los que participas", "Progrés dels projectes en què participes", "Progress of the projects you take part in" } },
            { "{0} de {1} tareas completadas", new[] { "{0} de {1} tareas completadas", "{0} de {1} tasques completades", "{0} of {1} tasks completed" } },
            { "Estado de tareas", new[] { "Estado de tareas", "Estat de les tasques", "Task status" } },
            { "Distribución total", new[] { "Distribución total", "Distribució total", "Total distribution" } },
            { "Próximas a finalizar", new[] { "Próximas a finalizar", "Properes a finalitzar", "Due soon" } },
            { "Tareas con fecha límite en los próximos días", new[] { "Tareas con fecha límite en los próximos días", "Tasques amb data límit en els propers dies", "Tasks with a deadline in the coming days" } },

            // Proyectos
            { "ESPACIO DE TRABAJO", new[] { "ESPACIO DE TRABAJO", "ESPAI DE TREBALL", "WORKSPACE" } },
            { "Consulta y realiza el seguimiento de todos los proyectos.", new[] { "Consulta y realiza el seguimiento de todos los proyectos.", "Consulta i fes el seguiment de tots els projectes.", "View and track all projects." } },
            { "{0} proyecto", new[] { "{0} proyecto", "{0} projecte", "{0} project" } },
            { "{0} proyectos", new[] { "{0} proyectos", "{0} projectes", "{0} projects" } },
            { "Responsable: {0}", new[] { "Responsable: {0}", "Responsable: {0}", "Owner: {0}" } },
            { "Tareas: {0}/{1}   ·   Entrega: {2}", new[] { "Tareas: {0}/{1}   ·   Entrega: {2}", "Tasques: {0}/{1}   ·   Entrega: {2}", "Tasks: {0}/{1}   ·   Due: {2}" } },

            // Tareas
            { "ORGANIZACIÓN DEL TRABAJO", new[] { "ORGANIZACIÓN DEL TRABAJO", "ORGANITZACIÓ DEL TREBALL", "WORK ORGANISATION" } },
            { "Consulta, filtra y actualiza las tareas asignadas.", new[] { "Consulta, filtra y actualiza las tareas asignadas.", "Consulta, filtra i actualitza les tasques assignades.", "View, filter and update your assigned tasks." } },
            { "+ Crear tarea", new[] { "+ Crear tarea", "+ Crear tasca", "+ New task" } },
            { "Todos los proyectos", new[] { "Todos los proyectos", "Tots els projectes", "All projects" } },
            { "Eliminar seleccionada", new[] { "Eliminar seleccionada", "Elimina la seleccionada", "Delete selected" } },
            { "{0} resultado", new[] { "{0} resultado", "{0} resultat", "{0} result" } },
            { "{0} resultados", new[] { "{0} resultados", "{0} resultats", "{0} results" } },
            { "Tarea", new[] { "Tarea", "Tasca", "Task" } },
            { "Proyecto", new[] { "Proyecto", "Projecte", "Project" } },
            { "Responsable", new[] { "Responsable", "Responsable", "Owner" } },
            { "Estado", new[] { "Estado", "Estat", "Status" } },
            { "Prioridad", new[] { "Prioridad", "Prioritat", "Priority" } },
            { "Horas", new[] { "Horas", "Hores", "Hours" } },
            { "Fecha límite", new[] { "Fecha límite", "Data límit", "Due date" } },
            { "Selecciona una tarea de la lista.", new[] { "Selecciona una tarea de la lista.", "Selecciona una tasca de la llista.", "Select a task from the list." } },
            { "¿Eliminar la tarea \"{0}\"?", new[] { "¿Eliminar la tarea \"{0}\"?", "Eliminar la tasca \"{0}\"?", "Delete the task \"{0}\"?" } },
            { "Confirmar", new[] { "Confirmar", "Confirma", "Confirm" } },
            { "Aviso", new[] { "Aviso", "Avís", "Notice" } },
            { "Título de la tarea:", new[] { "Título de la tarea:", "Títol de la tasca:", "Task title:" } },
            { "Crear tarea", new[] { "Crear tarea", "Crear tasca", "Create task" } },

            // Resumen
            { "RENDIMIENTO DEL EQUIPO", new[] { "RENDIMIENTO DEL EQUIPO", "RENDIMENT DE L'EQUIP", "TEAM PERFORMANCE" } },
            { "Resumen y estadísticas", new[] { "Resumen y estadísticas", "Resum i estadístiques", "Summary and statistics" } },
            { "Analiza el avance de los proyectos y el tiempo dedicado.", new[] { "Analiza el avance de los proyectos y el tiempo dedicado.", "Analitza l'avanç dels projectes i el temps dedicat.", "Review project progress and time spent." } },
            { "Total de tareas", new[] { "Total de tareas", "Total de tasques", "Total tasks" } },
            { "Tareas finalizadas", new[] { "Tareas finalizadas", "Tasques finalitzades", "Completed tasks" } },
            { "Tasa de finalización", new[] { "Tasa de finalización", "Taxa de finalització", "Completion rate" } },
            { "Estado de las tareas", new[] { "Estado de las tareas", "Estat de les tasques", "Task status" } },
            { "Distribución por estado", new[] { "Distribución por estado", "Distribució per estat", "Distribution by status" } },
            { "Horas por proyecto", new[] { "Horas por proyecto", "Hores per projecte", "Hours per project" } },
            { "Reales frente a estimadas", new[] { "Reales frente a estimadas", "Reals davant estimades", "Actual vs estimated" } },
            { "Horas estimadas", new[] { "Horas estimadas", "Hores estimades", "Estimated hours" } },
            { "Horas registradas", new[] { "Horas registradas", "Hores registrades", "Logged hours" } },
            { "Uso de horas", new[] { "Uso de horas", "Ús d'hores", "Hours used" } },
            { "{0} h / {1} h", new[] { "{0} h / {1} h", "{0} h / {1} h", "{0} h / {1} h" } },

            // Ajustes
            { "TU ESPACIO", new[] { "TU ESPACIO", "EL TEU ESPAI", "YOUR SPACE" } },
            { "Configura tu perfil y las opciones de Planea.", new[] { "Configura tu perfil y las opciones de Planea.", "Configura el teu perfil i les opcions de Planea.", "Set up your profile and Planea options." } },
            { "Perfil", new[] { "Perfil", "Perfil", "Profile" } },
            { "Idioma", new[] { "Idioma", "Idioma", "Language" } },
            { "Notificaciones", new[] { "Notificaciones", "Notificacions", "Notifications" } },
            { "Información visible para el resto del equipo", new[] { "Información visible para el resto del equipo", "Informació visible per a la resta de l'equip", "Information visible to the rest of the team" } },
            { "Nombre a mostrar:", new[] { "Nombre a mostrar:", "Nom a mostrar:", "Display name:" } },
            { "Guardar", new[] { "Guardar", "Desa", "Save" } },
            { "Vista del rol (para comprobar las acciones disponibles):", new[] { "Vista del rol (para comprobar las acciones disponibles):", "Vista del rol (per comprovar les accions disponibles):", "Role view (to check which actions are available):" } },
            { "Cerrar sesión", new[] { "Cerrar sesión", "Tanca la sessió", "Sign out" } },
            { "Cambios guardados. El menú se actualiza al cambiar de página.", new[] { "Cambios guardados. El menú se actualiza al cambiar de página.", "Canvis desats. El menú s'actualitza en canviar de pàgina.", "Changes saved. The menu updates when you change page." } },
            { "El nombre no puede estar vacío.", new[] { "El nombre no puede estar vacío.", "El nom no pot estar buit.", "The name cannot be empty." } },
            { "Planea usa por defecto el idioma de tu dispositivo", new[] { "Planea usa por defecto el idioma de tu dispositivo", "Planea fa servir per defecte l'idioma del teu dispositiu", "Planea uses your device's language by default" } },
            { "Español", new[] { "Español", "Espanyol", "Spanish" } },
            { "El idioma de navegación se ha actualizado.", new[] { "El idioma de navegación se ha actualizado.", "L'idioma de navegació s'ha actualitzat.", "The navigation language has been updated." } },
            { "Elige qué actualizaciones quieres recibir", new[] { "Elige qué actualizaciones quieres recibir", "Tria quines actualitzacions vols rebre", "Choose which updates you want to receive" } },
            { "Tareas asignadas", new[] { "Tareas asignadas", "Tasques assignades", "Assigned tasks" } },
            { "Cuando alguien te asigne una nueva tarea", new[] { "Cuando alguien te asigne una nueva tarea", "Quan algú t'assigni una nova tasca", "When someone assigns you a new task" } },
            { "Fechas límite", new[] { "Fechas límite", "Dates límit", "Due dates" } },
            { "Recordatorios de tareas próximas a vencer", new[] { "Recordatorios de tareas próximas a vencer", "Recordatoris de tasques properes a vencre", "Reminders for tasks that are due soon" } },
            { "Actualizaciones de proyecto", new[] { "Actualizaciones de proyecto", "Actualitzacions de projecte", "Project updates" } },
            { "Cambios importantes en tus proyectos", new[] { "Cambios importantes en tus proyectos", "Canvis importants en els teus projectes", "Important changes in your projects" } },
            { "Activo", new[] { "Activo", "Actiu", "On" } },
            { "Inactivo", new[] { "Inactivo", "Inactiu", "Off" } },

            // Inicio de sesión
            { "Planea - Iniciar sesión", new[] { "Planea - Iniciar sesión", "Planea - Inicia sessió", "Planea - Sign in" } },
            { "Bienvenido a Planea", new[] { "Bienvenido a Planea", "Benvingut a Planea", "Welcome to Planea" } },
            { "Inicia sesión para continuar", new[] { "Inicia sesión para continuar", "Inicia sessió per continuar", "Sign in to continue" } },
            { "Entrar como", new[] { "Entrar como", "Entrar com a", "Sign in as" } },
            { "Correo electrónico", new[] { "Correo electrónico", "Correu electrònic", "Email" } },
            { "Contraseña", new[] { "Contraseña", "Contrasenya", "Password" } },
            { "Iniciar sesión", new[] { "Iniciar sesión", "Inicia sessió", "Sign in" } },
            { "¿No tienes cuenta?", new[] { "¿No tienes cuenta?", "No tens compte?", "Don't have an account?" } },
            { "Crear cuenta", new[] { "Crear cuenta", "Crea un compte", "Create account" } },
            { "El registro de cuentas estará disponible cuando se conecte la base de datos.", new[] { "El registro de cuentas estará disponible cuando se conecte la base de datos.", "El registre de comptes estarà disponible quan es connecti la base de dades.", "Account registration will be available once the database is connected." } },
            { "Próximamente", new[] { "Próximamente", "Properament", "Coming soon" } },

            // Registro, proyectos, equipos y tareas (conectado a la API)
            { "+ Crear proyecto", new[] { "+ Crear proyecto", "+ Crear projecte", "+ Create project" } },
            { "Apellidos", new[] { "Apellidos", "Cognoms", "Last name" } },
            { "Añadir al equipo", new[] { "Añadir al equipo", "Afegir a l'equip", "Add to team" } },
            { "Cambiar estado", new[] { "Cambiar estado", "Canviar estat", "Change status" } },
            { "Cancelar", new[] { "Cancelar", "Cancel·lar", "Cancel" } },
            { "Cerrar", new[] { "Cerrar", "Tancar", "Close" } },
            { "Consulta y realiza el seguimiento de todos los proyectos. Haz clic en uno para gestionar su equipo.", new[] { "Consulta y realiza el seguimiento de todos los proyectos. Haz clic en uno para gestionar su equipo.", "Consulta i fes el seguiment de tots els projectes. Fes clic en un per gestionar el seu equip.", "View and track all projects. Click one to manage its team." } },
            { "Correo o contraseña incorrectos.", new[] { "Correo o contraseña incorrectos.", "Correu o contrasenya incorrectes.", "Incorrect email or password." } },
            { "Crear proyecto", new[] { "Crear proyecto", "Crear projecte", "Create project" } },
            { "Cuenta creada. Ya puedes iniciar sesión.", new[] { "Cuenta creada. Ya puedes iniciar sesión.", "Compte creat. Ja pots iniciar sessió.", "Account created. You can now sign in." } },
            { "Descripción", new[] { "Descripción", "Descripció", "Description" } },
            { "El nombre es obligatorio.", new[] { "El nombre es obligatorio.", "El nom és obligatori.", "The name is required." } },
            { "El título es obligatorio.", new[] { "El título es obligatorio.", "El títol és obligatori.", "The title is required." } },
            { "Equipo", new[] { "Equipo", "Equip", "Team" } },
            { "Ese usuario ya está en el equipo.", new[] { "Ese usuario ya está en el equipo.", "Aquest usuari ja és a l'equip.", "That user is already on the team." } },
            { "Fecha de entrega", new[] { "Fecha de entrega", "Data de lliurament", "Due date" } },
            { "Fecha de inicio", new[] { "Fecha de inicio", "Data d'inici", "Start date" } },
            { "Introduce tu correo y tu contraseña.", new[] { "Introduce tu correo y tu contraseña.", "Introdueix el teu correu i la teva contrasenya.", "Enter your email and password." } },
            { "La entrega no puede ser anterior al inicio.", new[] { "La entrega no puede ser anterior al inicio.", "El lliurament no pot ser anterior a l'inici.", "The due date cannot be before the start date." } },
            { "Las contraseñas no coinciden.", new[] { "Las contraseñas no coinciden.", "Les contrasenyes no coincideixen.", "Passwords do not match." } },
            { "Miembros del proyecto", new[] { "Miembros del proyecto", "Membres del projecte", "Project members" } },
            { "Nombre", new[] { "Nombre", "Nom", "Name" } },
            { "Nombre del proyecto", new[] { "Nombre del proyecto", "Nom del projecte", "Project name" } },
            { "Primero tiene que existir un proyecto.", new[] { "Primero tiene que existir un proyecto.", "Primer ha d'existir un projecte.", "A project must exist first." } },
            { "Quitar seleccionado", new[] { "Quitar seleccionado", "Treure seleccionat", "Remove selected" } },
            { "Rellena todos los campos con un correo válido.", new[] { "Rellena todos los campos con un correo válido.", "Omple tots els camps amb un correu vàlid.", "Fill in all fields with a valid email." } },
            { "Repite la contraseña", new[] { "Repite la contraseña", "Repeteix la contrasenya", "Repeat password" } },
            { "Rol", new[] { "Rol", "Rol", "Role" } },
            { "mostrando {0}", new[] { "mostrando {0}", "mostrant {0}", "showing {0}" } },
        };

        private static int Indice()
        {
            if (Datos.Idioma == "Català") return 1;
            if (Datos.Idioma == "English") return 2;
            return 0;
        }

        // Devuelve el texto en el idioma elegido. Si la clave no existe, devuelve la clave tal cual.
        public static string T(string clave, params object[] args)
        {
            string plantilla = clave;
            string[] valores;
            if (D.TryGetValue(clave, out valores))
            {
                plantilla = valores[Indice()];
            }
            return args.Length == 0 ? plantilla : string.Format(plantilla, args);
        }

        public static CultureInfo Cultura()
        {
            if (Datos.Idioma == "Català") return new CultureInfo("ca-ES");
            if (Datos.Idioma == "English") return new CultureInfo("en-US");
            return new CultureInfo("es-ES");
        }
    }
}
