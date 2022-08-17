using BL.Services;
using BL.Abstract;
using RssFeed.Models;

//»спользую сессии намеренно, поскольку в задании не было написано про Ѕƒ. ƒо этого про сессии только слышал, поэтому решил попробовать попрактиковатьс€ с ними в этом задании.
//–анее немного работал с ORM Entity Framework (например, в этом проекте: https://github.com/prplmad/TelegramBotReminder)

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddXmlFile("settings.xml");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddTransient<IDownloadFeedService, DownloadFeedService>();
builder.Services.AddScoped<Settings, Settings>();
builder.Services.AddTransient<IFeedUrlValidationService, FeedUrlValidationService>();
builder.Services.AddTransient<ISettingsService, SettingsService>();
builder.Services.AddTransient<IFeedService, FeedService>();




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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Settings}/{action=Settings}/{id?}");

app.Run();