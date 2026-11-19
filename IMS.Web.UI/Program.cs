using IMS.DataAccess;
using IMS.Facade;
using IMS.Facade.Interface;
using IMS.Web.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;





var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")
//    )
//);

// Add services to the container./add MVC 
builder.Services.AddControllersWithViews();

//Depedency injection connection
builder.Services.AddImsFacade(builder.Configuration);



// Authentication Configuration
builder.Services
    .AddAuthentication(
        CookieAuthenticationDefaults.AuthenticationScheme
    )
    .AddCookie(options =>
    {
        options.Cookie.Name = "IMS.Auth";

        options.LoginPath = "/Authentication/Login";

        options.AccessDeniedPath = "/Authentication/AccessDenied";

        options.ExpireTimeSpan = TimeSpan.FromHours(2);

        options.SlidingExpiration = true;


        // Validate the user on every authenticated request
        options.Events.OnValidatePrincipal = async context =>
        {
            var userIdValue = context.Principal?
                .FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userIdValue, out int userId))
            {
                context.RejectPrincipal();

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme
                );

                return;
            }

            var userFacade = context.HttpContext.RequestServices
                .GetRequiredService<IUserFacade>();

            var user = await userFacade.GetByIdAsync(userId);

            // Reject deleted or inactive users
            if (user == null || !user.IsActive)
            {
                context.RejectPrincipal();

                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme
                );

                return;
            }

            // Refresh the user's latest identity information
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email)
        };

            foreach (var userRole in user.UserRoles)
            {
                if (userRole.Role != null)
                {
                    claims.Add(
                        new Claim(ClaimTypes.Role, userRole.Role.RoleName)
                    );
                }
            }

            foreach (var userRole in user.UserRoles)
            {
                if (userRole.Role != null)
                {
                    claims.Add(
                        new Claim(ClaimTypes.Role, userRole.Role.RoleName)
                    );
                }
            }




            var roleIds = user.UserRoles
    .Select(x => x.RoleId)
    .ToList();

            var rolePermissionFacade = context.HttpContext.RequestServices
                .GetRequiredService<IRolePermissionFacade>();

            var permissionFacade = context.HttpContext.RequestServices
                .GetRequiredService<IPermissionFacade>();

            var rolePermissions =
                await rolePermissionFacade.GetAllAsync();

            var permissionIds = rolePermissions
                .Where(x => roleIds.Contains(x.RoleId))
                .Select(x => x.PermissionId)
                .Distinct()
                .ToList();

            var permissions = await permissionFacade.GetAllAsync();

            foreach (var permission in permissions)
            {
                if (permissionIds.Contains(permission.PermissionId)
                    && permission.IsActive)
                {
                    claims.Add(
                        new Claim("Permission", permission.PermissionName)
                    );
                }
            }















            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            context.ReplacePrincipal(new ClaimsPrincipal(identity));

            context.ShouldRenew = true;
        };
    });




//permission

builder.Services.AddSingleton<
    IAuthorizationPolicyProvider,
    PermissionPolicyProvider>();

builder.Services.AddScoped<
    IAuthorizationHandler,
    PermissionAuthorizationHandler>();
















// Authorization
builder.Services.AddAuthorization();


var app = builder.Build();






// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
