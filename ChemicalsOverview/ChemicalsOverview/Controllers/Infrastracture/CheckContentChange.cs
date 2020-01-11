using ChemicalsOverview.Controllers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChemicalsOverview.Controllers.Infrastracture
{
    public class CheckContentChange
    {
        private readonly DbRepository _context;
        public static void CompareAndUpdate(byte[] oldSheet, byte[] newSheet, int sheetId, DbRepository context)
        {
            if (!oldSheet.Equals(newSheet)) //compare binary content
            {
                context.UpdateSheet(sheetId, newSheet); //If they differ set backup to the new one
            }
        }

        public CheckContentChange(DbRepository context)
        {
            _context = context;
        }

        public async void Execute()
        {
            var sheets = _context.GetAllBackupSheets();
            var client = new HttpClient();
            var wc = new System.Net.WebClient();

            foreach(var sheet in sheets)
            {
                var currentSheetUrl = _context.GetChemicalById(sheet.ProductId).FirstOrDefault().Url;
                try
                {
                    await client.GetStringAsync(currentSheetUrl); //test URL
                }
                catch (HttpRequestException e) //skip if Url not valid
                {
                    continue;
                }

                var response = wc.DownloadData(currentSheetUrl);

                CompareAndUpdate(sheet.SafetySheet, response, sheet.ProductId, _context);
              
            }
            
        }
    }
}
