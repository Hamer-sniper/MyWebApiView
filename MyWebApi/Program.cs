using Microsoft.AspNetCore.Identity;
using MyWebApiView.Authentification;
using MyWebApiView.Controllers;
using MyWebApiView.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddMvc(mvcOtions => mvcOtions.EnableEndpointRouting = false);

        builder.Services.AddScoped<IDataBookData, DataBookDataApi>();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
        });

        //builder.Services.AddCors();

        var app = builder.Build();

        //app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.Use(async (context, next) =>
        {
            var token = context.Request.Cookies[".AspNetCore.Application.Id"];
            if (!string.IsNullOrEmpty(token))
                context.Request.Headers.Add("Authorization", "Bearer " + token);

            await next();
        });

        app.UseAuthentication();

        app.UseAuthorization();

        /*app.UseCors(x => x
        .WithOrigins("https://localhost:7161/api/MyApi") // путь к нашему SPA клиенту
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader());

        app.UseCookiePolicy(new CookiePolicyOptions
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
            HttpOnly = HttpOnlyPolicy.Always,
            Secure = CookieSecurePolicy.Always
        });*/

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=DataBook}/{action=Index}/{id?}");

        app.Run();
    }
}