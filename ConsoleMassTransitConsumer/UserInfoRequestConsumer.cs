using MassTransit;
using MassTransitContracts;

namespace ConsoleMassTransitConsumer
{
    internal class UserInfoRequestConsumer : IConsumer<IUserInfoRequest>
    {
        public async Task Consume(ConsumeContext<IUserInfoRequest> context)
        {
            var request = context.Message;
            Console.WriteLine($"Consuming IUserInfoRequest {context.Message.Id}...");
            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException("Id is empty");
            }

            var response = new UserInfoResponse()
            {
                Id = request.Id,
                Name = "Name from cunsumer"
            };


            await context.RespondAsync(response);
        }
    }
}
