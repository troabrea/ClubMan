using ClubMan.Api;
using ClubMan.Api.Services;
using ClubMan.Shared.Model;
using LamarCodeGeneration;
using LamarCodeGeneration.Util;
using Marten;
using Marten.Events;
using Marten.Storage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Oakton;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ApplyOaktonExtensions();

// Add services to the container.
builder.Services.AddMarten(o =>
    {
        o.Connection(builder.Configuration.GetConnectionString("Default"));
        o.Schema.For<Localidad>().MultiTenanted();
        o.Schema.For<Instalacion>().MultiTenanted().ForeignKey<Localidad>( i => i.LocalidadId);
        o.Schema.For<Actividad>().MultiTenanted().ForeignKey<Instalacion>(a => a.InstalacionId);
        o.Schema.For<Noticia>().MultiTenanted();
        o.Schema.For<Mensaje>().Duplicate(x => x.Enviado).MultiTenanted();
        o.Schema.For<Servicio>().MultiTenanted();
        o.Schema.For<Politica>().MultiTenanted();
        o.Schema.For<Solicitud>().MultiTenanted();
        o.Schema.For<Socio>().MultiTenanted();
        o.Schema.For<MovimientoSocio>().MultiTenanted();
        o.Schema.For<InvitacionDeSocio>().Duplicate(x => x.NumeroIdentidad).Duplicate(x => x.SocioId).MultiTenanted();
        o.Schema.For<Visitas>().MultiTenanted();
        o.Schema.For<VisitasSocio>().MultiTenanted();
        o.Schema.For<VisitasInvitado>().MultiTenanted();

        o.Events.TenancyStyle = TenancyStyle.Conjoined;
        o.Events.StreamIdentity = StreamIdentity.AsString;
        
        o.Projections.SelfAggregate<Visitas>().MultiTenanted();
        o.Projections.SelfAggregate<VisitasSocio>().MultiTenanted();
        o.Projections.SelfAggregate<VisitasInvitado>().MultiTenanted();
        
        o.Schema.For<Carnet>().Identity(x => x.CarnetId).Duplicate(x => x.NumeroIdentidad, notNull:true).
            Duplicate(x => x.Nombre, notNull:true).
            MultiTenanted();
        o.Schema.For<Empresa>();
        o.Schema.For<Usuario>().ForeignKey<Empresa>(u => u.EmpresaId);
    })
    .OptimizeArtifactWorkflow( TypeLoadMode.Static );

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICarnetService, CarnetService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.AddSecurityDefinition("Api-Auth", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Api Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    o.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Api-Auth"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, TenantAuthorizationHandler>
        ("BasicAuthentication", null);

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunOaktonCommands(args);