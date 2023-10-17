User newUser = new User(21, true);
Admin newAdmin = new Admin(true);
Manager newManager = new Manager(false);

newUser.ValidationOfAccess();
newAdmin.ValidationOfAccess();
newManager.ValidationOfAccess();

public abstract class Client 
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public bool AccessDisabled { get; set; }

    protected IAccessHandler _accessHandler;
    public virtual bool HandleAccess()
    {
        return _accessHandler.GetAccess(accessDisabled:AccessDisabled);
    }

    public void ValidationOfAccess()
    {
        Console.WriteLine($"Client has access : {HandleAccess()}");
    }
}

public class User : Client
{
    public int Reputation { get; set; }
    public User(int reputation, bool accessIsValid)
    {
        Reputation = reputation;
        AccessDisabled = accessIsValid;
        _accessHandler = new HasReputation();
    }
    public override bool HandleAccess()
    {
        return _accessHandler.GetAccess(reputation:Reputation);
    }
}

public class Manager : Client
{
    public Manager(bool accessIsValid)
    {
        AccessDisabled = accessIsValid;
        _accessHandler = new HasAccessAutomatic();
    }
}

public class Admin : Client
{
    public Admin(bool accessIsValid)
    {
        AccessDisabled = accessIsValid;
        _accessHandler = new HasAccessAutomatic();
    }
}

public interface IAccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false);
}

public class HasReputation : IAccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false)
    {
        return (reputation > 20);
    }
}

public class HasAccessAutomatic : IAccessHandler
{
    public bool GetAccess(int? reputation = 0, bool accessDisabled = false)
    {
        return (!accessDisabled);
    }
}

