using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using ClubMan.Web.Auth;

using ClubMan.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Net.Http.Headers;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzQzNTk0QDMyMzAyZTMzMmUzMEx0dnF6aDgwYzhhZDA0OVRYNWN5TzV0NzZoTWZQMStYOGlzVzVzMWUxQk09");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var apiUrl = builder.Configuration.GetValue<String>("ApiConfig:ApiUrl");
var apiKey = builder.Configuration.GetValue<String>("ApiConfig:ApiKey");

builder.Services.AddHttpClient("system", (cfg) =>
{
    cfg.BaseAddress = new Uri(apiUrl);
    cfg.DefaultRequestHeaders.Add(HeaderNames.Authorization,$"Bearer {apiKey}");
});

builder.Services.AddHttpClient("api", (cfg) =>
{
    cfg.BaseAddress = new Uri(apiUrl);
    cfg.DefaultRequestHeaders.Add(HeaderNames.Authorization,$"Bearer *DEFAULT*");
});

builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
builder.Services.AddSyncfusionBlazor();


builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddScoped<ISystemApiService, SystemApiService>();
builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<ICloudStorageService, CloudStorageService>();

builder.Services.AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services
    .AddBlazoriseRichTextEdit();

var app = builder.Build();
app.UseRequestLocalization("es-DO");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
