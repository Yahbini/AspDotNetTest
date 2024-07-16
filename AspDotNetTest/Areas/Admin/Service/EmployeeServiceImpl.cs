using AspDotNetTest.Models;
using System.Diagnostics;

namespace AspDotNetTest.Areas.Admin.Service;

public class EmployeeServiceImpl : EmployeeService
{
    private DatabaseContext dbContext;
    private IWebHostEnvironment webHostEnvironment;

    public EmployeeServiceImpl(DatabaseContext dbContext, IWebHostEnvironment webHostEnvironment)
    {
        this.dbContext = dbContext;
        this.webHostEnvironment = webHostEnvironment;
    }

    public bool Create(NhanVien nhanVien, IFormFile file)
    {
        try
        {
            // nhanVien.Password = BCrypt.Net.BCrypt.HashPassword(nhanVien.Password);
            dbContext.NhanViens.Add(nhanVien);
            return dbContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.Write("Lỗi: " + ex.InnerException?.Message);
            return false;
        }
    }

    public List<NhanVien> findAll()
    {
        return dbContext.NhanViens.ToList();
    }

    public NhanVien GetEmployeeByUsername(string username)
    {
        return dbContext.NhanViens.FirstOrDefault(u => u.Username == username);
    }
}
