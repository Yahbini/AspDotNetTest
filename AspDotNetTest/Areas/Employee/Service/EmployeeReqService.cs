using AspDotNetTest.Models;

namespace AspDotNetTest.Areas.Employee.Service;

public interface EmployeeReqService
{
    public List<NhanVien> findAllEmpl();
    public List<DoUuTien> findPriority();
    public List<YeuCau> findAllRequest();

    public bool Create(YeuCau request);
    public NhanVien findEmplByUsername(string username);
    public bool UpdateEmployee(NhanVien employee);
    public YeuCau findRequestByID(int id);
    public List<YeuCau> findRequestByUsername(string username);
}
