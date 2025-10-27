using EvalySI_App.Models.Formulario;
using EvalySI_App.Models.DatosGenerales;
using Microsoft.Data.SqlClient;
using EvalySI_App.Models;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using EvalySI_App.Models.Economia;
using EvalySI_App.Models.Informacion;
using EvalySI_App.Models.Salud;
using EvalySI_App.Models.Legal;

namespace EvalySI_App.Data
{
    public class daoAdmin
    {
        private readonly string _connectionString;

        public daoAdmin(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CandidatoViewModel>> ListarCandidatosResumenAsync()
        {
            var candidatos = new List<CandidatoViewModel>();
            await using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            await using var cmd = new SqlCommand("sp_Candidato_Resumen", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                candidatos.Add(new CandidatoViewModel
                {
                    Id = GetValueOrDefault<int>(reader, "Id"),
                    Nombres = GetValueOrDefault<string>(reader, "Nombres"),
                    Apellidos = GetValueOrDefault<string>(reader, "Apellidos"),
                    FechaRegistro = GetValueOrDefault<DateTime>(reader, "FechaRegistro"),
                    DPI = GetValueOrDefault<string>(reader, "DPI"),
                    TelefonoCelular = GetValueOrDefault<string>(reader, "TelefonoCelular")
                });
            }

            return candidatos;
        }



        // Método para obtener el detalle completo de un candidato
        public async Task<FormularioPoligrafoViewModel> ObtenerDetalleCandidatoAsync(int candidatoId)
        {
            var formularioViewModel = new FormularioPoligrafoViewModel
            {
                Candidato = await GetCandidatoByIdAsync(candidatoId),
                Padres = await GetPadresByCandidatoIdAsync(candidatoId),
                Hermanos = await GetHermanosByCandidatoIdAsync(candidatoId),
                Hijos = await GetHijosByCandidatoIdAsync(candidatoId),
                Deudas = await GetDeudaByCandidatoIdAsync(candidatoId),
                GastosMensuales = await GetGastosByCandidatoIdAsync(candidatoId),
                TarjetasCredito = await GetTarjetaCreditoByCandidatoIdAsync(candidatoId),
                Estudios = await GetEstudioByCandidatoIdAsync(candidatoId),
                HistorialLaboral = await GetHistorialLaboralByCandidatoIdAsync(candidatoId),
                AspectosEmocionales = await GetAspectosEByCandidatoIdAsync(candidatoId),
                HistoriaMedica = await GetHistoriaMedicaByCandidatoIdAsync(candidatoId),
                UsoMedicamentos = await GetMedicamentosByCandidatoIdAsync(candidatoId),
                HabitosAlcohol = await GetHabitosAlcoholByCandidatoIdAsync(candidatoId),
                Drogas = await GetDrogasByCandidatoIdAsync(candidatoId),
                AntecedentesGenerales = await GetAntecedentesByCandidatoIdAsync(candidatoId),
                ManejoArmas = await GetManejoArmasByCandidatoIdAsync(candidatoId),
                Conclusiones = await GetConclusionesByCandidatoIdAsync(candidatoId)
            };

            return formularioViewModel;
        }


        //MÉTODOS PARA OBTENER LA INFORMACIÓN COMPLETA DE LOS CANDIDATOS
        private async Task<CandidatoViewModel> GetCandidatoByIdAsync(int candidatoId)
        {
            CandidatoViewModel candidato = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Candidato_PorId", conn)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            candidato = new CandidatoViewModel
                            {
                                Id = GetValueOrDefault<int>(reader, "Id"),
                                FechaRegistro = GetValueOrDefault<DateTime>(reader, "FechaRegistro"),
                                Nombres = GetValueOrDefault<string>(reader, "Nombres"),
                                Apellidos = GetValueOrDefault<string>(reader, "Apellidos"),
                                Edad = GetValueOrDefault<int?>(reader, "Edad"),
                                DPI = GetValueOrDefault<string>(reader, "DPI"),
                                DPIExtendidoEn = GetValueOrDefault<string>(reader, "DPIExtendidoEn"),
                                LugarNacimiento = GetValueOrDefault<string>(reader, "LugarNacimiento"),
                                FechaNacimiento = GetValueOrDefault<DateTime?>(reader, "FechaNacimiento"),
                                Direccion = GetValueOrDefault<string>(reader, "Direccion"),
                                Nacionalidad = GetValueOrDefault<string>(reader, "Nacionalidad"),
                                NumIGSS = GetValueOrDefault<string>(reader, "NumIGSS"),
                                TelefonoCasa = GetValueOrDefault<string>(reader, "TelefonoCasa"),
                                TelefonoCelular = GetValueOrDefault<string>(reader, "TelefonoCelular"),
                                Profesion = GetValueOrDefault<string>(reader, "Profesion"),
                                PlazaAplica = GetValueOrDefault<string>(reader, "PlazaAplica"),
                                EstadoCivil = GetValueOrDefault<string>(reader, "EstadoCivil"),
                                TipoSangre = GetValueOrDefault<string>(reader, "TipoSangre"),
                                ContactoEmergencia = GetValueOrDefault<string>(reader, "ContactoEmergencia"),
                                TelefonoEmergencia = GetValueOrDefault<string>(reader, "TelefonoEmergencia"),
                                DependientesEconomicos = GetValueOrDefault<string>(reader, "DependientesEconomicos"),
                                Nit = GetValueOrDefault<string>(reader, "NIT"),
                                ExperienciasPoligraficas = GetValueOrDefault<string>(reader, "ExperienciasPoligraficas"),
                                ResultadoPoligrafoPrevio = GetValueOrDefault<string>(reader, "ResultadoPoligrafoPrevio"),
                                PorcentajeIngles = GetValueOrDefault<byte>(reader, "PorcentajeIngles"),
                                Correo = GetValueOrDefault<string>(reader, "Correo"),
                                UsuariosRedes = GetValueOrDefault<string>(reader, "UsuariosRedes"),
                                ConyugeNombre = GetValueOrDefault<string>(reader, "ConyugeNombre"),
                                ConyugeEdad = GetValueOrDefault<int>(reader, "ConyugeEdad"),
                                ConyugeDPI = GetValueOrDefault<string>(reader, "ConyugeDPI"),
                                ConyugeCel = GetValueOrDefault<string>(reader, "ConyugeCel"),
                                ConyugeEstadoCivil = GetValueOrDefault<string>(reader, "ConyugeEstadoCivil"),
                                ConyugeOcupacion = GetValueOrDefault<string>(reader, "ConyugeOcupacion"),
                                ConyugeTrabajo = GetValueOrDefault<string>(reader, "ConyugeTrabajo"),
                                ConyugeTelTrabajo = GetValueOrDefault<string>(reader, "ConyugeTelTrabajo")
                            };
                        }
                    }
                }
            }
            return candidato;
        }

        private async Task<PadresViewModel> GetPadresByCandidatoIdAsync(int candidatoId)
        {
            PadresViewModel padres = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Padres_CandidatoId", conn)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            padres = new PadresViewModel
                            {
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                NombrePadre = GetValueOrDefault<string>(reader, "NombrePadre"),
                                NombreMadre = GetValueOrDefault<string>(reader, "NombreMadre"),
                                EdadPadre = GetValueOrDefault<int?>(reader, "EdadP"),
                                EdadMadre = GetValueOrDefault<int?>(reader, "EdadM"),
                                NumResidenciaP = GetValueOrDefault<string>(reader, "NoResidenciaP"),
                                NumResidenciaM = GetValueOrDefault<string>(reader, "NoResidenciaM"),
                                DPIPadre = GetValueOrDefault<string>(reader, "DPIP"),
                                DPIMadre = GetValueOrDefault<string>(reader, "DPIM"),
                                EstadoCivilP = GetValueOrDefault<string>(reader, "EstadoCivilP"),
                                EstadoCivilM = GetValueOrDefault<string>(reader, "EstadoCivilM"),
                                CelularP = GetValueOrDefault<string>(reader, "CelularP"),
                                CelularM = GetValueOrDefault<string>(reader, "CelularM"),
                                ProfesionP = GetValueOrDefault<string>(reader, "ProfesionP"),
                                ProfesionM = GetValueOrDefault<string>(reader, "ProfesionM"),
                                NacionalidadP = GetValueOrDefault<string>(reader, "NacionalidadP"),
                                NacionalidadM = GetValueOrDefault<string>(reader, "NacionalidadM"),
                                LugarTrabajoP = GetValueOrDefault<string>(reader, "LugarTrabajoP"),
                                LugarTrabajoM = GetValueOrDefault<string>(reader, "LugarTrabajoM")
                            };
                        }
                    }
                }
            }
            return padres;
        }

        private async Task<List<HermanoViewModel>> GetHermanosByCandidatoIdAsync(int candidatoId)
        {
            var hermanos = new List<HermanoViewModel>();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Hermanos_CandidatoId", conn)) // Asume este SP
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            hermanos.Add(new HermanoViewModel
                            {
                                IdHermano = GetValueOrDefault<int>(reader, "IdHermano"),
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                Nombre = GetValueOrDefault<string>(reader, "Nombre"),
                                Edad = GetValueOrDefault<int?>(reader, "Edad"),
                                NoResidencia = GetValueOrDefault<string>(reader, "NoResidencia"),
                                DPI = GetValueOrDefault<string>(reader, "DPI"),
                                EstadoCivil = GetValueOrDefault<string>(reader, "EstadoCivil"),
                                Celular = GetValueOrDefault<string>(reader, "Celular"),
                                Profesion = GetValueOrDefault<string>(reader, "Profesion"),
                                Nacionalidad = GetValueOrDefault<string>(reader, "Nacionalidad"),
                                LugarTrabajo = GetValueOrDefault<string>(reader, "LugarTrabajo")
                            });
                        }
                    }
                }
            }
            return hermanos;
        }

        private async Task<List<HijoViewModel>> GetHijosByCandidatoIdAsync(int candidatoId)
        {
            var hijos = new List<HijoViewModel>();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Hijos_CandidatoId", conn)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            hijos.Add(new HijoViewModel
                            {
                                Id = GetValueOrDefault<int>(reader, "Id"),
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                NombreHijo = GetValueOrDefault<string>(reader, "NombreHijo"),
                                EdadHijo = GetValueOrDefault<int>(reader, "EdadHijo"),
                                Direccion = GetValueOrDefault<string>(reader, "Direccion"),
                                Ocupacion = GetValueOrDefault<string>(reader, "Ocupacion"),
                                EstadoCivilHijo = GetValueOrDefault<string>(reader, "EstadoCivilHijo"),
                                Nacionalidad = GetValueOrDefault<string>(reader, "Nacionalidad"),
                                LugarTrabajo = GetValueOrDefault<string>(reader, "LugarTrabajo")
                            });
                        }
                    }
                }
            }
            return hijos;
        }

        private async Task<List<DeudaViewModel>> GetDeudaByCandidatoIdAsync(int candidatoId)
        {
            var deudas = new List<DeudaViewModel>();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Deudas_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            deudas.Add(new DeudaViewModel
                            {
                                IdDeudas = GetValueOrDefault<int>(reader, "IdDeudas"),
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                Banco = GetValueOrDefault<string>(reader, "Banco"),
                                MontoMensual = GetValueOrDefault<decimal?>(reader, "MontoMensual"),
                                Razon = GetValueOrDefault<string>(reader, "Razon")
                            });
                        }
                    }
                }
            }
            return deudas;
        }

        private async Task<List<GastoMensualViewModel>> GetGastosByCandidatoIdAsync(int candidatoId)
        {
            var gastos = new List<GastoMensualViewModel>();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Gastos_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            gastos.Add(new GastoMensualViewModel
                            {
                                IdGM = GetValueOrDefault<int>(reader, "IdDeudas"),
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                NombreConcepto = GetValueOrDefault<string>(reader, "NombreConcepto"),
                                EsIngreso = GetValueOrDefault<bool>(reader, "EsIngreso"),
                                Monto = GetValueOrDefault<decimal>(reader, "Monto")
                            });
                        }
                    }
                }
            }
            return gastos;
        }

        private async Task<List<TarjetaCreditoViewModel>> GetTarjetaCreditoByCandidatoIdAsync(int candidatoId)
        {
            var tarjetaCredito = new List<TarjetaCreditoViewModel>();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Tarjeta_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tarjetaCredito.Add(new TarjetaCreditoViewModel
                            {
                                IdTarjeta = GetValueOrDefault<int>(reader, "IdTarjeta"),
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                Banco = GetValueOrDefault<string>(reader, "Banco"),
                                LimiteCredito = GetValueOrDefault<decimal>(reader, "LimiteCredito"),
                                SaldoActual = GetValueOrDefault<decimal>(reader, "SaldoActual")
                            });
                        }
                    }
                }
            }
            return tarjetaCredito;
        }

        private async Task<List<EstudioViewModel>> GetEstudioByCandidatoIdAsync(int candidatoId)
        {
            var estudios = new List<EstudioViewModel>();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Estudio_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            estudios.Add(new EstudioViewModel
                            {
                                IdEstudio = GetValueOrDefault<int>(reader, "IdEstudio"),
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                NombreInstitucion = GetValueOrDefault<string>(reader, "NombreInstitucion"),
                                EstudiosRealizados = GetValueOrDefault<string>(reader, "EstudiosRealizados"),
                                Lugar = GetValueOrDefault<string>(reader, "Lugar"),
                                FechaDesde = GetValueOrDefault<DateTime?>(reader, "FechaDesde"),
                                FechaHasta = GetValueOrDefault<DateTime?>(reader, "FechaHasta"),
                                UltimoGrado = GetValueOrDefault<string>(reader, "UltimoGrado")
                            });
                        }
                    }
                }
            }
            return estudios;
        }

        private async Task<List<HistorialLaboralViewModel>> GetHistorialLaboralByCandidatoIdAsync(int candidatoId)
        {
            var historial = new List<HistorialLaboralViewModel>();
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_HistorialLaboral_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            historial.Add(new HistorialLaboralViewModel
                            {
                                Id = GetValueOrDefault<long>(reader, "Id"),
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                Empresa = GetValueOrDefault<string>(reader, "Empresa"),
                                Cargo = GetValueOrDefault<string>(reader, "Cargo"),
                                TelefonoEmpresa = GetValueOrDefault<string>(reader, "TelefonoEmpresa"),
                                FechaIngreso = GetValueOrDefault<DateTime?>(reader, "FechaIngreso"),
                                FechaEgreso = GetValueOrDefault<DateTime?>(reader, "FechaEgreso"),
                                UltimoSalario = GetValueOrDefault<decimal?>(reader, "UltimoSalario"),
                                CausaRetiro = GetValueOrDefault<string>(reader, "CausaRetiro"),
                                JefeInmediato = GetValueOrDefault<string>(reader, "JefeInmediato"),
                                TelefonoJefe = GetValueOrDefault<string>(reader, "TelefonoJefe"),
                                CargoJefe = GetValueOrDefault<string>(reader, "CargoJefe"),
                                Observaciones = GetValueOrDefault<string>(reader, "Observaciones")
                            });
                        }
                    }
                }
            }
            return historial;
        }

        private async Task<AspectosEmocionalesViewModel> GetAspectosEByCandidatoIdAsync(int candidatoId)
        {
            AspectosEmocionalesViewModel aspectos = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_AspectosEmocionales_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            aspectos = new AspectosEmocionalesViewModel
                            {
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                VivenPadres = GetValueOrDefault<bool>(reader, "VivenPadres"),
                                RelacionEntrePadres = GetValueOrDefault<string>(reader, "RelacionEntrePadres"),
                                ConQuienVive = GetValueOrDefault<string>(reader, "ConQuienVive"),
                                IntentosSuicidio = GetValueOrDefault<string>(reader, "IntentosSuicidio"),
                                CualidadRespeta = GetValueOrDefault<string>(reader, "CualidadRespeta"),
                                DefectoIntolerable = GetValueOrDefault<string>(reader, "DefectoIntolerable"),
                                MejorExperiencia = GetValueOrDefault<string>(reader, "MejorExperiencia"),
                                PeorExperiencia = GetValueOrDefault<string>(reader, "PeorExperiencia")
                            };
                        }
                    }
                }
            }
            return aspectos;
        }

        private async Task<HistoriaMedicaViewModel> GetHistoriaMedicaByCandidatoIdAsync(int candidatoId)
        {
            HistoriaMedicaViewModel historia = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_HistoriaMedica_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            historia = new HistoriaMedicaViewModel
                            {
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                CondicionGeneral = GetValueOrDefault<string>(reader, "CondicionGeneral"),
                                MalestarActual = GetValueOrDefault<string>(reader, "MalestarActual"),
                                HoraUltimaComida = GetValueOrDefault<string>(reader, "HoraUltimaComida"),
                                HorasDormidasAyer = GetValueOrDefault<string>(reader, "HorasDormidasAyer"),
                                Embarazo = GetValueOrDefault<bool>(reader, "Embarazo"),
                                EnfermedadGrave = GetValueOrDefault<string>(reader, "EnfermedadGrave")
                            };
                        }
                    }
                }
            }
            return historia;
        }

        private async Task<MedicamentosViewModel> GetMedicamentosByCandidatoIdAsync(int candidatoId)
        {
            MedicamentosViewModel medicamentos = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Medicamentos_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            medicamentos = new MedicamentosViewModel
                            {
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                IngestaAlcohol24h = GetValueOrDefault<bool>(reader, "IngestaAlcohol24h"),
                                Droga30dias = GetValueOrDefault<bool>(reader, "Droga30dias"),
                                TratMedicoReciente = GetValueOrDefault<bool>(reader, "TratMedicoReciente"),
                                ConsumeMedicamentos = GetValueOrDefault<bool>(reader, "ConsumeMedicamentos"),
                                DopingPracticado = GetValueOrDefault<bool>(reader, "DopingPracticado"),
                                DopingAlterado = GetValueOrDefault<bool>(reader, "DopingAlterado"),
                                Cirugia = GetValueOrDefault<bool>(reader, "Cirugia"),
                                AlergiaMedicamento = GetValueOrDefault<bool>(reader, "AlergiaMedicamento"),
                                UltimoChequeoMedico = GetValueOrDefault<string>(reader, "UltimoChequeoMedico"),
                                AlergiaComida = GetValueOrDefault<bool>(reader, "AlergiaComida"),
                                UltimoChequeoOdonto = GetValueOrDefault<string>(reader, "UltimoChequeoOdonto"),
                                UltimoChequeoOftalmo = GetValueOrDefault<string>(reader, "UltimoChequeoOftalmo"),
                                UsaLentes = GetValueOrDefault<bool>(reader, "UsaLentes"),
                                Fuma = GetValueOrDefault<bool>(reader, "Fuma"),
                                Observaciones = GetValueOrDefault<string>(reader, "Observaciones")
                            };
                        }
                    }
                }
            }
            return medicamentos;
        }

        private async Task<HabitosAlcoholViewModel> GetHabitosAlcoholByCandidatoIdAsync(int candidatoId)
        {
            HabitosAlcoholViewModel habitos = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_HabitosAlcohol_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            habitos = new HabitosAlcoholViewModel
                            {
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                UltimaVezBebio = GetValueOrDefault<string>(reader, "UltimaVezBebio"),
                                PromedioMensual = GetValueOrDefault<string>(reader, "PromedioMensual"),
                                ExcesosPorAnio = GetValueOrDefault<int?>(reader, "ExcesosPorAnio"),
                                ComoEsCuandoExcede = GetValueOrDefault<string>(reader, "ComoEsCuandoExcede"),
                                UltimaAmnesia = GetValueOrDefault<string>(reader, "UltimaAmnesia"),
                                UltimaConduccionEbrio = GetValueOrDefault<string>(reader, "UltimaConduccionEbrio"),
                                PeorEvento = GetValueOrDefault<string>(reader, "PeorEvento"),
                                PeleaAlBeber = GetValueOrDefault<bool>(reader, "PeleaAlBeber"),
                                DetenidoAlBeber = GetValueOrDefault<bool>(reader, "DetenidoAlBeber"),
                                TratamientoControlBeber = GetValueOrDefault<bool>(reader, "TratamientoControlBeber"),
                                LaboroEbrioResaca = GetValueOrDefault<bool>(reader, "LaboroEbrioResaca"),
                                FaltoPorBeber = GetValueOrDefault<bool>(reader, "FaltoPorBeber"),
                                BebioEnHorasTrabajo = GetValueOrDefault<bool>(reader, "BebioEnHorasTrabajo")
                            };
                        }
                    }
                }
            }
            return habitos;
        }

        private async Task<DrogasViewModel> GetDrogasByCandidatoIdAsync(int candidatoId)
        {
            DrogasViewModel drogas = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Drogas_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            drogas = new DrogasViewModel
                            {
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                UltimaVezConsumo = GetValueOrDefault<string>(reader, "UltimaVezConsumo"),
                                ProboDrogas = GetValueOrDefault<bool>(reader, "ProboDrogas"),
                                CualquierContacto = GetValueOrDefault<bool>(reader, "CualquierContacto"),
                                GuardoDrogaAjena = GetValueOrDefault<bool>(reader, "GuardoDrogaAjena"),
                                ContactoConVendedores = GetValueOrDefault<bool>(reader, "ContactoConVendedores"),
                                FamiliarConsume = GetValueOrDefault<bool>(reader, "FamiliarConsume")
                            };
                        }
                    }
                }
            }
            return drogas;
        }

        private async Task<AntecedentesViewModel> GetAntecedentesByCandidatoIdAsync(int candidatoId)
        {
            AntecedentesViewModel antecedentes = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Antecedentes_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            antecedentes = new AntecedentesViewModel
                            {
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                CausoHeridasGraves = GetValueOrDefault<bool>(reader, "CausoHeridasGraves"),
                                MatoAlguien = GetValueOrDefault<bool>(reader, "MatoAlguien"),
                                UltimaRina = GetValueOrDefault<string>(reader, "UltimaRina"),
                                UltimaPerdidaControl = GetValueOrDefault<string>(reader, "UltimaPerdidaControl")
                            };
                        }
                    }
                }
            }
            return antecedentes;
        }

        private async Task<ManejoArmasViewModel> GetManejoArmasByCandidatoIdAsync(int candidatoId)
        {
            ManejoArmasViewModel manejo = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_ManejoArmas_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            manejo = new ManejoArmasViewModel
                            {
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                TieneArmasPropias = GetValueOrDefault<bool>(reader, "TieneArmasPropias"),
                                HaPortadoArma = GetValueOrDefault<bool>(reader, "HaPortadoArma"),
                                EnfrentamientoConArma = GetValueOrDefault<bool>(reader, "EnfrentamientoConArma"),
                                DisparoInnecesario = GetValueOrDefault<bool>(reader, "DisparoInnecesario"),
                                UsoIndebidoArma = GetValueOrDefault<bool>(reader, "UsoIndebidoArma"),
                                CompraVentaIlegalArmas = GetValueOrDefault<bool>(reader, "CompraVentaIlegalArmas")
                            };
                        }
                    }
                }
            }
            return manejo;
        }

        private async Task<ConclusionesViewModel> GetConclusionesByCandidatoIdAsync(int candidatoId)
        {
            ConclusionesViewModel conclusiones = null;
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Conclusiones_CandidatoId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            conclusiones = new ConclusionesViewModel
                            {
                                CandidatoId = GetValueOrDefault<int>(reader, "CandidatoId"),
                                ExperienciaChantajeable = GetValueOrDefault<bool?>(reader, "ExperienciaChantajeable"),
                                PensabaPreguntasFaltantes = GetValueOrDefault<bool?>(reader, "PensabaPreguntasFaltantes"),
                                FalseoOmisiones = GetValueOrDefault<bool?>(reader, "FalseoOmisiones"),
                                AlgoQuePreocupe = GetValueOrDefault<bool?>(reader, "AlgoQuePreocupe"),
                                AlgoQueDecir = GetValueOrDefault<bool?>(reader, "AlgoQueDecir"),
                                ObjetivosCP = GetValueOrDefault<string>(reader, "ObjetivosCP"),
                                ObjetivosMP = GetValueOrDefault<string>(reader, "ObjetivosMP"),
                                ObjetivosLP = GetValueOrDefault<string>(reader, "ObjetivosLP")
                            };
                        }
                    }
                }
            }
            return conclusiones;
        }

        // --- Helper para leer datos de forma segura ---
        private T GetValueOrDefault<T>(SqlDataReader reader, string columnName)
        {
            int ordinal = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(ordinal))
            {
                return default; // Retorna el valor por defecto (null para objetos, 0 para números, etc.)
            }
            
            object value = reader.GetValue(ordinal);
            Type targetType = typeof(T);
            
            // Manejar tipos nullable (int?, DateTime?, etc.)
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                targetType = Nullable.GetUnderlyingType(targetType);
            }
            
            return (T)Convert.ChangeType(value, targetType);
        }

        // Método para actualizar un candidato
        public async Task<bool> ActualizarCandidatoAsync(CandidatoViewModel candidato)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Candidato_Actualizar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros del candidato
                    cmd.Parameters.Add(new SqlParameter("@Id", candidato.Id));
                    cmd.Parameters.Add(new SqlParameter("@Nombres", candidato.Nombres ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Apellidos", candidato.Apellidos ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Edad", candidato.Edad ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DPI", candidato.DPI ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DPIExtendidoEn", candidato.DPIExtendidoEn ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@LugarNacimiento", candidato.LugarNacimiento ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", candidato.FechaNacimiento ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Direccion", candidato.Direccion ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Nacionalidad", candidato.Nacionalidad ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@NumIGSS", candidato.NumIGSS ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoCasa", candidato.TelefonoCasa ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoCelular", candidato.TelefonoCelular ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Profesion", candidato.Profesion ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PlazaAplica", candidato.PlazaAplica ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@EstadoCivil", candidato.EstadoCivil ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TipoSangre", candidato.TipoSangre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ContactoEmergencia", candidato.ContactoEmergencia ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@TelefonoEmergencia", candidato.TelefonoEmergencia ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@DependientesEconomicos", candidato.DependientesEconomicos ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@NIT", candidato.Nit ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ExperienciasPoligraficas", candidato.ExperienciasPoligraficas ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ResultadoPoligrafoPrevio", candidato.ResultadoPoligrafoPrevio ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@PorcentajeIngles", candidato.PorcentajeIngles ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Correo", candidato.Correo ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@UsuariosRedes", candidato.UsuariosRedes ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeNombre", candidato.ConyugeNombre ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeEdad", candidato.ConyugeEdad ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeDPI", candidato.ConyugeDPI ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeCel", candidato.ConyugeCel ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeEstadoCivil", candidato.ConyugeEstadoCivil ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeOcupacion", candidato.ConyugeOcupacion ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeTrabajo", candidato.ConyugeTrabajo ?? (object)DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@ConyugeTelTrabajo", candidato.ConyugeTelTrabajo ?? (object)DBNull.Value));

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        // Método para eliminar (soft delete) un candidato
        public async Task<bool> EliminarCandidatoAsync(int candidatoId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("sp_Candidato_Eliminar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CandidatoId", candidatoId));

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

    }
}