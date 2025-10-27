CREATE DATABASE BD_ConsultoresSI
USE BD_ConsultoresSI

CREATE TABLE Usuarios (
  IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
  Email VARCHAR(255) NOT NULL UNIQUE,
  HashPassword VARCHAR(MAX) NOT NULL,
  Nombre NVARCHAR(100) NOT NULL,
  FechaCreacion DATETIME NOT NULL DEFAULT SYSDATETIME()
);
INSERT INTO Usuarios (Email, HashPassword, Nombre)
VALUES
('admin@evalysi.com', N'123456', N'Admin');
GO
-- ROLES y PERMISOS
CREATE TABLE Roles (
  IdRol INT IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(80) NOT NULL,
  Descripcion NVARCHAR(200) NULL,
  Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE Permisos (
  IdPermiso INT IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(80) NOT NULL UNIQUE,
  Descripcion NVARCHAR(200) NULL,
  Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE RolPermiso (
  RolId INT NOT NULL REFERENCES Roles(IdRol),
  PermisoId INT NOT NULL REFERENCES Permisos(IdPermiso),
  PRIMARY KEY (RolId, PermisoId)
);

-- Usuarios ya existe; agregamos vínculo a roles (N–N)
CREATE TABLE UsuarioRol (
  UsuarioId INT NOT NULL REFERENCES Usuarios(IdUsuario),
  RolId INT NOT NULL REFERENCES Roles(IdRol),
  PRIMARY KEY (UsuarioId, RolId)
);

CREATE TABLE Candidatos (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  FechaRegistro DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),

  -- DATOS GENERALES
  Nombres VARCHAR(100) NOT NULL,
  Apellidos VARCHAR(100) NOT NULL,
  Edad INT NOT NULL,
  DPI VARCHAR(13) UNIQUE NOT NULL,
  DPIExtendidoEn VARCHAR(15) NOT NULL,
  LugarNacimiento VARCHAR(120),
  FechaNacimiento DATE NOT NULL,
  Direccion VARCHAR(200) NOT NULL,
  Nacionalidad VARCHAR(60) NOT NULL,
  NumIGSS VARCHAR(20),
  TelefonoCasa VARCHAR(10),
  TelefonoCelular VARCHAR(10) NOT NULL,
  Profesion VARCHAR(100) NOT NULL,
  PlazaAplica VARCHAR(100) NOT NULL,
  EstadoCivil VARCHAR(40) NOT NULL,
  TipoSangre VARCHAR(10) NOT NULL,
  ContactoEmergencia VARCHAR(100) NOT NULL,
  TelefonoEmergencia VARCHAR(10) NOT NULL,
  DependientesEconomicos VARCHAR (50),
  NIT VARCHAR(20),
  ExperienciasPoligraficas VARCHAR(100),
  ResultadoPoligrafoPrevio VARCHAR(60),
  PorcentajeIngles TINYINT NOT NULL,
  Correo VARCHAR(255) NOT NULL,
  UsuariosRedes VARCHAR(150),
  ConyugeNombre VARCHAR(120),
  ConyugeEdad INT,
  ConyugeDPI VARCHAR(13),
  ConyugeCel VARCHAR(10),
  ConyugeEstadoCivil VARCHAR(40),
  ConyugeOcupacion VARCHAR(120),
  ConyugeTrabajo VARCHAR(200),
  ConyugeTelTrabajo VARCHAR(25),

);

CREATE TABLE Hijos (
  IdHijos INT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  NombreHijo VARCHAR(100),
  EdadHijo INT,
  EstadoCivilHijo VARCHAR(40),
  Direccion VARCHAR(200),
  Ocupacion VARCHAR(100),
  Nacionalidad VARCHAR(60),
  LugarTrabajo VARCHAR(200)
);
CREATE INDEX IX_Hijos_Candidato ON Hijos(CandidatoId);

CREATE TABLE Padres (
  IdPadre INT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  NombrePadre VARCHAR(100)NOT NULL,
  NombreMadre VARCHAR(100) NOT NULL,
  EdadP INT NOT NULL,
  EdadM INT NOT NULL,
  NoResidenciaP VARCHAR(40) NOT NULL,
  NoResidenciaM VARCHAR(40) NOT NULL,
  DPIP VARCHAR(13)NOT NULL,
  DPIM VARCHAR(13)NOT NULL,
  EstadoCivilP VARCHAR(40) NOT NULL,
  EstadoCivilM VARCHAR(40)NOT NULL,
  CelularP VARCHAR(10) NOT NULL,
  CelularM VARCHAR(10) NOT NULL,
  ProfesionP VARCHAR(100) NOT NULL,
  ProfesionM VARCHAR(100) NOT NULL,
  NacionalidadP VARCHAR(60) NOT NULL,
  NacionalidadM VARCHAR(60) NOT NULL,
  LugarTrabajoP VARCHAR(150)NOT NULL,
  LugarTrabajoM VARCHAR(150) NOT NULL
);

CREATE INDEX IX_Padres_Candidato ON Padres(CandidatoId);

CREATE TABLE Hermanos (
  IdHermano INT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id) ,
  Nombre NVARCHAR(120),
  Edad INT,
  NoResidencia NVARCHAR(40),
  DPI NVARCHAR(13),
  EstadoCivil NVARCHAR(40),
  Celular NVARCHAR(10),
  Profesion NVARCHAR(100),
  Nacionalidad NVARCHAR(60),
  LugarTrabajo NVARCHAR(150)
);
CREATE INDEX IX_Hermanos_Candidato ON Hermanos(CandidatoId);


--3) ASPECTOS EMOCIONALES 

CREATE TABLE AspectosEmocionales (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  VivenPadres BIT NOT NULL ,
  RelacionEntrePadres VARCHAR(150) NOT NULL ,
  ConQuienVive VARCHAR(150) NOT NULL ,
  IntentosSuicidio VARCHAR(150) NOT NULL ,
  CualidadRespeta VARCHAR(120) NOT NULL ,
  DefectoIntolerable VARCHAR(120)NOT NULL ,
  MejorExperiencia VARCHAR(200)NOT NULL ,
  PeorExperiencia VARCHAR(200)NOT NULL 
);

CREATE TABLE InfoSocial (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  Religion VARCHAR(80),
  FrecuenciaCulto VARCHAR(80),
  Grupos VARCHAR(150),
  ActividadesTiempoLibre VARCHAR(150) NOT NULL ,
  Autodescripcion VARCHAR(200)NOT NULL ,
  Piercings VARCHAR(120),
  Tatuajes BIT,
  TatuajesDescripcion VARCHAR(100)
);

-- 4) ESTUDIOS 

CREATE TABLE Estudios (
  IdEstudio INT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  NombreInstitucion VARCHAR(100) NOT NULL,
  EstudiosRealizados VARCHAR(150) NOT NULL,
  Lugar VARCHAR(120) NOT NULL ,
  FechaDesde DATE NOT NULL ,
  FechaHasta DATE NOT NULL ,
  UltimoGrado VARCHAR(100) NOT NULL 
);
CREATE INDEX IX_Estudios_Candidato ON Estudios(CandidatoId);


--5) PROCESO CONTRATACIÓN 

CREATE TABLE ProcesoContratacion (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  OcultoIdentidad BIT,
  OmisionDeliberada BIT,
  DocumentoFalso BIT,
  InfoFalsaCV BIT,
  DocumentosEnOrden BIT,
  Observaciones VARCHAR(200)
);

--6) HISTORIAL LABORAL 

CREATE TABLE HistorialLaboral (
  Id BIGINT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  Empresa VARCHAR(200),
  Cargo VARCHAR(120),
  TelefonoEmpresa VARCHAR(10),
  FechaIngreso DATE, 
  FechaEgreso DATE,
  UltimoSalario DECIMAL(10,2),
  CausaRetiro VARCHAR(200),
  JefeInmediato VARCHAR(100),
  TelefonoJefe VARCHAR(10),
  CargoJefe VARCHAR(100),
  Observaciones VARCHAR(200)
);
CREATE INDEX IX_HistLab_Candidato ON HistorialLaboral(CandidatoId);

CREATE TABLE LaboralPreguntas (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  PedidoRenuncia BIT,
  AbandonoEmpleo BIT,
  AcusadoDeshonestidad BIT,
  VReglamentos BIT,
  BeneficiosIlicitos BIT,
  UsoIndebidoInfoConf BIT,
  DiscusionesConSuperiores BIT,
  ActaAdmOProceso BIT,
  Sobornos BIT,
  Sabotaje BIT,
  DemandaContra BIT,
  DemandaAAlguien BIT,
  Observaciones VARCHAR(200),
  ProblemasLaborales VARCHAR(200),
  FaltasAdmSerias VARCHAR(200),
  OpinionSindicatos VARCHAR(200)
);

--7) HONESTIDAD/VALORES 

CREATE TABLE HonestidadValores (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  HonestaIdentidad BIT,
  DocumentoFalsoEnPlaza BIT,
  ManejoValores BIT,
  Faltantes BIT,
  Sobrantes BIT,
  PrestamosConDineroACargo BIT,
  ManejoInfoConf BIT,
  UsoIndebidoInfoConf BIT
);

--8) ECONOMÍA

CREATE TABLE CuentasBancarias (
  IdCuenta BIGINT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  Banco VARCHAR(80),
  TipoCuenta VARCHAR(40),
  Saldo DECIMAL(10,2) 
);
CREATE INDEX IX_Ctas_Candidato ON CuentasBancarias(CandidatoId);

CREATE TABLE TarjetasCredito (
  IdTarjeta INT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  Banco VARCHAR(80),
  LimiteCredito DECIMAL(10,2),
  SaldoActual DECIMAL(10,2)
);
CREATE INDEX IX_Tdc_Candidato ON TarjetasCredito(CandidatoId);

--CREATE TABLE CatGastoConcepto (
--    IdGC INT IDENTITY(1,1) PRIMARY KEY,
--    Nombre VARCHAR(80) NOT NULL
--);

--INSERT INTO CatGastoConcepto (Nombre) VALUES 
--('Salario/Prestación Salarial'),
--('Pago de vivienda'),
--('Agua, luz, teléfono'),
--('Celular'),
--('Gastos médicos'),
--('Estudios propios o de alguien más'),
--('Alimentación'),
--('Vestimenta'),
--('Transporte'),
--('Otros Gastos'),
--('Otros Ingresos');

CREATE TABLE GastosMensuales (
    IdGM INT IDENTITY(1,1) PRIMARY KEY,
    CandidatoId INT NOT NULL,
    ConceptoNombre VARCHAR(100),
    EsIngreso BIT NOT NULL DEFAULT 0, 
    Monto DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_GastosMensuales_Candidato FOREIGN KEY (CandidatoId) REFERENCES Candidatos(Id)
);

CREATE INDEX IX_GastosMensuales_CandidatoId ON GastosMensuales(CandidatoId);


CREATE TABLE Deudas (
  IdDeudas INT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  Banco VARCHAR(80),
  MontoMensual DECIMAL(10,2),
  Razon VARCHAR(200)
);
CREATE INDEX IX_Deudas ON Deudas(CandidatoId);

CREATE TABLE Vehiculos (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  Marca VARCHAR(60),
  Modelo VARCHAR(40),
  Placas VARCHAR(25)
);
CREATE INDEX IX_Vehiculos_Candidato ON Vehiculos(CandidatoId);

--9) ACTIVIDADES DELICTIVAS 

CREATE TABLE ActividadesDelictivas (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  AsociadoConDelincuentes BIT,
  ConoceDelincuentes BIT,
  DetenidoCuestionado BIT,
  EstuvoRecluso BIT,
  HizoAlgoDetenido BIT,
  FamiliarDetenido BIT,
  CargosPorFaltas BIT,
  PenalesPoliciacosLimpios BIT,
  AyudoCometerDelito BIT,
  CambioPrecios BIT,
  UsoIlegalTarjeta BIT,
  DocumentoFalsificado BIT,
  RoboArticulo BIT,
  CompraVentaAutosRobados BIT,
  ActoSIlegal BIT,
  AcosoS BIT,
  PG BIT,
  BeneficiosPros BIT,
  Secuestro BIT,
  OtraActividadIllicita BIT
);

--10) HISTORIA MÉDICA 

CREATE TABLE HistoriaMedica (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  CondicionGeneral VARCHAR(80),
  MalestarActual VARCHAR(150),
  HoraUltimaComida VARCHAR(5) NOT NULL,
  HorasDormidasAyer VARCHAR(5) NOT NULL,
  Embarazo BIT,
  EnfermedadGrave VARCHAR(100)
);

CREATE TABLE CatCondicionMedica (
  IdCM INT IDENTITY(1,1) PRIMARY KEY,
  Nombre NVARCHAR(60) UNIQUE
);

INSERT INTO CatCondicionMedica (Nombre)
VALUES ('Respiratorios'),('Corazon'),('Presion'),('Diabetes'),
       ('Desmayos'),('Convulsiones'),('Alergias'),('Digestion'),
       ('HeridasCabeza'),('Covid19');

CREATE TABLE HistoriaMedicaCond (
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  CondicionNombre NVARCHAR(60),
  Especificar VARCHAR(200),
  Fecha DATE,
  PRIMARY KEY (CandidatoId, CondicionNombre)
);
-- Eliminar la foreign key para permitir texto libre
ALTER TABLE HistoriaMedicaCond
DROP CONSTRAINT FK__HistoriaM__Condi__43D61337;

CREATE TABLE UsoMedicamentos (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  IngestaAlcohol24h BIT,
  Droga30dias BIT,
  TratMedicoReciente BIT,
  ConsumeMedicamentos BIT,
  DopingPracticado BIT,
  DopingAlterado BIT,
  Cirugia BIT,
  AlergiaMedicamento BIT,
  UltimoChequeoMedico VARCHAR(40),
  AlergiaComida BIT,
  UltimoChequeoOdonto VARCHAR(40),
  UltimoChequeoOftalmo VARCHAR(40),
  UsaLentes BIT,
  Fuma BIT,
  Observaciones VARCHAR(200)
);

--11) ANTECEDENTES / ARMAS / HÁBITOS / DROGAS / CONCLUSIONES 

CREATE TABLE AntecedentesGenerales (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  CausoHeridasGraves BIT,
  MatoAlguien BIT,
  UltimaRina VARCHAR(120),
  UltimaPerdidaControl VARCHAR(150)
);

CREATE TABLE ManejoArmas (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  TieneArmasPropias BIT,
  HaPortadoArma BIT,
  EnfrentamientoConArma BIT,
  DisparoInnecesario BIT,
  UsoIndebidoArma BIT,
  CompraVentaIlegalArmas BIT
);

CREATE TABLE HabitosAlcohol (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  UltimaVezBebio VARCHAR(40) NOT NULL,
  PromedioMensual VARCHAR(40),
  ExcesosPorAnio INT,
  ComoEsCuandoExcede VARCHAR(200),
  UltimaAmnesia VARCHAR(40),
  UltimaConduccionEbrio VARCHAR(40),
  PeorEvento VARCHAR(200),
  PeleaAlBeber BIT,
  DetenidoAlBeber BIT,
  TratamientoControlBeber BIT,
  LaboroEbrioResaca BIT,
  FaltoPorBeber BIT,
  BebioEnHorasTrabajo BIT
);

CREATE TABLE Drogas (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  UltimaVezConsumo VARCHAR(40),
  ProboDrogas BIT,
  CualquierContacto BIT,
  GuardoDrogaAjena BIT,
  ContactoConVendedores BIT,
  FamiliarConsume BIT
);

-- DROP TABLE Conclusiones;
CREATE TABLE Conclusiones (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  ExperienciaChantajeable BIT,
  PensabaPreguntasFaltantes BIT,
  FalseoOmisiones BIT,
  AlgoQuePreocupe BIT,
  AlgoQueDecir BIT,
  ObjetivosCP VARCHAR(100) NOT NULL,
  ObjetivosMP VARCHAR(100) NOT NULL,
  ObjetivosLP VARCHAR(100) NOT NULL
);


--ESTUDIOS SOCIOECONÓMICOS
--12) REFERENCIAS (FAMILIAR / PERSONAL / VECINO) 

CREATE TABLE Referencias (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId INT NOT NULL REFERENCES Candidatos(Id),
  TipoReferencia VARCHAR(15) NOT NULL
    CHECK (TipoReferencia IN ('FAMILIAR','PERSONAL','VECINO')),
  Nombre VARCHAR(120) NOT NULL,
  Telefono VARCHAR(25) NOT NULL,
  Parentesco VARCHAR(60) NULL,       -- para FAMILIAR
  TiempoConocer VARCHAR(40) NULL,    -- para PERSONAL/VECINO
  Notas VARCHAR(200) NULL
);
CREATE INDEX IX_Referencias_Candidato_Tipo
  ON Referencias(CandidatoId, TipoReferencia);


--13) SOCIOECONÓMICO / VISITA DOMICILIAR 

CREATE TABLE Socioeconomico (
  CandidatoId INT PRIMARY KEY REFERENCES Candidatos(Id),
  PersonasDependen INT,              
  TieneIngresoExtra BIT DEFAULT 0,
  DetalleIngresoExtra VARCHAR(200),
  IngresosHogarAprox DECIMAL(10,2),
  TipoVivienda VARCHAR(12) CHECK (TipoVivienda IN ('CASA','APARTAMENTO','CUARTO')),
  TenenciaVivienda VARCHAR(12) CHECK (TenenciaVivienda IN ('PROPIA','ALQUILADA','HERENCIA','FAMILIAR','INVASION')),
  AdquisicionVivienda VARCHAR(200), 
  MontoAlquiler DECIMAL(10,2) ,      
  QuienesPaganAlquiler VARCHAR(200) ,
  TiempoVivirAhi VARCHAR(60) ,
  DomicilioAnterior VARCHAR(200) ,
  MotivoCambioDomicilio VARCHAR(200),
  ColorExterior        VARCHAR(100) NULL,
  ColorInterior        VARCHAR(100) NULL,
  TipoParedes          VARCHAR(100) NULL,
  TipoTecho            VARCHAR(100) NULL,
  Niveles              INT NULL,
  ConstruccionDe       VARCHAR(150) NULL,
  NumeroAmbientes      INT NULL,
  AmbientesDetalle     VARCHAR(200) NULL,    
  MtsFrente            DECIMAL(10,2) NULL,
  MtsFondo             DECIMAL(10,2) NULL,
  CallesTipo           VARCHAR(20) NULL, 
  CallesTipoOtro       VARCHAR(100) NULL,  
  EquipadoCon          VARCHAR(300) NULL,  
  ComercioEnVivienda   VARCHAR(200) NULL
);

-- 2) Quiénes viven en la vivienda
CREATE TABLE SocioeconomicoHabitantes (
  Id                INT IDENTITY(1,1) PRIMARY KEY,
  CandidatoId       INT NOT NULL REFERENCES dbo.Candidatos(Id),
  Nombre            VARCHAR(120) NULL,
  Parentesco        VARCHAR(60) NULL,
  Edad              INT NULL,
  AportaAGastos     BIT NULL,
  CantidadAporte    DECIMAL(10,2) NULL
);
CREATE INDEX IX_SocioHabitantes_Candidato ON dbo.SocioeconomicoHabitantes(CandidatoId);

--14) BITÁCORA 

CREATE TABLE Bitacora (
  Id BIGINT IDENTITY(1,1) PRIMARY KEY,
  UsuarioId INT NOT NULL REFERENCES Usuarios(IdUsuario),
  Accion VARCHAR(40) NOT NULL,       -- 'CREAR','EDITAR','ELIMINAR','LOGIN'
  Detalle NVARCHAR(MAX) NULL,
  Fecha DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

