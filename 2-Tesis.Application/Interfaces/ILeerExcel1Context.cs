using Microsoft.AspNetCore.Http;

namespace _2_Tesis.Application.Interfaces
{
    public interface ILeerExcel1Context
    {
        Task LeerExcel1(IFormFile formFile);
        Task LeerExcel2(IFormFile formFile);
        Task LeerExcel3(IFormFile formFile);
        Task LeerExcel4(IFormFile formFile);
    }
}
