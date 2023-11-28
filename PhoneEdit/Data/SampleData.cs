using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PhoneEdit.Data;

public static class SampleData
{
    // Creates default app's admin
    public static async Task CreateDefaultUser(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var userCheck = await userManager.Users.AnyAsync();
        if (!userCheck)
        {
            var adminUser = new IdentityUser()
            {
                UserName = "mail@example.com",
                Email = "mail@example.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, "123456");
        }
    }
}
