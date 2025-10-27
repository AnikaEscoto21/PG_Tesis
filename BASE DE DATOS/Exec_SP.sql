--EXEC PRUEBAS BD_CONSULTORESSI
-- Ejecutar el SP con credenciales de prueba

USE BD_ConsultoresSI;

GO 

EXEC sp_Login 
    @Email = 'admin@evalysi.com',
    @HashPassword = '123456';

EXEC dbo.sp_Candidato
    @Nombres='Juan Carlos',
    @Apellidos='Pérez Gómez',
    @Edad=29,
    @DPI='1234567890123',
    @DPIExtendidoEn='Guatemala',
    @LugarNacimiento='Ciudad de Guatemala',
    @FechaNacimiento='1996-08-15',
    @Direccion='Zona 9, Ciudad de Guatemala',
    @Nacionalidad='Guatemalteca',
    @NumIGSS='99887766',
    @TelefonoCasa=NULL,
    @TelefonoCelular='51234567',
    @Profesion='Ingeniero en Sistemas',
    @PlazaAplica='Desarrollador Web',
    @EstadoCivil='Soltero',
    @TipoSangre='O+',
    @ContactoEmergencia='María Pérez',
    @TelefonoEmergencia='42157890',
    @DependientesEconomicos='Ninguno',
    @NIT='7654321-9',
    @ExperienciasPoligraficas='Sí, 2023 en Consultores SI',
    @ResultadoPoligrafoPrevio='Aprobado',
    @PorcentajeIngles=85,
    @Correo='juan.perez@example.com',
    @UsuariosRedes='@juanperez_gt',
    @ConyugeNombre=NULL,
    @ConyugeEdad=NULL,
    @ConyugeDPI=NULL,
    @ConyugeCel=NULL,
    @ConyugeEstadoCivil=NULL,
    @ConyugeOcupacion=NULL,
    @ConyugeTrabajo=NULL,
    @ConyugeTelTrabajo=NULL;


EXEC sp_Padres
    @CandidatoId   = 1,                 
    @NombrePadre   = 'Carlos Cacao',
    @NombreMadre   = 'María Sánchez',
    @EdadP         = 55,
    @EdadM         = 52,
    @NoResidenciaP = 'KM-12 Lote 4',
    @NoResidenciaM = 'KM-12 Lote 4',
    @DPIP          = '1234567890123',
    @DPIM          = '9876543210123',
    @EstadoCivilP  = 'Casado',
    @EstadoCivilM  = 'Casada',
    @CelularP      = '50112233',
    @CelularM      = '50112234',
    @ProfesionP    = 'Carpintero',
    @ProfesionM    = 'Docente',
    @NacionalidadP = 'Guatemalteca',
    @NacionalidadM = 'Guatemalteca',
    @LugarTrabajoP = 'Taller El Roble',
    @LugarTrabajoM = 'Colegio Nacional';


SELECT * FROM Padres


EXEC dbo.sp_Hermano
    @CandidatoId = 1,              
    @Nombre      = N'Luis Cacao',
    @Edad        = 27,
    @NoResidencia= N'Km 12 Lote 4',
    @DPI         = N'1234567890123',
    @EstadoCivil = N'Soltero',
    @Celular     = N'50112233',
    @Profesion   = N'Técnico en Redes',
    @Nacionalidad= N'Guatemalteca',
    @LugarTrabajo= N'IT Solutions';

SELECT * FROM Hermanos

EXEC sp_Hijos
    @CandidatoId       = 1,                 
    @NombreHijo        = N'Gabriela Cacao',
    @EdadHijo          = 8,
    @EstadoCivilHijo   = 'Soltera',
    @Direccion         = 'Col. Las Flores, zona 7',
    @Ocupacion         = 'Estudiante',
    @Nacionalidad      = 'Guatemalteca',
    @LugarTrabajo      = NULL;               

	SELECT * FROM Hijos

