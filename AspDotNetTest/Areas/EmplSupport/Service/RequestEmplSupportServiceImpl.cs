using AspDotNetTest.Models;

namespace AspDotNetTest.Areas.EmplSupport.Service;

public class RequestEmplSupportServiceImpl : RequestEmplSupportService
{
    private DatabaseContext databaseContext;

    public RequestEmplSupportServiceImpl(DatabaseContext databaseContext)
    {
        this.databaseContext = databaseContext;
    }

    public List<YeuCau> findReqByEmployee(string username)
    {
        return databaseContext.YeuCaus.Where(r => r.ManvXuly == username).ToList();
    }
}
