SecuritySystem newSecuritySystem = new SecuritySystem();

User newAdministrator = newSecuritySystem.AuthenticationMethod(true, true);
newAdministrator.PasswordHash();

User newAuthorizedUser = newSecuritySystem.AuthenticationMethod(true, false);
newAuthorizedUser.PasswordHash();

User newUserWithoutTwoFactorAuthentication = newSecuritySystem.AuthenticationMethod(false, true);
newUserWithoutTwoFactorAuthentication.PasswordHash();

//User newUserException = newSecuritySystem.AuthenticationMethod(false, false);

// factory class
public class SecuritySystem
{
    // create product (user)
    public User AuthenticationMethod(bool twoFactorRequired, bool isAdmin)
    {
        User user;

        if (twoFactorRequired)
        {
            if (isAdmin)
            {
                user = new Administrator();
            }
            else
            {
                user = new AuthorizedUser();
            }

            return user;
        }
        else
        {
            if (isAdmin)
            {
                return new Administrator();
            }
            else
            {
                throw new Exception("two factor authentication is false");
            }
        }
    }
}

// abstract class + concrete classes
public abstract class User
{
    public string StoredPassword;
    public abstract void PasswordHash();
}

//concrete class
public class Administrator : User
{
    public override void PasswordHash()
    {
        Console.WriteLine("PasswordHash for Administrator User");
    }
}

public class AuthorizedUser : User
{
    public override void PasswordHash()
    {
        Console.WriteLine("PasswordHash for Authorized User");
    }
}
