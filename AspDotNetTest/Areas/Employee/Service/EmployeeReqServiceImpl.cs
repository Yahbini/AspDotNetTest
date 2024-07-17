using AspDotNetTest.Models;

namespace AspDotNetTest.Areas.Employee.Service;

public class EmployeeReqServiceImpl : EmployeeReqService
{
    private DatabaseContext dbContext;

    public EmployeeReqServiceImpl(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public bool Create(YeuCau request)
    {
        dbContext.YeuCaus.Add(request);
        return dbContext.SaveChanges() > 0;

    }

    public List<NhanVien> findAllEmpl()
    {
        return dbContext.NhanViens.ToList();
    }

    public List<YeuCau> findAllRequest()
    {
        return dbContext.YeuCaus.ToList();
    }

    public NhanVien findEmplByUsername(string username)
    {
        return dbContext.NhanViens.FirstOrDefault(u => u.Username == username);
    }

    public List<DoUuTien> findPriority()
    {
        return dbContext.DoUuTiens.ToList();
    }

    public YeuCau findRequestByID(int id)
    {
        return dbContext.YeuCaus.SingleOrDefault(r => r.Mayeucau == id);
    }

    public List<YeuCau> findRequestByUsername(string username)
    {
        return dbContext.YeuCaus.Where(r => r.ManvGui == username).ToList();
    }

    public bool UpdateEmployee(NhanVien employee)
    {
        dbContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return dbContext.SaveChanges() > 0;
    }
}
