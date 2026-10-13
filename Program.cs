using ProductsCRUD.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// Required DI lifetime. Static synchronized state keeps seed products available across requests.
builder.Services.AddScoped<IProductService, InMemoryProductService>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Products}/{action=Index}/{id?}");
app.Run();
