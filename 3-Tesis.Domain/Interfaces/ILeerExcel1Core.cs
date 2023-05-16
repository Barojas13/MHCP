using Microsoft.AspNetCore.Http;

namespace _3_Tesis.Domain.Interfaces
{
    public interface ILeerExcel1Core
    {
        Task LeerExcel1(IFormFile formFile);
        Task LeerExcel2(IFormFile formFile);
        Task LeerExcel3(IFormFile formFile);
        Task LeerExcel4(IFormFile formFile);
    }
}
