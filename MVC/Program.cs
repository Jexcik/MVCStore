using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC;
using MVC.Db;
using MVC.Db.Models;

var builder = WebApplication.CreateBuilder(args);

//Получаем строку подключения из файла конфигурации
var connection = builder.Configuration.GetConnectionString("MVC_Shop");

//Добавляем DatabaseContext в качестве сервиса в приложение
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
//добавляем контекст IndentityContext в качестве сервиса в приложение
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));

// указываем тип пользователя и роли
builder.Services.AddIdentity<User, IdentityRole>()
                // устанавливаем тип хранилища - наш контекст
                .AddEntityFrameworkStores<IdentityContext>();

// настройка cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.Cookie = new CookieBuilder
    {
        IsEssential = true
    };
});


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductsRepository, ProductsDbRepository>();
builder.Services.AddTransient<ICartsRepository, CartsDbRepository>();
builder.Services.AddTransient<IOrdersRepository, OrdersDbRepository>();
builder.Services.AddTransient<ICompareRepository, CompareDbRepository>();
builder.Services.AddTransient<IFavoriteRepository, FavoriteDbRepository>();
builder.Services.AddSingleton<IRolesRepository, RolesInMemoryRepository>();
builder.Services.AddSingleton<IUsersRepository, UsersInMemoryRepository>();
builder.Services.AddSingleton<Constants>();

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

//Подключение аутентификации
app.UseAuthentication();
//Подключение авторизации
app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
