using _2_Tesis.Application.Interfaces;
using _3_Tesis.Domain.DesingContext;
using Microsoft.AspNetCore.Http;

namespace _2_Tesis.Application.Implementations
{
    public class LeerExcel1Context : ILeerExcel1Context
    {
        public async Task LeerExcel1(IFormFile formFile)
        {
            await FactoryDomain.LeerExcel1DomainManager.LeerExcel1(formFile);
        }

        public async Task LeerExcel2(IFormFile formFile)
        {
            await FactoryDomain.LeerExcel1DomainManager.LeerExcel2(formFile);
        }

        public async Task LeerExcel3(IFormFile formFile)
        {
            await FactoryDomain.LeerExcel1DomainManager.LeerExcel3(formFile);
        }

        public async Task LeerExcel4(IFormFile formFile)
        {
            await FactoryDomain.LeerExcel1DomainManager.LeerExcel4(formFile);
        }
    }
}
