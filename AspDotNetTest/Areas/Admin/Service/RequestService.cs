using AspDotNetTest.Models;

namespace AspDotNetTest.Areas.Admin.Service;

public interface RequestService
{
    public List<YeuCau> findAll();

    public YeuCau findById(int id);
    public bool UpdateRequest(YeuCau yuCau);
    public List<YeuCau> findReqByUsername(string employeeUsername);
}
