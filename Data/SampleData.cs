using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PhoneEdit.Data;

public class SampleData
{
    private static IConfiguration _configuration;

    public SampleData(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    // Creates default app's admin
    public static async Task CreateDefaultUser(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        
        var defaultUsername = configuration.GetValue<string>("DefaultUsername");
        var defaultPassword = configuration.GetValue<string>("DefaultPassword");

        var userCheck = await userManager.Users.AnyAsync();
        if (!userCheck)
        {
            var adminUser = new IdentityUser()
            {
                UserName = Environment.GetEnvironmentVariable("USERNAME") ?? defaultUsername,
                Email = Environment.GetEnvironmentVariable("USERNAME") ?? defaultUsername,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, (Environment.GetEnvironmentVariable("PASSWORD") ?? defaultPassword) ?? throw new InvalidOperationException());
        }
    }
}
