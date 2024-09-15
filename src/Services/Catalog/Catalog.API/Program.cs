namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCarter();
            builder.Services.AddMediatR
             (config => { config.RegisterServicesFromAssembly(typeof(Program).Assembly); });
            builder.Services.AddMarten(config => 
            config.Connection(builder.Configuration.GetConnectionString("Database")!)
            ).UseLightweightSessions();
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.MapCarter();
      
            app.Run();
        }
    }
}
