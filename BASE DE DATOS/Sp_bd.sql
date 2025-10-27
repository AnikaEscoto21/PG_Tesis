USE BD_ConsultoresSI;

GO

CREATE PROCEDURE sp_Login
    @Email NVARCHAR(255),  
    @HashPassword VARCHAR(255)
AS
BEGIN
    SELECT 
        IdUsuario,
        Email,
        Nombre,
        FechaCreacion
    FROM Usuarios
    WHERE Email=@Email AND HashPassword = @HashPassword
END


--SP_CANDIDATO
CREATE PROCEDURE sp_Candidato
    @Nombres VARCHAR(100),
    @Apellidos VARCHAR(100),
    @Edad INT,
    @DPI VARCHAR(13),
    @DPIExtendidoEn VARCHAR(15),
	@LugarNacimiento VARCHAR(120) = NULL,
    @FechaNacimiento DATE,
	@Direccion VARCHAR(200),
    @Nacionalidad VARCHAR(60),
	@NumIGSS VARCHAR(20) = NULL,
    @TelefonoCasa VARCHAR(10) = NULL,
    @TelefonoCelular VARCHAR(10),
	@Profesion VARCHAR(100),
    @PlazaAplica VARCHAR(100),
	@EstadoCivil VARCHAR(40),
    @TipoSangre VARCHAR(10),
	@ContactoEmergencia VARCHAR(100),
    @TelefonoEmergencia VARCHAR(10),
	@DependientesEconomicos VARCHAR(50),
	@NIT VARCHAR(20),
	@ExperienciasPoligraficas VARCHAR(100) = NULL,
    @ResultadoPoligrafoPrevio VARCHAR(100) = NULL,
	@PorcentajeIngles TINYINT,
    @Correo NVARCHAR(255),
    @UsuariosRedes VARCHAR(150) = NULL,
    @ConyugeNombre VARCHAR(120) = NULL,
    @ConyugeEdad INT = NULL,
    @ConyugeDPI VARCHAR(13) = NULL,
    @ConyugeCel VARCHAR(10) = NULL,
    @ConyugeEstadoCivil VARCHAR(40) = NULL,
    @ConyugeOcupacion VARCHAR(120) = NULL,
    @ConyugeTrabajo VARCHAR(200) = NULL,
    @ConyugeTelTrabajo VARCHAR(25) = NULL

AS
BEGIN
    SET NOCOUNT ON;
        
		INSERT INTO Candidatos (
			Nombres, Apellidos, Edad, DPI, DPIExtendidoEn,
			LugarNacimiento, FechaNacimiento, Direccion, Nacionalidad,
			NumIGSS, TelefonoCasa, TelefonoCelular,
			Profesion, PlazaAplica, EstadoCivil, TipoSangre,
			ContactoEmergencia, TelefonoEmergencia, DependientesEconomicos,
			NIT, ExperienciasPoligraficas, ResultadoPoligrafoPrevio,
			PorcentajeIngles, Correo, UsuariosRedes,
			ConyugeNombre, ConyugeEdad, ConyugeDPI, ConyugeCel,
			ConyugeEstadoCivil, ConyugeOcupacion, ConyugeTrabajo, ConyugeTelTrabajo,
			FechaRegistro
		)
		VALUES (
			@Nombres, @Apellidos, @Edad, @DPI, @DPIExtendidoEn,
			@LugarNacimiento, @FechaNacimiento, @Direccion, @Nacionalidad,
			@NumIGSS, @TelefonoCasa, @TelefonoCelular,
			@Profesion, @PlazaAplica, @EstadoCivil, @TipoSangre,
			@ContactoEmergencia, @TelefonoEmergencia, @DependientesEconomicos,
			@NIT, @ExperienciasPoligraficas, @ResultadoPoligrafoPrevio,
			@PorcentajeIngles, @Correo, @UsuariosRedes,
			@ConyugeNombre, @ConyugeEdad, @ConyugeDPI, @ConyugeCel,
			@ConyugeEstadoCivil, @ConyugeOcupacion, @ConyugeTrabajo, @ConyugeTelTrabajo,
			GETDATE()
		);

		SELECT CAST(SCOPE_IDENTITY() AS INT) AS NuevoId;
END
GO

CREATE PROCEDURE sp_Candidato_Actualizar
    @Id INT,
    @Nombres NVARCHAR(100),
    @Apellidos NVARCHAR(100),
    @Edad INT,
    @DPI NVARCHAR(13),
    @DPIExtendidoEn NVARCHAR(15),
    @LugarNacimiento NVARCHAR(120),
    @FechaNacimiento DATETIME,
    @Direccion NVARCHAR(200),
    @Nacionalidad NVARCHAR(60),
    @NumIGSS NVARCHAR(20),
    @TelefonoCasa NVARCHAR(8),
    @TelefonoCelular NVARCHAR(8),
    @Profesion NVARCHAR(120),
    @PlazaAplica NVARCHAR(120),
    @EstadoCivil NVARCHAR(120),
    @TipoSangre NVARCHAR(8),
    @ContactoEmergencia NVARCHAR(8),
    @TelefonoEmergencia NVARCHAR(8),
    @DependientesEconomicos NVARCHAR(50),
    @NIT NVARCHAR(9),
    @ExperienciasPoligraficas NVARCHAR(100),
    @ResultadoPoligrafoPrevio NVARCHAR(60),
    @PorcentajeIngles TINYINT,
    @Correo NVARCHAR(255),
    @UsuariosRedes NVARCHAR(150),
    @ConyugeNombre NVARCHAR(120),
    @ConyugeEdad INT,
    @ConyugeDPI NVARCHAR(120),
    @ConyugeCel NVARCHAR(200),
    @ConyugeEstadoCivil NVARCHAR(40),
    @ConyugeOcupacion NVARCHAR(120),
    @ConyugeTrabajo NVARCHAR(200),
    @ConyugeTelTrabajo NVARCHAR(25)
AS
BEGIN
    UPDATE Candidato
    SET Nombres = @Nombres,
        Apellidos = @Apellidos,
        Edad = @Edad,
        DPI = @DPI,
        DPIExtendidoEn = @DPIExtendidoEn,
        LugarNacimiento = @LugarNacimiento,
        FechaNacimiento = @FechaNacimiento,
        Direccion = @Direccion,
        Nacionalidad = @Nacionalidad,
        NumIGSS = @NumIGSS,
        TelefonoCasa = @TelefonoCasa,
        TelefonoCelular = @TelefonoCelular,
        Profesion = @Profesion,
        PlazaAplica = @PlazaAplica,
        EstadoCivil = @EstadoCivil,
        TipoSangre = @TipoSangre,
        ContactoEmergencia = @ContactoEmergencia,
        TelefonoEmergencia = @TelefonoEmergencia,
        DependientesEconomicos = @DependientesEconomicos,
        NIT = @NIT,
        ExperienciasPoligraficas = @ExperienciasPoligraficas,
        ResultadoPoligrafoPrevio = @ResultadoPoligrafoPrevio,
        PorcentajeIngles = @PorcentajeIngles,
        Correo = @Correo,
        UsuariosRedes = @UsuariosRedes,
        ConyugeNombre = @ConyugeNombre,
        ConyugeEdad = @ConyugeEdad,
        ConyugeDPI = @ConyugeDPI,
        ConyugeCel = @ConyugeCel,
        ConyugeEstadoCivil = @ConyugeEstadoCivil,
        ConyugeOcupacion = @ConyugeOcupacion,
        ConyugeTrabajo = @ConyugeTrabajo,
        ConyugeTelTrabajo = @ConyugeTelTrabajo
    WHERE Id = @Id
END


--SP_PADRES
CREATE PROCEDURE sp_Padres
    @CandidatoId      INT,
    @NombrePadre      VARCHAR(100),
    @NombreMadre      VARCHAR(100),
    @EdadP            INT,
    @EdadM            INT,
    @NoResidenciaP    VARCHAR(40),
    @NoResidenciaM    VARCHAR(40),
    @DPIP             VARCHAR(13),
    @DPIM             VARCHAR(13),
    @EstadoCivilP     VARCHAR(40),
    @EstadoCivilM     VARCHAR(40),
    @CelularP         VARCHAR(10),
    @CelularM         VARCHAR(10),
    @ProfesionP       VARCHAR(100),
    @ProfesionM       VARCHAR(100),
    @NacionalidadP    VARCHAR(60),
    @NacionalidadM    VARCHAR(60),
    @LugarTrabajoP    VARCHAR(150),
    @LugarTrabajoM    VARCHAR(150)
AS
BEGIN
    SET NOCOUNT ON;

        INSERT INTO Padres (
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
        )
        VALUES (
            @CandidatoId,
            @NombrePadre, @NombreMadre,
            @EdadP, @EdadM,
            @NoResidenciaP, @NoResidenciaM,
            @DPIP, @DPIM,
            @EstadoCivilP, @EstadoCivilM,
            @CelularP, @CelularM,
            @ProfesionP, @ProfesionM,
            @NacionalidadP, @NacionalidadM,
            @LugarTrabajoP, @LugarTrabajoM
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT) AS IdPadre;
END
GO

--SP_HERMANO
CREATE PROCEDURE sp_Hermano
    @CandidatoId INT,
    @Nombre NVARCHAR(120),
    @Edad INT = NULL,
	@NoResidencia NVARCHAR(40) = NULL,
    @DPI NVARCHAR(25) = NULL,
    @EstadoCivil NVARCHAR(40) = NULL,
	@Celular NVARCHAR(10) = NULL,
    @Profesion NVARCHAR(120) = NULL,
    @Nacionalidad NVARCHAR(60) = NULL,
    @LugarTrabajo NVARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO Hermanos (
            CandidatoId, Nombre, Edad, NoResidencia, DPI,
            EstadoCivil, Celular, Profesion, Nacionalidad, LugarTrabajo
        )
        VALUES (
            @CandidatoId, @Nombre, @Edad, @NoResidencia, @DPI, 
            @EstadoCivil, @Celular, @Profesion, @Nacionalidad, @LugarTrabajo
        );
END
GO

--SP_HIJOS
CREATE PROCEDURE sp_Hijos
    @CandidatoId INT,
    @NombreHijo NVARCHAR(100),
    @EdadHijo INT = NULL,
	@EstadoCivilHijo VARCHAR(40) = NULL,
    @Direccion VARCHAR(200) = NULL,
    @Ocupacion VARCHAR(100) = NULL,
    @Nacionalidad VARCHAR(60) = NULL,
    @LugarTrabajo VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
        INSERT INTO Hijos (
            CandidatoId, NombreHijo, EdadHijo, EstadoCivilHijo,
			Direccion, Ocupacion, Nacionalidad, LugarTrabajo
        )
        VALUES (
            @CandidatoId, @NombreHijo, @EdadHijo, @EstadoCivilHijo,
			@Direccion, @Ocupacion, @Nacionalidad, @LugarTrabajo
        );
END
GO

--SP_ASPECTOSEMOCIONALES
CREATE PROCEDURE sp_AspectosEmocionales
    @CandidatoId INT,
    @VivenPadres BIT = 0,
    @RelacionEntrePadres VARCHAR(150),
    @ConQuienVive VARCHAR(150),
    @IntentosSuicidio VARCHAR(150),
    @CualidadRespeta VARCHAR(120),
    @DefectoIntolerable VARCHAR(120),
    @MejorExperiencia VARCHAR(200),
    @PeorExperiencia VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO AspectosEmocionales (
            CandidatoId, VivenPadres, RelacionEntrePadres, ConQuienVive,
            IntentosSuicidio, CualidadRespeta, DefectoIntolerable,
            MejorExperiencia, PeorExperiencia
        )
        VALUES (
            @CandidatoId, @VivenPadres, @RelacionEntrePadres, @ConQuienVive,
            @IntentosSuicidio, @CualidadRespeta, @DefectoIntolerable,
            @MejorExperiencia, @PeorExperiencia
        );
END
GO

--SP_INFOSOCIAL
CREATE PROCEDURE sp_InfoSocial
    @CandidatoId INT,
    @Religion VARCHAR(80) = NULL,
    @FrecuenciaCulto VARCHAR(80) = NULL,
    @Grupos VARCHAR(150) = NULL,
    @ActividadesTiempoLibre VARCHAR(150),
    @Autodescripcion VARCHAR(200),
    @Piercings VARCHAR(120) = NULL,
    @Tatuajes BIT = NULL,
    @TatuajesDescripcion VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO InfoSocial (
            CandidatoId, Religion, FrecuenciaCulto, Grupos, ActividadesTiempoLibre,
            Autodescripcion, Piercings, Tatuajes, TatuajesDescripcion
        )
        VALUES (
            @CandidatoId, @Religion, @FrecuenciaCulto, @Grupos, @ActividadesTiempoLibre,
            @Autodescripcion, @Piercings, @Tatuajes, @TatuajesDescripcion
        );
END
GO

--SP_ESTUDIO
CREATE PROCEDURE sp_Estudio
    @CandidatoId INT,
    @NombreInstitucion VARCHAR(100),
    @EstudiosRealizados VARCHAR(150),
    @Lugar VARCHAR(120),
    @FechaDesde DATE,
    @FechaHasta DATE,
    @UltimoGrado VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO Estudios (
            CandidatoId, NombreInstitucion, EstudiosRealizados,
            Lugar, FechaDesde, FechaHasta, UltimoGrado
        )
        VALUES (
            @CandidatoId, @NombreInstitucion, @EstudiosRealizados,
            @Lugar, @FechaDesde, @FechaHasta, @UltimoGrado
        );
END
GO

--SP_PROCESOCONTRATACION
CREATE PROCEDURE sp_ProcesoContratacion
    @CandidatoId INT,
    @OcultoIdentidad BIT = NULL,
    @OmisionDeliberada BIT = NULL,
    @DocumentoFalso BIT = NULL,
    @InfoFalsaCV BIT = NULL,
    @DocumentosEnOrden BIT = NULL,
    @Observaciones VARCHAR(200) = NULL
AS
BEGIN
        INSERT INTO ProcesoContratacion (
            CandidatoId, OcultoIdentidad, OmisionDeliberada,
            DocumentoFalso, InfoFalsaCV, DocumentosEnOrden, Observaciones
        )
        VALUES (
            @CandidatoId, @OcultoIdentidad, @OmisionDeliberada,
            @DocumentoFalso, @InfoFalsaCV, @DocumentosEnOrden, @Observaciones
        );
END
GO

--SP_HISTORIALLABORAL
CREATE PROCEDURE sp_HistorialLaboral
    @CandidatoId INT,
    @Empresa VARCHAR(200)= NULL,
    @Cargo VARCHAR(120) = NULL,
    @TelefonoEmpresa VARCHAR(10) = NULL,
    @FechaIngreso DATE = NULL,
    @FechaEgreso DATE = NULL,
    @UltimoSalario DECIMAL(10,2) = NULL,
    @CausaRetiro VARCHAR(200) = NULL,
    @JefeInmediato VARCHAR(100) = NULL,
    @TelefonoJefe VARCHAR(10) = NULL,
    @CargoJefe VARCHAR(100) = NULL,
    @Observaciones VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO HistorialLaboral (
            CandidatoId, Empresa, Cargo, TelefonoEmpresa,
            FechaIngreso, FechaEgreso, UltimoSalario, CausaRetiro,
            JefeInmediato, TelefonoJefe, CargoJefe, Observaciones
        )
        VALUES (
            @CandidatoId, @Empresa, @Cargo, @TelefonoEmpresa,
            @FechaIngreso, @FechaEgreso, @UltimoSalario, @CausaRetiro,
            @JefeInmediato, @TelefonoJefe, @CargoJefe, @Observaciones
        );
END
GO

--SP_LABORALPREGUNTAS
CREATE PROCEDURE sp_LaboralPreguntas
    @CandidatoId INT,
    @PedidoRenuncia BIT = 0,
    @AbandonoEmpleo BIT = 0,
    @AcusadoDeshonestidad BIT = 0,
    @VReglamentos BIT = 0,
    @BeneficiosIlicitos BIT = 0,
    @UsoIndebidoInfoConf BIT = 0,
    @DiscusionesConSuperiores BIT = 0,
    @ActaAdmOProceso BIT = 0,
    @Sobornos BIT = 0,
    @Sabotaje BIT = 0,
    @DemandaContra BIT = 0,
    @DemandaAAlguien BIT = 0,
    @Observaciones VARCHAR(200) = 0,
    @ProblemasLaborales VARCHAR(200) = 0,
    @FaltasAdmSerias VARCHAR(200) = 0,
    @OpinionSindicatos VARCHAR(200) = 0
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO LaboralPreguntas(
            CandidatoId, PedidoRenuncia, AbandonoEmpleo, AcusadoDeshonestidad,
            VReglamentos, BeneficiosIlicitos, UsoIndebidoInfoConf,
            DiscusionesConSuperiores, ActaAdmOProceso, Sobornos, Sabotaje,
            DemandaContra, DemandaAAlguien, Observaciones, ProblemasLaborales,
            FaltasAdmSerias, OpinionSindicatos
        )
        VALUES (
            @CandidatoId, @PedidoRenuncia, @AbandonoEmpleo, @AcusadoDeshonestidad,
            @VReglamentos, @BeneficiosIlicitos, @UsoIndebidoInfoConf,
            @DiscusionesConSuperiores, @ActaAdmOProceso, @Sobornos, @Sabotaje,
            @DemandaContra, @DemandaAAlguien, @Observaciones, @ProblemasLaborales,
            @FaltasAdmSerias, @OpinionSindicatos
        );
END
GO

--SP_HONESTIDADVALORES

CREATE PROCEDURE sp_HonestidadValores
    @CandidatoId INT,
    @HonestaIdentidad BIT = 0,
    @DocumentoFalsoEnPlaza BIT = 0,
    @ManejoValores BIT = 0,
    @Faltantes BIT = 0,
    @Sobrantes BIT = 0,
    @PrestamosConDineroACargo BIT = 0,
    @ManejoInfoConf BIT = 0,
    @UsoIndebidoInfoConf BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO HonestidadValores (
            CandidatoId, HonestaIdentidad, DocumentoFalsoEnPlaza, ManejoValores,
            Faltantes, Sobrantes, PrestamosConDineroACargo, ManejoInfoConf, UsoIndebidoInfoConf
        )
        VALUES (
            @CandidatoId, @HonestaIdentidad, @DocumentoFalsoEnPlaza, @ManejoValores,
            @Faltantes, @Sobrantes, @PrestamosConDineroACargo, @ManejoInfoConf, @UsoIndebidoInfoConf
        );
END
GO

--SP_CUENTABANCARIA
CREATE PROCEDURE sp_CuentasBancarias
    @CandidatoId INT,
    @Banco VARCHAR(80)= NULL,
    @TipoCuenta VARCHAR(40) = NULL,
    @Saldo DECIMAL(10,2) = NULL
AS
BEGIN
        INSERT INTO CuentasBancarias (CandidatoId, Banco, TipoCuenta, Saldo)
        VALUES (@CandidatoId, @Banco, @TipoCuenta, @Saldo);
END
GO

CREATE PROCEDURE sp_TarjetasCredito
    @CandidatoId INT,
    @Banco VARCHAR(80) = NULL,
    @LimiteCredito DECIMAL(10,2) = NULL,
    @SaldoActual DECIMAL(10,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO TarjetasCredito (CandidatoId, Banco, LimiteCredito, SaldoActual)
        VALUES (@CandidatoId, @Banco, @LimiteCredito, @SaldoActual);
END
GO

--SP_GASTOSMENSUALES
CREATE PROCEDURE sp_GastoMensual
    @CandidatoId INT,
    @ConceptoNombre VARCHAR(80),
    @EsIngreso BIT,
    @Monto DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
        DECLARE @ConceptoId INT;
        
        SELECT @ConceptoId = IdGC FROM CatGastoConcepto WHERE Nombre = @ConceptoNombre;
        
        INSERT INTO GastosMensuales (CandidatoId, ConceptoId, EsIngreso, Monto)
        VALUES (@CandidatoId, @ConceptoId, @EsIngreso, @Monto);
END
GO


--SP_DEUDAS
CREATE PROCEDURE sp_Deudas
    @CandidatoId INT,
    @Banco NVARCHAR(80) = NULL,
    @MontoMensual DECIMAL(10,2) = NULL,
    @Razon VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO Deudas (CandidatoId, Banco, MontoMensual, Razon)
        VALUES (@CandidatoId, @Banco, @MontoMensual, @Razon);
END
GO

--SP_VEHICULOS
CREATE PROCEDURE sp_Vehiculos
    @CandidatoId INT,
    @Marca NVARCHAR(60) = NULL,
    @Modelo NVARCHAR(40) = NULL,
    @Placas NVARCHAR(25) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO Vehiculos (CandidatoId, Marca, Modelo, Placas)
        VALUES (@CandidatoId, @Marca, @Modelo, @Placas);
END
GO

--SP_ACTIVIDADESDELICTIVAS
CREATE PROCEDURE sp_ActividadesDelictivas
    @CandidatoId INT,
    @AsociadoConDelincuentes BIT = 0,
    @ConoceDelincuentes BIT = 0,
    @DetenidoCuestionado BIT = 0,
    @EstuvoRecluso BIT = 0,
    @HizoAlgoDetenido BIT = 0,
    @FamiliarDetenido BIT = 0,
    @CargosPorFaltas BIT = 0,
    @PenalesPoliciacosLimpios BIT = 0,
    @AyudoCometerDelito BIT = 0,
    @CambioPrecios BIT = 0,
    @UsoIlegalTarjeta BIT = 0,
    @DocumentoFalsificado BIT = 0,
    @RoboArticulo BIT = 0,
    @CompraVentaAutosRobados BIT = 0,
    @ActoSIlegal BIT = 0,
    @AcosoS BIT = 0,
    @PG BIT = 0,
    @BeneficiosPros BIT = 0,
    @Secuestro BIT = 0,
    @OtraActividadIllicita BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO ActividadesDelictivas (
            CandidatoId, AsociadoConDelincuentes, ConoceDelincuentes, DetenidoCuestionado,
            EstuvoRecluso, HizoAlgoDetenido, FamiliarDetenido, CargosPorFaltas,
            PenalesPoliciacosLimpios, AyudoCometerDelito, CambioPrecios, UsoIlegalTarjeta,
            DocumentoFalsificado, RoboArticulo, CompraVentaAutosRobados, ActoSIlegal,
            AcosoS, PG, BeneficiosPros, Secuestro, OtraActividadIllicita
        )
        VALUES (
            @CandidatoId, @AsociadoConDelincuentes, @ConoceDelincuentes, @DetenidoCuestionado,
            @EstuvoRecluso, @HizoAlgoDetenido, @FamiliarDetenido, @CargosPorFaltas,
            @PenalesPoliciacosLimpios, @AyudoCometerDelito, @CambioPrecios, @UsoIlegalTarjeta,
            @DocumentoFalsificado, @RoboArticulo, @CompraVentaAutosRobados, @ActoSIlegal,
            @AcosoS, @PG, @BeneficiosPros, @Secuestro, @OtraActividadIllicita
        );

END
GO

--SP_HISTORIAMEDICA
CREATE PROCEDURE sp_HistoriaMedica
    @CandidatoId INT,
    @CondicionGeneral VARCHAR(80) = NULL,
    @MalestarActual VARCHAR(150) = NULL,
    @HoraUltimaComida VARCHAR(5),
    @HorasDormidasAyer VARCHAR(5),
    @Embarazo BIT = 0,
    @EnfermedadGrave VARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO HistoriaMedica (
            CandidatoId, CondicionGeneral, MalestarActual, HoraUltimaComida,
            HorasDormidasAyer, Embarazo, EnfermedadGrave
        )
        VALUES (
            @CandidatoId, @CondicionGeneral, @MalestarActual, @HoraUltimaComida,
            @HorasDormidasAyer, @Embarazo, @EnfermedadGrave
        );
END
GO

--SP_HISTORIAMEDICACOND
-- Primero elimina el procedimiento existente
DROP PROCEDURE IF EXISTS sp_HistoriaMedicaCond;
GO

-- Crea el nuevo procedimiento que acepta el nombre
CREATE PROCEDURE sp_HistoriaMedicaCond
    @CandidatoId INT,
    @CondicionNombre NVARCHAR(100),
    @Especificar NVARCHAR(200) = NULL,
    @Fecha DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO HistoriaMedicaCond (CandidatoId, CondicionNombre, Especificar, Fecha)
    VALUES (@CandidatoId, @CondicionNombre, @Especificar, @Fecha);
END
GO


--SP_MEDICAMENTOS
CREATE PROCEDURE sp_Medicamentos
    @CandidatoId INT,
    @IngestaAlcohol24h BIT = 0,
    @Droga30dias BIT = 0,
    @TratMedicoReciente BIT = 0,
    @ConsumeMedicamentos BIT = 0,
    @DopingPracticado BIT = 0,
    @DopingAlterado BIT = 0,
    @Cirugia BIT = 0,
    @AlergiaMedicamento BIT = 0,
    @UltimoChequeoMedico VARCHAR(40) = NULL,
    @AlergiaComida BIT = 0,
    @UltimoChequeoOdonto VARCHAR(40) = NULL,
    @UltimoChequeoOftalmo VARCHAR(40) = NULL,
    @UsaLentes BIT = 0,
    @Fuma BIT = 0,
    @Observaciones VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO UsoMedicamentos (
            CandidatoId, IngestaAlcohol24h, Droga30dias, TratMedicoReciente,
            ConsumeMedicamentos, DopingPracticado, DopingAlterado, Cirugia,
            AlergiaMedicamento, UltimoChequeoMedico, AlergiaComida,
            UltimoChequeoOdonto, UltimoChequeoOftalmo, UsaLentes, Fuma, Observaciones
        )
        VALUES (
            @CandidatoId, @IngestaAlcohol24h, @Droga30dias, @TratMedicoReciente,
            @ConsumeMedicamentos, @DopingPracticado, @DopingAlterado, @Cirugia,
            @AlergiaMedicamento, @UltimoChequeoMedico, @AlergiaComida,
            @UltimoChequeoOdonto, @UltimoChequeoOftalmo, @UsaLentes, @Fuma, @Observaciones
        );
END
GO

--SP_ANTECEDENTES
CREATE PROCEDURE sp_Antecedentes
    @CandidatoId INT,
    @CausoHeridasGraves BIT = 0,
    @MatoAlguien BIT = 0,
    @UltimaRina VARCHAR(120) = NULL,
    @UltimaPerdidaControl VARCHAR(150) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO AntecedentesGenerales (
            CandidatoId, CausoHeridasGraves, MatoAlguien, UltimaRina, UltimaPerdidaControl
        )
        VALUES (
            @CandidatoId, @CausoHeridasGraves, @MatoAlguien, @UltimaRina, @UltimaPerdidaControl
        );
END
GO

--SP_MANEJOARMAS
CREATE PROCEDURE sp_ManejoArmas
    @CandidatoId INT,
    @TieneArmasPropias BIT = 0,
    @HaPortadoArma BIT = 0,
    @EnfrentamientoConArma BIT = 0,
    @DisparoInnecesario BIT = 0,
    @UsoIndebidoArma BIT = 0,
    @CompraVentaIlegalArmas BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO ManejoArmas (
            CandidatoId, TieneArmasPropias, HaPortadoArma, EnfrentamientoConArma,
            DisparoInnecesario, UsoIndebidoArma, CompraVentaIlegalArmas
        )
        VALUES (
            @CandidatoId, @TieneArmasPropias, @HaPortadoArma, @EnfrentamientoConArma,
            @DisparoInnecesario, @UsoIndebidoArma, @CompraVentaIlegalArmas
        );

END
GO

--SP_HABITOSALCOHOL
CREATE PROCEDURE sp_HabitosAlcohol
    @CandidatoId INT,
    @UltimaVezBebio VARCHAR(40),
    @PromedioMensual VARCHAR(40) = NULL,
    @ExcesosPorAnio INT = NULL,
    @ComoEsCuandoExcede VARCHAR(150) = NULL,
    @UltimaAmnesia VARCHAR(40) = NULL,
    @UltimaConduccionEbrio VARCHAR(40) = NULL,
    @PeorEvento VARCHAR(150) = NULL,
    @PeleaAlBeber BIT = 0,
    @DetenidoAlBeber BIT = 0,
    @TratamientoControlBeber BIT = 0,
    @LaboroEbrioResaca BIT = 0,
    @FaltoPorBeber BIT = 0,
    @BebioEnHorasTrabajo BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO HabitosAlcohol (
            CandidatoId, UltimaVezBebio, PromedioMensual, ExcesosPorAnio,
            ComoEsCuandoExcede, UltimaAmnesia, UltimaConduccionEbrio, PeorEvento,
            PeleaAlBeber, DetenidoAlBeber, TratamientoControlBeber,
            LaboroEbrioResaca, FaltoPorBeber, BebioEnHorasTrabajo
        )
        VALUES (
            @CandidatoId, @UltimaVezBebio, @PromedioMensual, @ExcesosPorAnio,
            @ComoEsCuandoExcede, @UltimaAmnesia, @UltimaConduccionEbrio, @PeorEvento,
            @PeleaAlBeber, @DetenidoAlBeber, @TratamientoControlBeber,
            @LaboroEbrioResaca, @FaltoPorBeber, @BebioEnHorasTrabajo
        );

END
GO

--SP_DROGAS
CREATE PROCEDURE sp_Drogas
    @CandidatoId INT,
    @UltimaVezConsumo VARCHAR(40) = NULL,
    @ProboDrogas BIT = 0,
    @CualquierContacto BIT = 0,
    @GuardoDrogaAjena BIT = 0,
    @ContactoConVendedores BIT = 0,
    @FamiliarConsume BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO Drogas (
            CandidatoId, UltimaVezConsumo, ProboDrogas, CualquierContacto,
            GuardoDrogaAjena, ContactoConVendedores, FamiliarConsume
        )
        VALUES (
            @CandidatoId, @UltimaVezConsumo, @ProboDrogas, @CualquierContacto,
            @GuardoDrogaAjena, @ContactoConVendedores, @FamiliarConsume
        );
END
GO

--SP_CONCLUSIONES
CREATE PROCEDURE sp_Conclusiones
    @CandidatoId INT,
    @ExperienciaChantajeable BIT = NULL,
    @PensabaPreguntasFaltantes BIT = NULL,
    @FalseoOmisiones BIT = NULL,
    @AlgoQuePreocupe BIT = NULL,
    @AlgoQueDecir BIT = NULL,
	@ObjetivosCP VARCHAR(100),
	@ObjetivosMP VARCHAR(100),
	@ObjetivosLP VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO Conclusiones (
            CandidatoId, ExperienciaChantajeable, PensabaPreguntasFaltantes,
            FalseoOmisiones, AlgoQuePreocupe, AlgoQueDecir, ObjetivosCP, ObjetivosMP, ObjetivosLP
        )
        VALUES (
            @CandidatoId, @ExperienciaChantajeable, @PensabaPreguntasFaltantes,
            @FalseoOmisiones, @AlgoQuePreocupe, @AlgoQueDecir, @ObjetivosCP, @ObjetivosMP, @ObjetivosLP
        ); 
END
GO

--SP_SOCIOECONOMICOS
CREATE PROCEDURE sp_Socioeconomico
    @CandidatoId           INT,
    @PersonasDependen      INT,
    @TieneIngresoExtra     BIT = 0,
    @DetalleIngresoExtra   VARCHAR(200),
    @IngresosHogarAprox    DECIMAL(10,2),
    @TipoVivienda          VARCHAR(12),
    @TenenciaVivienda      VARCHAR(12),
    @AdquisicionVivienda   VARCHAR(200),
    @MontoAlquiler         DECIMAL(10,2),
    @QuienesPaganAlquiler  VARCHAR(200),
    @TiempoVivirAhi        VARCHAR(60),
    @DomicilioAnterior     VARCHAR(200),
    @MotivoCambioDomicilio VARCHAR(200),
    @ColorExterior         VARCHAR(100) = NULL,
    @ColorInterior         VARCHAR(100) = NULL,
    @TipoParedes           VARCHAR(100) = NULL,
    @TipoTecho             VARCHAR(100) = NULL,
    @Niveles               INT = NULL,
    @ConstruccionDe        VARCHAR(150) = NULL,
    @NumeroAmbientes       INT = NULL,
    @AmbientesDetalle      VARCHAR(200)  = NULL,
    @MtsFrente             DECIMAL(10,2) = NULL,
    @MtsFondo              DECIMAL(10,2) = NULL,
    @CallesTipo            VARCHAR(20) = NULL,
    @CallesTipoOtro        VARCHAR(100) = NULL,
    @EquipadoCon           VARCHAR(300) = NULL,
    @ComercioEnVivienda    VARCHAR(200) = NULL
AS
BEGIN
    SET NOCOUNT ON;
        INSERT INTO Socioeconomico (
            CandidatoId, PersonasDependen, TieneIngresoExtra, DetalleIngresoExtra,
            IngresosHogarAprox, TipoVivienda, TenenciaVivienda, AdquisicionVivienda,
            MontoAlquiler, QuienesPaganAlquiler, TiempoVivirAhi, DomicilioAnterior,
            MotivoCambioDomicilio, ColorExterior, ColorInterior, TipoParedes,
            TipoTecho, Niveles, ConstruccionDe, NumeroAmbientes, AmbientesDetalle,
            MtsFrente, MtsFondo, CallesTipo, CallesTipoOtro, EquipadoCon, ComercioEnVivienda
        )
        VALUES (
            @CandidatoId, @PersonasDependen, @TieneIngresoExtra, @DetalleIngresoExtra,
            @IngresosHogarAprox, @TipoVivienda, @TenenciaVivienda, @AdquisicionVivienda,
            @MontoAlquiler, @QuienesPaganAlquiler, @TiempoVivirAhi, @DomicilioAnterior,
            @MotivoCambioDomicilio, @ColorExterior, @ColorInterior, @TipoParedes,
            @TipoTecho, @Niveles, @ConstruccionDe, @NumeroAmbientes, @AmbientesDetalle,
            @MtsFrente, @MtsFondo, @CallesTipo, @CallesTipoOtro, @EquipadoCon, @ComercioEnVivienda
        );
END
GO
--SP_SOCIOECONOMICOHABITANTES
CREATE PROCEDURE sp_SocioeconomicoHabitantes
    @CandidatoId INT,
    @Nombre VARCHAR(120) = NULL,
    @Parentesco VARCHAR(60) = NULL,
    @Edad INT = NULL,
    @AportaAGastos BIT = NULL,
    @CantidadAporte DECIMAL(10,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO SocioeconomicoHabitantes
        (CandidatoId, Nombre, Parentesco, Edad, AportaAGastos, CantidadAporte)
    VALUES
        (@CandidatoId, @Nombre, @Parentesco, @Edad, @AportaAGastos, @CantidadAporte);

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
END
GO

