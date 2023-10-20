Client user1 = new User();

Console.WriteLine(user1.GetDescription());

ConcreteBadge newClient = new ConcreteBadge(user1, "3 stars");

Console.WriteLine(newClient.GetDescription());




public abstract class Client 
{ 
    public string Username { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }

    public Client() 
    {
        Description = "No Description";
    }

    public virtual string GetDescription() 
    {
        return Description;
    }
}


public class User : Client
{
    public User()
    {
        Description = "Base-lever User";
    }
}

public abstract class BadgeDecorator : Client
{
    public Client clientDecorator { get; set; }

    public string Badge { get; set; }

    public abstract override string GetDescription();
    public abstract string GetBadges();

    public BadgeDecorator(Client client)
    {
        clientDecorator = client;
    }
}

public class ConcreteBadge : BadgeDecorator 
{
    public ConcreteBadge(Client client, string badge) : base(client)
    {
       // clientDecorator = client;
        Badge = badge;
        Description = "Decorator level user";
    }

    public override string GetBadges()
    {
        return Badge;
    }
    public override string GetDescription() 
    {
        return $"{Description}, {Badge}";
    }

}