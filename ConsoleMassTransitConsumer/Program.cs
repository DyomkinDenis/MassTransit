using ConsoleMassTransitConsumer;
using MassTransit;
using Microsoft.Extensions.Hosting;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "massTransitExamples", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.UseMessageRetry(config =>
                {
                    config.Handle<TimeoutException>();
                    config.Incremental(5, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1));
                });
                cfg.ConfigureEndpoints(context);
            });
            x.AddConsumer<UserInfoRequestConsumer>();
            x.AddConsumer<CreateUserConsumer>();

        });
    });

host.RunConsoleAsync().Wait();
