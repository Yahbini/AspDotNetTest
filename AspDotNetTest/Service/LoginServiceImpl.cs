using AspDotNetTest.Models;

namespace AspDotNetTest.Service;

public class LoginServiceImpl : LoginService
{
    private DatabaseContext dbContext;

    public LoginServiceImpl(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public NhanVien Login(string username, string password)
    {
        var account = dbContext.NhanViens.SingleOrDefault(a => a.Username == username && a.Kichhoat == true);

        if (account != null)
        {
            if (BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                return account;
            }
        }

        return null;
    }
}
