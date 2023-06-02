﻿using VinaOfficeWebsite.Database;
using VinaOfficeWebsite.Repository;
using Microsoft.AspNetCore.Rewrite;
using VinaOfficeWebsite.Models.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<BzVinaofficeContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);


builder.Services.AddDbContext<BzVinaofficeContext>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.Configure<SystemConfig>(
    builder.Configuration.GetSection("SystemConfig"));

builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");


builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();
// Adding Database Context to Web Application Builder Services Collection.
// This should be performed before building Web Application.

//handle 404 page
app.Use(async (ctx, next) =>
{
    await next();
    if (ctx.Response.StatusCode == 404)
    {
        ctx.Request.Path = "/Error/Page404";
        await next();
    }
});

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.UseStaticFiles();

var options = new RewriteOptions()
       .AddRewrite("sitemap.xml", "Sitemap/SitemapXml", skipRemainingRules: true)
       .AddRewrite("robots.txt", "Sitemap/RobotServices", skipRemainingRules: true)
       .AddRewrite("Home/SaveOrder", "Home/SaveOrder", skipRemainingRules: true)
       .AddRewrite("Contact/Send", "Contact/Send", skipRemainingRules: true)
       .AddRewrite("Home/LoadCart", "Home/LoadCart", skipRemainingRules: true)
       .AddRewrite("tong-quan/(.*)", "About/Index?slug=$1", skipRemainingRules: true)
       .AddRewrite("tong-quan/(.*)/", "About/Index?slug=$1", skipRemainingRules: true)
       .AddRewrite("chinh-sach/(.*)", "About/Policy?slug=$1", skipRemainingRules: true)
       .AddRewrite("chinh-sach/(.*)/", "About/Policy?slug=$1", skipRemainingRules: true)
       .AddRewrite("dat-hang", "Home/Order", skipRemainingRules: true)
       .AddRewrite("dat-hang/", "Home/Order", skipRemainingRules: true)
       .AddRewrite("gio-hang", "Home/Cart", skipRemainingRules: true)
       .AddRewrite("gio-hang/", "Home/Cart", skipRemainingRules: true)
       .AddRewrite("tim-kiem/(.*)", "Search/Index?q=$1", skipRemainingRules: true)
       .AddRewrite("tim-kiem/(.*)/", "Search/Index?q=$1", skipRemainingRules: true)
       .AddRewrite("blogs/(.*).html", "Blog/Detail?slug=$1", skipRemainingRules: true)
       .AddRewrite("blogs", "Blog/Index", skipRemainingRules: true)
       .AddRewrite("blogs/", "Blog/Index", skipRemainingRules: true)
       .AddRewrite("lien-he", "Contact/Index?slug=$1", skipRemainingRules: true)
       .AddRewrite("lien-he/", "Contact/Index?slug=$1", skipRemainingRules: true)
       .AddRewrite("chi-tiet-(.*).html", "Product/Detail?slug=$1", skipRemainingRules: true)
       .AddRewrite("(.*^.{2,}$)", "Product/Index?slug=$1", skipRemainingRules: false);

app.UseRewriter(options);

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

