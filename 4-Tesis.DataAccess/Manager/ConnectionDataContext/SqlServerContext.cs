using _4_Tesis.DataAccess.DataBaseObjects;

namespace _4_Tesis.DataAccess.Manager.ConnectionDataContext
{
    public class SqlServerContext
    {
        private static SqlServerContext _sqlServerContextInstance = null;

        private static ETLCRMContext _eTLCRMContext;

        public static SqlServerContext SqlServerContextInstance
        {
            get
            {
                if (_sqlServerContextInstance == null)
                {
                    _sqlServerContextInstance = new SqlServerContext();
                }

                return _sqlServerContextInstance;
            }
        }

        public static ETLCRMContext ETLCRMContext
        {
            get
            {
                if (_eTLCRMContext == null)
                {
                    _eTLCRMContext = new ETLCRMContext();
                }
                return _eTLCRMContext;
            }
            set { _eTLCRMContext = value; }
        }
    }
}
