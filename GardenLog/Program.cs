using GardenLog.Models;
using GardenLog.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<JsonFileWmoCodeConverterService>();
builder.Services.AddTransient<JsonFileWeatherService>();
builder.Services.AddTransient<GetUsersService>();
builder.Services.AddTransient<GetBlogPostService>();
builder.Services.AddTransient<CreateJsonBlogPostService>();
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext") ?? throw new InvalidOperationException("Connection string 'UserContext' not found.")));
builder.Services.AddControllers();
builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options=>
{
    options.Cookie.Name = "CookieAuth"; // config. cookie name
});

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromHours(3);
});

var app = builder.Build();

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

app.UseAuthentication(); //middeleware - is this really needed?
app.UseAuthorization();

app.MapRazorPages();

app.MapBlazorHub();

app.Run();
