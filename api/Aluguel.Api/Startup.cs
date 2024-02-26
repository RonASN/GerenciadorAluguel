using GerenciadorAluguel.Database.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace Aluguel.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<GerenciadorAluguelDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("GerenciadorAluguelDbConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseRouting();

        app.UseEndpoints(config => config.MapControllers());
    }
}
