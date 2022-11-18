using ClubMan.Api;
using ClubMan.Shared.Model;
using LamarCodeGeneration.Util;
using Marten;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMarten(o =>
    {
        o.Connection(builder.Configuration.GetConnectionString("Default"));
        o.Schema.For<Localidad>().MultiTenanted();
        o.Schema.For<Instalacion>().MultiTenanted().ForeignKey<Localidad>( i => i.LocalidadId);
        o.Schema.For<Actividad>().MultiTenanted().ForeignKey<Instalacion>(a => a.InstalacionId);
        o.Schema.For<Noticia>().MultiTenanted();
        o.Schema.For<Servicio>().MultiTenanted();
        o.Schema.For<Politica>().MultiTenanted();
        o.Schema.For<Solicitud>().MultiTenanted();
        o.Schema.For<Empresa>();
        o.Schema.For<Usuario>().ForeignKey<Empresa>(u => u.EmpresaId);
    })
    .OptimizeArtifactWorkflow();

builder.Services.AddHttpContextAccessor();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();