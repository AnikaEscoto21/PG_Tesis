USE BD_ConsultoresSI;

GO

--SP VISTA ADMINISTRADOR
CREATE PROCEDURE sp_Candidato_Resumen
AS
BEGIN
    SELECT 
        Id,
        Nombres,
        Apellidos,
        FechaRegistro,
		DPI,
		TelefonoCelular
    FROM Candidatos
END
GO

CREATE PROCEDURE sp_Candidato_PorId
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT
        Id, Nombres, Apellidos, Edad, DPI, DPIExtendidoEn,
        LugarNacimiento, FechaNacimiento, Direccion, Nacionalidad,
        NumIGSS, TelefonoCasa, TelefonoCelular,
        Profesion, PlazaAplica, EstadoCivil, TipoSangre,
        ContactoEmergencia, TelefonoEmergencia, DependientesEconomicos,
        NIT, ExperienciasPoligraficas, ResultadoPoligrafoPrevio,
        PorcentajeIngles, Correo, UsuariosRedes,
        ConyugeNombre, ConyugeEdad, ConyugeDPI, ConyugeCel,
        ConyugeEstadoCivil, ConyugeOcupacion, ConyugeTrabajo, ConyugeTelTrabajo,
        FechaRegistro
    FROM Candidatos 
    WHERE Id = @Id;
END
GO

CREATE OR ALTER PROCEDURE sp_Padres_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        NombrePadre, NombreMadre,
        EdadP, EdadM,
        NoResidenciaP, NoResidenciaM,
        DPIP, DPIM,
        EstadoCivilP, EstadoCivilM,
        CelularP, CelularM,
        ProfesionP, ProfesionM,
        NacionalidadP, NacionalidadM,
        LugarTrabajoP, LugarTrabajoM
    FROM Padres 
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE PROCEDURE sp_Hermanos_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdHermano,
        CandidatoId,
        Nombre,
        Edad,
        NoResidencia,
        DPI,
        EstadoCivil,
        Celular,
        Profesion,
        Nacionalidad,
        LugarTrabajo
    FROM Hermanos 
    WHERE CandidatoId = @CandidatoId;
END
GO

CREATE OR ALTER PROCEDURE sp_Hijos_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdHijos As Id,
        CandidatoId,
        NombreHijo,
        EdadHijo,
        Direccion,
        Ocupacion,
        EstadoCivilHijo,
        Nacionalidad,
        LugarTrabajo
    FROM Hijos 
    WHERE CandidatoId = @CandidatoId;
END
GO

CREATE PROCEDURE sp_Deudas_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdDeudas,
        CandidatoId,
        Banco,
        MontoMensual,
        Razon
    FROM Deudas 
    WHERE CandidatoId = @CandidatoId;
END
GO

--SP_GASTOSMENSUALES
CREATE OR ALTER PROCEDURE sp_Gastos_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdGM AS IdDeudas,  
        CandidatoId,
        ConceptoNombre AS NombreConcepto,  
        EsIngreso,
        Monto
    FROM GastosMensuales 
    WHERE CandidatoId = @CandidatoId;
END
GO

CREATE PROCEDURE sp_Tarjeta_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdTarjeta,
        CandidatoId,
        Banco,
        LimiteCredito,
        SaldoActual
    FROM TarjetasCredito 
    WHERE CandidatoId = @CandidatoId;
END
GO

CREATE OR ALTER PROCEDURE sp_Estudio_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdEstudio,
        CandidatoId,
        NombreInstitucion,
        EstudiosRealizados,
        Lugar,
        FechaDesde,
        FechaHasta,
        UltimoGrado
    FROM Estudios 
    WHERE CandidatoId = @CandidatoId;
END
GO

CREATE OR ALTER PROCEDURE sp_HistorialLaboral_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        CandidatoId,
        Empresa,
        Cargo,
        TelefonoEmpresa,
        FechaIngreso,
        FechaEgreso,
        UltimoSalario,
        CausaRetiro,
        JefeInmediato,
        TelefonoJefe,
        CargoJefe,
        Observaciones
    FROM HistorialLaboral 
    WHERE CandidatoId = @CandidatoId;
END
GO

CREATE OR ALTER PROCEDURE sp_AspectosEmocionales_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        VivenPadres,
        RelacionEntrePadres,
        ConQuienVive,
        IntentosSuicidio,
        CualidadRespeta,
        DefectoIntolerable,
        MejorExperiencia,
        PeorExperiencia
    FROM AspectosEmocionales 
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE OR ALTER PROCEDURE sp_CuentasBancarias_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdCuenta,
        CandidatoId,
        Banco,
        TipoCuenta,
        Saldo
    FROM CuentasBancarias 
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE OR ALTER PROCEDURE sp_Vehiculos_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        CandidatoId,
        Marca,
        Modelo,
        Placas
    FROM Vehiculos 
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE OR ALTER PROCEDURE sp_InformacionSocial_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        Religion,
        FrecuenciaCulto,
        Grupos,
        ActividadesTiempoLibre,
        Autodescripcion,
        Piercings,
        Tatuajes,
        TatuajesDescripcion
    FROM InfoSocial
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE OR ALTER PROCEDURE sp_ProcesoContratacion_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        OcultoIdentidad,
        OmisionDeliberada,
        DocumentoFalso,
        InfoFalsaCV,
        DocumentosEnOrden,
        Observaciones
    FROM ProcesoContratacion
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE PROCEDURE sp_PreguntasLaborales_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        PedidoRenuncia,
        AbandonoEmpleo,
        AcusadoDeshonestidad,
        VReglamentos,
        BeneficiosIlicitos,
        UsoIndebidoInfoConf,
        DiscusionesConSuperiores,
        ActaAdmOProceso,
        Sobornos,
        Sabotaje,
        DemandaContra,
        DemandaAAlguien,
        Observaciones,
        ProblemasLaborales,
        FaltasAdmSerias,
        OpinionSindicatos
    FROM PreguntasLaborales
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE PROCEDURE sp_Valores_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        HonestaIdentidad,
        DocumentoFalsoEnPlaza,
        ManejoValores,
        Faltantes,
        Sobrantes,
        PrestamosConDineroACargo,
        ManejoInfoConf,
        UsoIndebidoInfoConf
    FROM HonestidadValores
    WHERE CandidatoId = @CandidatoId;
END
GO



CREATE PROCEDURE sp_HistoriaMedica_CandidatoId
 @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        CondicionGeneral,
        MalestarActual,
        HoraUltimaComida,
        HorasDormidasAyer,
        Embarazo,
        EnfermedadGrave
    FROM HistoriaMedica WHERE CandidatoId = @CandidatoId;
END
GO



CREATE OR ALTER PROCEDURE sp_HistoriaMedicaCond_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        CondicionNombre,
        Especificar,
        Fecha
    FROM HistoriaMedicaCond
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE PROCEDURE sp_Medicamentos_CandidatoId
@CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        IngestaAlcohol24h,
        Droga30dias,
        TratMedicoReciente,
        ConsumeMedicamentos,
        DopingPracticado,
        DopingAlterado,
        Cirugia,
        AlergiaMedicamento,
        UltimoChequeoMedico,
        AlergiaComida,
        UltimoChequeoOdonto,
        UltimoChequeoOftalmo,
        UsaLentes,
        Fuma,
        Observaciones
    FROM UsoMedicamentos WHERE CandidatoId = @CandidatoId;
END
GO



CREATE PROCEDURE sp_HabitosAlcohol_CandidatoId
@CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        UltimaVezBebio,
        PromedioMensual,
        ExcesosPorAnio,
        ComoEsCuandoExcede,
        UltimaAmnesia,
        UltimaConduccionEbrio,
        PeorEvento,
        PeleaAlBeber,
        DetenidoAlBeber,
        TratamientoControlBeber,
        LaboroEbrioResaca,
        FaltoPorBeber,
        BebioEnHorasTrabajo
    FROM HabitosAlcohol WHERE CandidatoId = @CandidatoId;
END
GO


CREATE OR ALTER PROCEDURE sp_Drogas_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        UltimaVezConsumo,
        ProboDrogas,
        CualquierContacto,
        GuardoDrogaAjena,
        ContactoConVendedores,
        FamiliarConsume
    FROM Drogas 
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE OR ALTER PROCEDURE sp_Antecedentes_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        CausoHeridasGraves,
        MatoAlguien,
        UltimaRina,
        UltimaPerdidaControl
    FROM AntecedentesGenerales
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE PROCEDURE sp_ActividadesDelictivas_CandidatoId
@CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        AsociadoConDelincuentes,
        ConoceDelincuentes,
        DetenidoCuestionado,
        EstuvoRecluso,
        HizoAlgoDetenido,
        FamiliarDetenido,
        CargosPorFaltas,
        PenalesPoliciacosLimpios,
        AyudoCometerDelito,
        CambioPrecios,
        UsoIlegalTarjeta,
        DocumentoFalsificado,
        RoboArticulo,
        CompraVentaAutosRobados,
        ActoSIlegal,
        AcosoS,
        PG,
        BeneficiosPros,
        Secuestro,
        OtraActividadIllicita
    FROM ActividadesDelictivas WHERE CandidatoId = @CandidatoId;
END
GO


CREATE OR ALTER PROCEDURE sp_ManejoArmas_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        TieneArmasPropias,
        HaPortadoArma,
        EnfrentamientoConArma,
        DisparoInnecesario,
        UsoIndebidoArma,
        CompraVentaIlegalArmas
    FROM ManejoArmas 
    WHERE CandidatoId = @CandidatoId;
END
GO


CREATE OR ALTER PROCEDURE sp_Conclusiones_CandidatoId
    @CandidatoId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CandidatoId,
        ExperienciaChantajeable,
        PensabaPreguntasFaltantes,
        FalseoOmisiones,
        AlgoQuePreocupe,
        AlgoQueDecir, 
		ObjetivosCP,
		ObjetivosMP,
		ObjetivosLP
    FROM Conclusiones 
    WHERE CandidatoId = @CandidatoId;
END
GO



--CREATE OR ALTER PROCEDURE sp_Candidato_Actualizar
--    @Id INT,
--    @Nombres NVARCHAR(100),
--    @Apellidos NVARCHAR(100),
--    @Edad INT = NULL,
--    @DPI NVARCHAR(20),
--    @DPIExtendidoEn NVARCHAR(100),
--    @LugarNacimiento NVARCHAR(100),
--    @FechaNacimiento DATE = NULL,
--    @Direccion NVARCHAR(200),
--    @Nacionalidad NVARCHAR(50),
--    @NumIGSS NVARCHAR(20),
--    @TelefonoCasa NVARCHAR(20),
--    @TelefonoCelular NVARCHAR(20),
--    @Profesion NVARCHAR(100),
--    @PlazaAplica NVARCHAR(100),
--    @EstadoCivil NVARCHAR(50),
--    @TipoSangre NVARCHAR(10),
--    @ContactoEmergencia NVARCHAR(100),
--    @TelefonoEmergencia NVARCHAR(20),
--    @DependientesEconomicos NVARCHAR(100),
--    @NIT NVARCHAR(20),
--    @ExperienciasPoligraficas NVARCHAR(MAX),
--    @ResultadoPoligrafoPrevio NVARCHAR(100),
--    @PorcentajeIngles TINYINT,
--    @Correo NVARCHAR(100),
--    @UsuariosRedes NVARCHAR(200),
--    @ConyugeNombre NVARCHAR(100),
--    @ConyugeEdad INT = NULL,
--    @ConyugeDPI NVARCHAR(20),
--    @ConyugeCel NVARCHAR(20),
--    @ConyugeEstadoCivil NVARCHAR(50),
--    @ConyugeOcupacion NVARCHAR(100),
--    @ConyugeTrabajo NVARCHAR(100),
--    @ConyugeTelTrabajo NVARCHAR(20)
--AS
--BEGIN
--    SET NOCOUNT ON;

--    UPDATE Candidatos
--    SET 
--        Nombres = @Nombres,
--        Apellidos = @Apellidos,
--        Edad = @Edad,
--        DPI = @DPI,
--        DPIExtendidoEn = @DPIExtendidoEn,
--        LugarNacimiento = @LugarNacimiento,
--        FechaNacimiento = @FechaNacimiento,
--        Direccion = @Direccion,
--        Nacionalidad = @Nacionalidad,
--        NumIGSS = @NumIGSS,
--        TelefonoCasa = @TelefonoCasa,
--        TelefonoCelular = @TelefonoCelular,
--        Profesion = @Profesion,
--        PlazaAplica = @PlazaAplica,
--        EstadoCivil = @EstadoCivil,
--        TipoSangre = @TipoSangre,
--        ContactoEmergencia = @ContactoEmergencia,
--        TelefonoEmergencia = @TelefonoEmergencia,
--        DependientesEconomicos = @DependientesEconomicos,
--        NIT = @NIT,
--        ExperienciasPoligraficas = @ExperienciasPoligraficas,
--        ResultadoPoligrafoPrevio = @ResultadoPoligrafoPrevio,
--        PorcentajeIngles = @PorcentajeIngles,
--        Correo = @Correo,
--        UsuariosRedes = @UsuariosRedes,
--        ConyugeNombre = @ConyugeNombre,
--        ConyugeEdad = @ConyugeEdad,
--        ConyugeDPI = @ConyugeDPI,
--        ConyugeCel = @ConyugeCel,
--        ConyugeEstadoCivil = @ConyugeEstadoCivil,
--        ConyugeOcupacion = @ConyugeOcupacion,
--        ConyugeTrabajo = @ConyugeTrabajo,
--        ConyugeTelTrabajo = @ConyugeTelTrabajo
--    WHERE Id = @Id;
--END
--GO

--CREATE OR ALTER PROCEDURE sp_Candidato_Eliminar
--    @CandidatoId INT
--AS
--BEGIN
--    SET NOCOUNT ON;

--    -- Soft delete (si tienes columna Activo)
--    UPDATE Candidatos
--    SET Activo = 0
--    WHERE Id = @CandidatoId;
    
--    -- O hard delete si prefieres:
--    -- DELETE FROM Candidatos WHERE Id = @CandidatoId;
--END
--GO