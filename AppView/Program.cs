
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    option =>
    {
        option.LoginPath = "/Login/Login";
    });

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
app.UseDefaultFiles();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.UseSession();



app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
      name: "Admin",
      areaName: "Admin",
      pattern: "Admin/{controller=Home}/{action=TrangChu}/{id?}"
    );

    endpoints.MapAreaControllerRoute(
      name: "KhachHang",
      areaName: "KhachHang",
      pattern: "KhachHang/{controller=HomeKhachHang}/{action=IndexKhachHang}/{id?}"
    );




});
app.MapControllerRoute(
name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");


app.Run();

