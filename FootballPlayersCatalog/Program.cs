using Microsoft.EntityFrameworkCore;
using FootballPlayersCatalog.Context;
using FootballPlayersCatalog.Hubs;

var builder = WebApplication.CreateBuilder(args);

// ���������� �������� � ����������� � ���� ������
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// ������������ ����������� HTTP ��������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ������������� ���� SignalR
app.MapHub<PlayerHub>("/playerhub");

// ��������� �������� �� ��������� ��� ����������� "AddPlayer" � ��������� "Index".
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AddPlayer}/{action=Index}/{id?}");

app.Run();
