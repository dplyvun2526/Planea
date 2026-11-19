-- Datos de catálogo necesarios para que Planea funcione (ejecutar una sola vez).
-- Estados de tarea y roles. Los ids son autonuméricos (IDENTITY).
INSERT INTO STATE_TASKS (name_state) VALUES ('Pendiente'), ('En progreso'), ('Bloqueada'), ('Finalizada');
INSERT INTO ROLES (name_roles) VALUES ('Administrador'), ('Usuario');

-- PRIMER ADMINISTRADOR (una vez, tras registrarse desde la app). Ser "Administrador" = tener ese rol
-- en PROJECT_USER_ROLE (tabla ROLES). Hace falta un proyecto; después los admin crean los demás desde la app.
-- INSERT INTO PROJECTS (name_project, description_project, date_start_project, date_submit)
--     VALUES ('Planea', 'Proyecto inicial', GETDATE(), DATEADD(MONTH, 1, GETDATE()));
-- INSERT INTO PROJECT_USER_ROLE (id_roles, id_users, id_project)
--     SELECT (SELECT id_roles FROM ROLES WHERE name_roles = 'Administrador'), u.id_user, SCOPE_IDENTITY()
--     FROM USERS u WHERE u.mail_user = 'correo@ejemplo.com';
