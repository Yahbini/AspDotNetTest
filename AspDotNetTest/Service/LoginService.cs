using AspDotNetTest.Models;

namespace AspDotNetTest.Service;

public interface LoginService
{
    public NhanVien Login(string username, string password);
}
