using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMan.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoAdicional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SobreNosotros = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondaryColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    SoloOficina = table.Column<bool>(type: "bit", nullable: false),
                    Publicado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensaje",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalleUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enviado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noticia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalleUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publicado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Politica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvitadosPorDia = table.Column<int>(type: "int", nullable: false),
                    MenoriaDeEdad = table.Column<int>(type: "int", nullable: false),
                    VisitasAlMesInvitados = table.Column<int>(type: "int", nullable: false),
                    LimiteHuespedes = table.Column<int>(type: "int", nullable: false),
                    DiasMembresiaHuesped = table.Column<int>(type: "int", nullable: false),
                    CuotasParaPasividad = table.Column<int>(type: "int", nullable: false),
                    EdadParaHonorifico = table.Column<int>(type: "int", nullable: false),
                    AntiguedadParaHonorifico = table.Column<int>(type: "int", nullable: false),
                    EdadParaHonorificoPropietario = table.Column<int>(type: "int", nullable: false),
                    AntiguedadParaHonorificoPropietario = table.Column<int>(type: "int", nullable: false),
                    EntradasNoResidentes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Politica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Publicado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusMembresia = table.Column<int>(type: "int", nullable: false),
                    SolicitudId = table.Column<long>(type: "bigint", nullable: false),
                    NumeroCarnet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoSocio = table.Column<int>(type: "int", nullable: false),
                    FechaMembresia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugarTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoOficina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoFlota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreAsistente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAsitente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solcitud",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusSolicitud = table.Column<int>(type: "int", nullable: false),
                    TipoSocio = table.Column<int>(type: "int", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimoSometimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaRevision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Solicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beneficiario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugarTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posición = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoOficina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoFlota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreAsistente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAsitente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitudPdfUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoSocioUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solcitud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpresaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaveHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaveSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instalacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalidadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Reservable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instalacion_Localidad_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdicionalSocio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    TipoAdicional = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    MovimientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdicionalSocio", x => new { x.SocioId, x.Id });
                    table.ForeignKey(
                        name: "FK_AdicionalSocio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DependienteSocio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    NumeroCarnet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDependiente = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugarTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    MovimientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependienteSocio", x => new { x.SocioId, x.Id });
                    table.ForeignKey(
                        name: "FK_DependienteSocio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HuespedSocio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    MovimientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroCarnet = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuespedSocio", x => new { x.SocioId, x.Id });
                    table.ForeignKey(
                        name: "FK_HuespedSocio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvitacionDeSocio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false),
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    NumeroCarnet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaHoraVisita = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitacionDeSocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvitacionDeSocio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoSocio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    DependienteId = table.Column<long>(type: "bigint", nullable: false),
                    TipoMovimiento = table.Column<int>(type: "int", nullable: false),
                    ReferenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistradaPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRevision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevisadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoSocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoSocio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Socio_Embarcaciones",
                columns: table => new
                {
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eslora = table.Column<double>(type: "float", nullable: false),
                    Manga = table.Column<double>(type: "float", nullable: false),
                    Localizacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socio_Embarcaciones", x => new { x.SocioId, x.Id });
                    table.ForeignKey(
                        name: "FK_Socio_Embarcaciones_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependiente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolicitudId = table.Column<long>(type: "bigint", nullable: false),
                    TipoDependiente = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIndentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LugarTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoTrabajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependiente", x => new { x.SolicitudId, x.Id });
                    table.ForeignKey(
                        name: "FK_Dependiente_Solcitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solcitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembresiaAlterna",
                columns: table => new
                {
                    SolicitudId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreClub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiembroDesde = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembresiaAlterna", x => new { x.SolicitudId, x.Id });
                    table.ForeignKey(
                        name: "FK_MembresiaAlterna_Solcitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solcitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferenciaBancaria",
                columns: table => new
                {
                    SolicitudId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Banco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OficialCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDeCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenciaBancaria", x => new { x.SolicitudId, x.Id });
                    table.ForeignKey(
                        name: "FK_ReferenciaBancaria_Solcitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solcitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revision",
                columns: table => new
                {
                    SolicitudId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSometida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstatusRevision = table.Column<int>(type: "int", nullable: false),
                    NumeroAprobacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRevision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadAcciones = table.Column<int>(type: "int", nullable: false),
                    Valoracciones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SometidaPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletadaPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revision", x => new { x.SolicitudId, x.Id });
                    table.ForeignKey(
                        name: "FK_Revision_Solcitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solcitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocioSecundador",
                columns: table => new
                {
                    SolicitudId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSocio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreSocio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocioSecundador", x => new { x.SolicitudId, x.Id });
                    table.ForeignKey(
                        name: "FK_SocioSecundador_Solcitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solcitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solcitud_Embarcaciones",
                columns: table => new
                {
                    SolicitudId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eslora = table.Column<double>(type: "float", nullable: false),
                    Manga = table.Column<double>(type: "float", nullable: false),
                    Localizacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solcitud_Embarcaciones", x => new { x.SolicitudId, x.Id });
                    table.ForeignKey(
                        name: "FK_Solcitud_Embarcaciones_Solcitud_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solcitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstalacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horas = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalleUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publicado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividad_Instalacion_InstalacionId",
                        column: x => x.InstalacionId,
                        principalTable: "Instalacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventoDeSocio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovimientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocioId = table.Column<long>(type: "bigint", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horas = table.Column<int>(type: "int", nullable: false),
                    InstalacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Personas = table.Column<int>(type: "int", nullable: false),
                    Estatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoDeSocio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventoDeSocio_Instalacion_InstalacionId",
                        column: x => x.InstalacionId,
                        principalTable: "Instalacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoDeSocio_Socio_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvitadoEvento",
                columns: table => new
                {
                    EventoDeSocioId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitadoEvento", x => new { x.EventoDeSocioId, x.Id });
                    table.ForeignKey(
                        name: "FK_InvitadoEvento_EventoDeSocio_EventoDeSocioId",
                        column: x => x.EventoDeSocioId,
                        principalTable: "EventoDeSocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_InstalacionId",
                table: "Actividad",
                column: "InstalacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoDeSocio_InstalacionId",
                table: "EventoDeSocio",
                column: "InstalacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoDeSocio_SocioId",
                table: "EventoDeSocio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacion_LocalidadId",
                table: "Instalacion",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitacionDeSocio_SocioId",
                table: "InvitacionDeSocio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoSocio_SocioId",
                table: "MovimientoSocio",
                column: "SocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "AdicionalSocio");

            migrationBuilder.DropTable(
                name: "Dependiente");

            migrationBuilder.DropTable(
                name: "DependienteSocio");

            migrationBuilder.DropTable(
                name: "HuespedSocio");

            migrationBuilder.DropTable(
                name: "InvitacionDeSocio");

            migrationBuilder.DropTable(
                name: "InvitadoEvento");

            migrationBuilder.DropTable(
                name: "MembresiaAlterna");

            migrationBuilder.DropTable(
                name: "Mensaje");

            migrationBuilder.DropTable(
                name: "MovimientoSocio");

            migrationBuilder.DropTable(
                name: "Noticia");

            migrationBuilder.DropTable(
                name: "Politica");

            migrationBuilder.DropTable(
                name: "ReferenciaBancaria");

            migrationBuilder.DropTable(
                name: "Revision");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Socio_Embarcaciones");

            migrationBuilder.DropTable(
                name: "SocioSecundador");

            migrationBuilder.DropTable(
                name: "Solcitud_Embarcaciones");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "EventoDeSocio");

            migrationBuilder.DropTable(
                name: "Solcitud");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Instalacion");

            migrationBuilder.DropTable(
                name: "Socio");

            migrationBuilder.DropTable(
                name: "Localidad");
        }
    }
}
