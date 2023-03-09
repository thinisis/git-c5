using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemThuTuDong
{
    internal class ExcelData
    {

        public static List<Account> ExcelDataToList(string url)
        {
            // If you are using the Professional version, enter your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = ExcelFile.Load(url);

            // Select the first worksheet from the file.
            var worksheet = workbook.Worksheets[0];

            // Create DataTable from an Excel worksheet.
            var dataTable = worksheet.CreateDataTable(new CreateDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 1,
                StartColumn = 2,
                NumberOfColumns = 2,
                NumberOfRows = worksheet.Rows.Count - 1,
                Resolution = ColumnTypeResolution.AutoPreferStringCurrentCulture
            });
            List<Account> accountList = new List<Account>();
            // Write DataTable content
            foreach (DataRow row in dataTable.Rows)
            {
                Account account = new Account();
                account.username = row[0].ToString();
                account.password = row[1].ToString();
                accountList.Add(account);
            }
            return accountList;
        }
    }
}
