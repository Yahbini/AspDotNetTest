using AspDotNetTest.Models;

namespace AspDotNetTest.Areas.Admin.Service;

public interface EmployeeService
{
    public bool Create(NhanVien nhanVien, IFormFile file);
    public List<NhanVien> findAll();
    public NhanVien GetEmployeeByUsername(string username);
    public bool IsEmplExist(string username);

}
