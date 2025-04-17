using KandaIdea_Task.Infrastructure.Data;

namespace KandaIdea_Task.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task UseDatabaseSeederAsync (this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope ();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext> ();
            await DataSeeder.EnsureSeededAsync (context);
        }
    }
}
