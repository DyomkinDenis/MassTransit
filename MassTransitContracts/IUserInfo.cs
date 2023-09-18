namespace MassTransitContracts;


public interface ICreateUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int RetryCount { get; set; }
}

public class CreateUser : ICreateUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int RetryCount { get; set; }

}
