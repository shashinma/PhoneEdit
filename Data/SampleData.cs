using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PhoneEdit.Data;

public class SampleData
{
    private readonly DefaultUserOptions _options;

    public SampleData(IOptions<DefaultUserOptions> optionsAccessor)
    {
        _options = optionsAccessor.Value;
    }

    public static async Task CreateDefaultUser(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var optionsAccessor = serviceProvider.GetRequiredService<IOptions<DefaultUserOptions>>();
        var options = optionsAccessor.Value;

        var userCheck = await userManager.Users.AnyAsync();
        if (!userCheck)
        {
            var adminUser = new IdentityUser()
            {
                UserName = options.Username,
                Email = options.Username,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, options.Password ?? throw new InvalidOperationException());
        }
    }
}

public class DefaultUserOptions
{
    public string Username { get; set; }
    public string Password { get; set; }
}