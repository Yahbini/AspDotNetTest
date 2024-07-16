using AspDotNetTest.Models;

namespace AspDotNetTest.Areas.Admin.Service;

public class RequestServiceImpl : RequestService
{
    private DatabaseContext dbContext;

    public RequestServiceImpl(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public List<YeuCau> findAll()
    {
        return dbContext.YeuCaus.ToList();
    }

    public YeuCau findById(int id)
    {
        return dbContext.YeuCaus.FirstOrDefault(r => r.Mayeucau == id);
    }

    public List<YeuCau> findReqByUsername(string employeeUsername)
    {
        return dbContext.YeuCaus.Where(y => y.ManvGui == employeeUsername).ToList();
    }

    public bool UpdateRequest(YeuCau yeuCau)
    {
        dbContext.Entry(yeuCau).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return dbContext.SaveChanges() > 0;
    }
}
