using PhoneEdit.Data;

namespace PhoneEdit.Services;

public class DefaultUserService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public DefaultUserService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var services = scope.ServiceProvider;
            var serviceProvider = services.GetRequiredService<IServiceProvider>();

            // Создание дефолтного пользователя
            await SampleData.CreateDefaultUser(serviceProvider);
        }
    }
}