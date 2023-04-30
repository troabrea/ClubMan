using Microsoft.EntityFrameworkCore;
using ClubMan.Shared.Model;

namespace ClubMan.WebApi.Model;

public class ClubManContext : DbContext
{
    public ClubManContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Empresa> Empresas => Set<Empresa>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<UsuarioApp> UsuariosApp => Set<UsuarioApp>();
    public DbSet<Politica> Politicas => Set<Politica>();
    public DbSet<Localidad> Localidades => Set<Localidad>();
    public DbSet<Instalacion> Instalaciones => Set<Instalacion>();
    public DbSet<Actividad> Actividades => Set<Actividad>();
    public DbSet<Mensaje> Mensajes => Set<Mensaje>();
    public DbSet<Noticia> Noticias => Set<Noticia>();
    public DbSet<Pregunta> Preguntas => Set<Pregunta>();
    public DbSet<Servicio> Servicios => Set<Servicio>();
    public DbSet<Carnet> Carnets => Set<Carnet>();
    public DbSet<Socio> Socios => Set<Socio>();
    public DbSet<Solicitud> Solicitudes => Set<Solicitud>();
    public DbSet<MovimientoSocio> MovimientosSocio => Set<MovimientoSocio>();
    public DbSet<EventoDeSocio> EventosDeSocio => Set<EventoDeSocio>();
    public DbSet<InvitacionDeSocio> InvitacionesDeSocio => Set<InvitacionDeSocio>();
    public DbSet<VisitaManual> VisitasManuales => Set<VisitaManual>();
    public DbSet<Visitas> Visitas => Set<Visitas>();
    public DbSet<VisitasInvitado> VisitasInvitado => Set<VisitasInvitado>();
    public DbSet<VisitasSocio> VisitasSocio => Set<VisitasSocio>();

    public DbSet<Cxc> Cxc => Set<Cxc>();
    public DbSet<Cobro> Cobros => Set<Cobro>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAdminModel(modelBuilder);
        ConfigureContentModel(modelBuilder);

        ConfigureSolictudModel(modelBuilder);
        ConfigureSocioModel(modelBuilder);

        ConfigureTransactionsModel(modelBuilder);
        
        ConfigureCxcModel(modelBuilder);
    }

    private static void ConfigureCxcModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cxc>()
            .ToView("Balances")
            .HasKey(r => r.IdInterno);
        
        modelBuilder.Entity<Cobro>(b =>
        {
            b.ToTable("Cobro")
                .HasKey(r => r.Id);
            b.OwnsMany(x => x.Aplicaciones);    
        });
    }
    
    private static void ConfigureTransactionsModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VisitaManual>(b =>
        {
            b.HasKey(b => b.Id);
            b.Property(x => x.PorteroId).IsRequired();
            b.Property(x => x.FechaHora).IsRequired();
            b.ToTable("VisitaManual");
            b.HasIndex(x => x.PorteroId);
            b.HasIndex(x => x.FechaHora);
        });
        
        modelBuilder.Entity<EventoDeSocio>(b =>
        {
            b.Property(x => x.SocioId).IsRequired();
            b.Property(x => x.InstalacionId).IsRequired();
            b.OwnsMany(x => x.Invitados);
            b.HasOne<Socio>()
                .WithMany()
                .HasForeignKey(x => x.SocioId);

            b.HasOne<Instalacion>()
                .WithMany()
                .HasForeignKey(x => x.InstalacionId);

            b.ToTable("EventoDeSocio");
        });

        modelBuilder.Entity<MovimientoSocio>(b =>
        {
            b.Property(x => x.SocioId).IsRequired();

            b.HasOne<Socio>()
                .WithMany()
                .HasForeignKey(x => x.SocioId);


            b.ToTable("MovimientoSocio");
        });

        modelBuilder.Entity<InvitacionDeSocio>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.SolicitudId).IsRequired();
            b.Property(x => x.SocioId).IsRequired();

            b.HasIndex(x => x.SolicitudId);
            b.HasIndex(x => x.FechaHoraVisita);
            b.HasIndex(x => x.SocioId);
            
            b.HasOne<Socio>()
                .WithMany()
                .HasForeignKey(x => x.SocioId);

            b.ToTable("InvitacionDeSocio");
        });

        modelBuilder.Entity<Carnet>(b =>
            {
                b.Property(x => x.SocioId).IsRequired();
                b.HasKey(x => x.CarnetId);
                b.ToTable("Carnet");
                b.HasOne<Socio>()
                    .WithMany()
                    .HasForeignKey(c => c.SocioId);
            }
        );
        modelBuilder.Entity<MovimientoSocio>(b =>
            {
                b.Property(x => x.SocioId).IsRequired();
                b.ToTable("MovimientoSocio");
                b.HasOne<Socio>()
                    .WithMany()
                    .HasForeignKey(c => c.SocioId);
            }
        );

        modelBuilder.Entity<Visitas>(b =>
        {
            b.HasKey(x => x.Id);
            b.ToTable("Visitas");
        });
        
        modelBuilder.Entity<VisitasSocio>(b =>
        {
            b.Property(x => x.SocioId).IsRequired();
            
            b.HasOne<Socio>()
                .WithMany()
                .HasForeignKey(x => x.SocioId);
            
            b.HasKey(x => x.Id);
            b.ToTable("VisitasSocio");
        });

        modelBuilder.Entity<VisitasInvitado>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.NumeroIdentidad);
            b.ToTable("VisitasInvitado");
        });

    }

    private static void ConfigureContentModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Localidad>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("Localidad");
            }
        );
        modelBuilder.Entity<Instalacion>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.LocalidadId).IsRequired();

            b.HasOne<Localidad>()
                .WithMany()
                .HasForeignKey(x => x.LocalidadId);

            b.ToTable("Instalacion");
        });
        modelBuilder.Entity<Actividad>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.InstalacionId).IsRequired();

            b.HasOne<Instalacion>()
                .WithMany()
                .HasForeignKey(x => x.InstalacionId);

            b.ToTable("Actividad");
        });

        modelBuilder.Entity<Noticia>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("Noticia");
            }
        );
        modelBuilder.Entity<Pregunta>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("Pregunta");
            }
        );
        modelBuilder.Entity<Servicio>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("Servicio");
            }
        );

        modelBuilder.Entity<Mensaje>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("Mensaje");
            }
        );
    }

    private static void ConfigureAdminModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("Empresa");
                b.Ignore(x => x.TiposMembresia);
            }
        );
        modelBuilder.Entity<Usuario>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.EmpresaId).IsRequired();

            b.HasOne<Empresa>()
                .WithMany()
                .HasForeignKey(x => x.EmpresaId);

            b.ToTable("Usuario");
        });

        modelBuilder.Entity<Politica>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("Politica");
            }
        );
    }

    private void ConfigureSolictudModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Solicitud>(b =>
        {
            b.OwnsMany(x => x.MembresiasAlternas);
            b.OwnsMany(x => x.Dependientes);
            b.OwnsMany(x => x.SociosSecundadores);
            b.OwnsMany(x => x.Embarcaciones);
            b.OwnsMany(x => x.Revisiones);
            b.OwnsMany(x => x.ReferenciasBancarias);
            b.ToTable("Solcitud");
        });
    }
    
    private void ConfigureSocioModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Socio>(b =>
        {
            b.OwnsMany(x => x.Dependientes);
            b.OwnsMany(x => x.Embarcaciones);
            b.OwnsMany(x => x.Adicionales);
            b.OwnsMany(x => x.Huespededes);
            b.ToTable("Socio");
        });
        
    }
}