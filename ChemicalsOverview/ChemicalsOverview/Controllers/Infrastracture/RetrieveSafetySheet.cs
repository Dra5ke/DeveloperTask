using ChemicalsOverview.Controllers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChemicalsOverview.Controllers.Infrastracture
{
    public class RetrieveSafetySheet
    {
        private readonly DbRepository _context;

        public RetrieveSafetySheet(DbRepository context)
        {
            _context = context;
        }

        public async Task<byte[]> ExecuteAsync(int id)
        {
            var chemical = _context.GetChemicalById(id);
            var client = new HttpClient();
            var wc = new System.Net.WebClient();

            try
            {
                await client.GetStringAsync(chemical.FirstOrDefault().Url); //test URL
            }
            catch (HttpRequestException e) //if the URL is not valid return "old" data from the BackupTable
            {
                var fromBackup = _context.GetBackupSheet(id);
                return fromBackup.FirstOrDefault().SafetySheet;
            }
            var response = wc.DownloadData(chemical.FirstOrDefault().Url); //if the URL works download the data, save it as a Backup and return it

            UpdateBackup(id, response); //check if the binary content changed and update the db

            return response;
        }

        private void UpdateBackup(int id, byte[] sheetData)
        {
            var newSheet = new Models.BackupSheet { ProductId = id, SafetySheet = sheetData };

            if (!_context.GetBackupSheet(id).Any())
            {
                _context.AddSheet(newSheet);
            }
            else
            {
                CheckContentChange.CompareAndUpdate(_context.GetBackupSheet(id).FirstOrDefault().SafetySheet, newSheet.SafetySheet, id, _context);
            }
        }
    }
}
