using Microsoft.EntityFrameworkCore;
using FootballPlayersCatalog.Context;
using FootballPlayersCatalog.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервисов и подключение к базе данных
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Конфигурация обработчика HTTP запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Маршрутизация хаба SignalR
app.MapHub<PlayerHub>("/playerhub");

// Установка маршрута по умолчанию для контроллера "AddPlayer" с действием "Index".
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AddPlayer}/{action=Index}/{id?}");

app.Run();
