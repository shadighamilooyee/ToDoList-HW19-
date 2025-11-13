using App.Domain.AppServices;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.ItemAgg.Contracts;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Services;
using App.Infra.Data.Repo.Ef;
using App.Infra.Db.SqlServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(@"Server=DESKTOP-Q3HHNR8\SQLEXPRESS;Database=ToDoList;Integrated Security=true;TrustServerCertificate=True;");
});
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItemAppService, ItemAppService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Authentication/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authentication}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
