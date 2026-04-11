var builder = WebApplication.CreateBuilder(args);

// Add MVC
builder.Services.AddControllersWithViews();

// ✅ Enable Session
builder.Services.AddSession();

var app = builder.Build();

// Middleware
app.UseStaticFiles();
app.UseRouting();

// ✅ Use Session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();