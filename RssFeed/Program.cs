using BL.Services;
using BL.Abstract;
using RssFeed.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddXmlFile("settings.xml");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDownloadFeedService, DownloadFeedService>();
builder.Services.AddSingleton<Settings, Settings>();
builder.Services.AddTransient<IFeedUrlValidationService, FeedUrlValidationService>();
builder.Services.AddTransient<ISettingsService, SettingsService>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Settings}/{action=Settings}/{id?}");

app.Run();