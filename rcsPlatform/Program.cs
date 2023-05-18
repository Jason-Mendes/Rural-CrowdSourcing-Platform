using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using rcsPlatform.Models;
using rcsPlatform;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<rcsDbContext>();
builder.Services.Configure<StaticFileOptions>(opt =>{
    opt.ServeUnknownFileTypes = true;
    opt.DefaultContentType = "application/octet-stream";
});

builder.Services.AddDbContext<rcsDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 23))));

var app = builder.Build();

// Configure method for the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// app.UseStaticFiles(new StaticFileOptions
// {
//     FileProvider = new PhysicalFileProvider(
//         Path.Combine(app.Environment.ContentRootPath, "MyStaticFiles")),
//     RequestPath = "/StaticFiles"
// });

app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles();
string staticFilesFolder = Path.Combine(app.Environment.ContentRootPath, "MyStaticFiles");
if (!Directory.Exists(staticFilesFolder))
{
    Directory.CreateDirectory(staticFilesFolder);
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(staticFilesFolder),
    RequestPath = "/StaticFiles"
});


// All the other code...


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapFallbackToFile("/index.html");
});
app.UseAuthorization();

app.Run();
