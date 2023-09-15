using ClubMan.WebApi.Model;
using ClubMan.WebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ClubManContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IErpService, ErpService>();
builder.Services.AddScoped<ICarnetService, CarnetService>();
// builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

if(!app.Environment.IsDevelopment()) {
    app.UseHttpsRedirection();
}
app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();