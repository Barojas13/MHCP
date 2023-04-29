using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ICell = NPOI.SS.UserModel.ICell;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string excelFilePath = "C:\\Users\\Brayan Rojas\\Downloads";

                using var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read);
                var workbook = new XSSFWorkbook(stream);
                var sheet = workbook.GetSheetAt(0);
                var models = new List<T>();

                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);

                    if (row != null)
                    {
                        var model = Activator.CreateInstance<T>();

                        for (int j = 0; j < row.LastCellNum; j++)
                        {
                            var cell = row.GetCell(j);

                            if (cell != null)
                            {
                                var property = typeof(T).GetProperty($"Column{j + 1}");

                                if (property != null)
                                {

                                }
                            }
                        }

                        models.Add(model);
                    }
                }
            }
        }

        private object GetCellValue(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Numeric:
                    return cell.NumericCellValue;
                case CellType.String:
                    return cell.StringCellValue;
                default:
                    return null;
            }
        }
    }
}