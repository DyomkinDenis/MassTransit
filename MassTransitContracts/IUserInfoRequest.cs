namespace MassTransitContracts;
public interface IUserInfoRequest
{
    public Guid Id { get; set; }
}

public class UserInfoRequest : IUserInfoRequest
{
    public Guid Id { get; set; }
}

public interface IUserInfoResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class UserInfoResponse : IUserInfoResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}