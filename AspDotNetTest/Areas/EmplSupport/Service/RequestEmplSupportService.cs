using AspDotNetTest.Models;

namespace AspDotNetTest.Areas.EmplSupport.Service;

public interface RequestEmplSupportService
{
    public List<YeuCau> findReqByEmployee(string username);
}
