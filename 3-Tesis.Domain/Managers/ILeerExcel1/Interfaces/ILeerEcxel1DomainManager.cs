using Microsoft.AspNetCore.Http;

namespace _3_Tesis.Domain.Managers.ILeerExcel1.Interfaces
{
    public interface ILeerEcxel1DomainManager
    {
        Task LeerExcel1(IFormFile formFile);
    }
}
