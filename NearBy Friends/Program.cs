using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NearBy_Friends.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders(); // Add this line to ensure default token providers are configured

// Inject IConfiguration
var configuration = builder.Configuration;

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = configuration["Authentication:Google:ClientId"];
        options.ClientSecret = configuration["Authentication:Google:ClientSecret"];

        // Customize user creation during Google authentication
        options.Events = new OAuthEvents
        {
            OnCreatingTicket = async context =>
            {
                // Extract email from the authentication context
                var email = context.User.GetProperty("email").GetString();

                // Retrieve user manager
                var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<IdentityUser>>();

                // Check if the user exists
                var existingUser = await userManager.FindByEmailAsync(email);

                // If the user doesn't exist, create a new user and assign the "Customer" role
                if (existingUser == null)
                {
                    var newUser = new IdentityUser { UserName = email, Email = email };
                    var result = await userManager.CreateAsync(newUser);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newUser, "Customer");
                    }
                }
            }
        };
    });


builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chatHub");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
