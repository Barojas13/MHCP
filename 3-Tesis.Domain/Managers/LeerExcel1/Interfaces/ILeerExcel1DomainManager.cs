using Microsoft.AspNetCore.Http;

namespace _3_Tesis.Domain.Managers.LeerExcel1.Interfaces
{
    public interface ILeerExcel1DomainManager
    {
        Task LeerExcel1(IFormFile formFile);
        Task LeerExcel2(IFormFile formFile);
        Task LeerExcel3(IFormFile formFile);
        Task LeerExcel4(IFormFile formFile);
    }
}
