using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PhoneEdit.Data;

var builder = WebApplication.CreateBuilder(args);

try
{
    var identityContextSecrets = builder.Configuration.GetConnectionString("IdentityContext") ?? 
                                 throw new InvalidOperationException("Connection string 'IdentityContext' not found.");
    var phoneBookContextSecrets = builder.Configuration.GetConnectionString("PhoneBookContext") ?? 
                                  throw new InvalidOperationException("Connection string 'PhoneBookContext' not found.");
        
    builder.Services.AddDbContext<ApplicationDbContext>(options => 
        options.UseSqlite(identityContextSecrets));
    
    builder.Services.AddDbContext<PhonebookContext>(options => 
        options.UseMySql(phoneBookContextSecrets, ServerVersion.AutoDetect(phoneBookContextSecrets))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
        );
}
catch (MySqlException ex)
{
    throw new InvalidOperationException("Error: ", ex);
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 3;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
    app.UseDatabaseErrorPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PhoneBook}/{action=Index}/{id?}");

app.MapRazorPages();

// Apply migrations if there are any pending
using (var scope = app.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var pendingAppDbContextMigrations = appDbContext.Database.GetPendingMigrations().ToList();

    if (pendingAppDbContextMigrations.Count > 0)
    {
        appDbContext.Database.Migrate();
    }
}

var serviceProvider = builder.Services.BuildServiceProvider();
await SampleData.CreateDefaultUser(serviceProvider);

app.Run();