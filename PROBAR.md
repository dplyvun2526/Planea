# Cómo probar Planea (app de escritorio + API)

La app de escritorio habla con la **API**, y la API con la **base de datos** del equipo. Hay que arrancar la API primero y la app después.

## Requisitos
- Windows con **.NET 10 SDK** (para la API) y **.NET 8 Desktop Runtime** (para la app). Comprueba con `dotnet --list-sdks` y `dotnet --list-runtimes`.
- La contraseña de la base de datos (la tiene el equipo). **No la escribas nunca en archivos del repo.**

## 1. Descargar los dos repositorios
```powershell
git clone https://github.com/seda-123/Planea_Api.git
git clone https://github.com/dplyvun2526/Planea.git
```
Si ya los tenías, actualízalos: en `Planea_Api` ejecuta `git checkout master` y `git pull`; en `Planea`, `git checkout main` y `git pull`.

## 2. Arrancar la API (ventana de PowerShell nº 1; déjala abierta)
```powershell
cd Planea_Api\Planea_Api
$env:ConnectionStrings__DefaultConnection = "Server=<SERVIDOR>;Database=<BASE_DE_DATOS>;User Id=<USUARIO>;Password=<CONTRASEÑA>;TrustServerCertificate=True;Encrypt=True;Connect Timeout=15"
dotnet run --launch-profile http
```
Debe aparecer `Now listening on: http://localhost:5097`. El servidor, la base de datos y el usuario son los del equipo.

## 3. Arrancar la app (ventana de PowerShell nº 2)
```powershell
cd Planea
dotnet run
```
Se abre el login. Si la API está en otra dirección, define antes `$env:PLANEA_API_URL = "http://localhost:5097/"`.

## 4. Qué probar
1. **Admin:** entra con una cuenta administradora. Debe verse el botón "+ Crear proyecto".
2. **Crear proyecto** (nombre, descripción, fechas) y comprobar que aparece su tarjeta.
3. **Equipo:** clic en una tarjeta → añadir un usuario con un rol.
4. **Tareas:** "+ Crear tarea" (proyecto, prioridad, fecha, responsable); luego "Cambiar estado" y "Eliminar seleccionada".
5. **Inicio y Resumen:** las cifras cambian con lo creado.
6. **Usuario normal:** "Crear cuenta" → entra con él: no ve "+ Crear proyecto" ni proyectos ajenos. Con el admin, añádelo a un proyecto y vuelve a entrar con él: ve el proyecto y todas sus tareas.
7. **Idiomas:** Ajustes → Idioma (Castellano, Català, English). Se recuerda al reabrir.
8. **Ajustes:** el perfil muestra nombre, correo y rol, solo para consultar.

## Notas
- Lo que crees se guarda en la base de datos **compartida**: usa nombres tipo "PRUEBA …".
- Un usuario es administrador si tiene el rol "Administrador" en algún proyecto (tabla `PROJECT_USER_ROLE`); los usuarios nuevos siempre son "Usuario".
- Si falla algo, copia el mensaje exacto (de la app o de la ventana de la API) y avisa a Denys.
