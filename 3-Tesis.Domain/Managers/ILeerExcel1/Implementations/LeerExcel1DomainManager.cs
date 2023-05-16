using _3_Tesis.Domain.Implementations;
using _3_Tesis.Domain.Interfaces;
using _3_Tesis.Domain.Managers.ILeerExcel1.Interfaces;
using Microsoft.AspNetCore.Http;

namespace _3_Tesis.Domain.Managers.ILeerExcel1.Implementations
{
    public class LeerExcel1DomainManager : ILeerEcxel1DomainManager
    {
        private static ILeerExcel1Core _leerExcel1Core; 

        public static ILeerExcel1Core LeerExcel1Core
        {
            get
            {
                if (_leerExcel1Core == null)
                {
                    _leerExcel1Core = new LeerExcel1Core();
                }
                return _leerExcel1Core;
            }
            set { _leerExcel1Core = value; }
        }

        public async Task LeerExcel1(IFormFile formFile)
        {
            await _leerExcel1Core.LeerExcel1(formFile);
        }
    }
}
