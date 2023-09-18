using MassTransit;
using MassTransitContracts;

namespace ConsoleMassTransitErrorConsumers
{
    internal class CreateUserFaultConsumer : IConsumer<Fault<ICreateUser>>
    {
        public async Task Consume(ConsumeContext<Fault<ICreateUser>> context)
        {
            Console.WriteLine(context.Message.Exceptions.First().Message);

            await context.ConsumeCompleted;
        }
    }
}
