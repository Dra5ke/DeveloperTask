using ChemicalsOverview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemicalsOverview.Controllers.Data
{
    public class DbRepository
    {
        private readonly ChemicalContext _context;

        public DbRepository(ChemicalContext context)
        {
            _context = context;
        }

        public IEnumerable<Chemical> GetAllChemicals()
        {
            return _context.Chemicals.OrderBy(c => c.ProductId).ToList();
        }

        public IQueryable<Chemical> GetChemicalById(int id)
        {
            return _context.Chemicals.Where(c => c.ProductId == id);
        }

        public IEnumerable<BackupSheet> GetAllBackupSheets()
        {
            return _context.BackupSheets.OrderBy(b => b.ProductId).ToList();
        }

        public IQueryable<BackupSheet> GetBackupSheet(int id)
        {
            return _context.BackupSheets.Where(b => b.ProductId == id);
        }

        public void AddSheet(BackupSheet sheet)
        {
            _context.BackupSheets.Add(sheet);
        }

        public void UpdateSheet(int id, byte[] newContent)
        {
            var backupSheet = _context.BackupSheets.FirstOrDefault(b => b.ProductId == id);

            if(backupSheet != null)
            {
                backupSheet.SafetySheet = newContent;
                _context.BackupSheets.Update(backupSheet);
                _context.SaveChanges();
            }
        }
    }
}
