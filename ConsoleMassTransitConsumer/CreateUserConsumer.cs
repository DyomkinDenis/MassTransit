using MassTransit;
using MassTransitContracts;

namespace ConsoleMassTransitConsumer
{
    internal class CreateUserConsumer : IConsumer<ICreateUser>
    {

        public Task Consume(ConsumeContext<ICreateUser> context)
        {

            Console.WriteLine($"Consuming... {context.Message.Id}...{context.Message.Name}..");

            var r = new Random().Next(2);
            if(r == 0)
            {
            throw new TimeoutException();

            }
            else
            {
                throw new ArgumentNullException();
            }
            return Task.CompletedTask;
        }
    }
}
