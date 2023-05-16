using _2_Tesis.Application.Implementations;
using _2_Tesis.Application.Interfaces;
using _2_Tesis.Application.Managers.LeerExcel1.Interfaces;
using Microsoft.AspNetCore.Http;

namespace _2_Tesis.Application.Managers.LeerExcel1.Implementations
{
    public class LeerExcel1ContextManager : ILeerExcel1ContextManager
    {
        private static ILeerExcel1Context _leerExcel1Context;

        public LeerExcel1ContextManager()
        {
        }

        public static ILeerExcel1Context LeerExcel1Context
        {
            get
            {
                if (_leerExcel1Context == null)
                {
                    _leerExcel1Context = new LeerExcel1Context();
                }
                return _leerExcel1Context;
            }
            set { _leerExcel1Context = value; }
        }

        public async Task LeerExcel1(IFormFile formFile)
        {
            await LeerExcel1Context.LeerExcel1(formFile);
        }

        public async Task LeerExcel2(IFormFile formFile)
        {
            await LeerExcel1Context.LeerExcel2(formFile);
        }

        public async Task LeerExcel3(IFormFile formFile)
        {
            await LeerExcel1Context.LeerExcel3(formFile);
        }

        public async Task LeerExcel4(IFormFile formFile)
        {
            await LeerExcel1Context.LeerExcel4(formFile);
        }
    }
}
