using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChemicalsOverview.Models
{
    public class BackupSheet
    {
        public byte[] SafetySheet { get; set; }
        [Key]
        public int ProductId { get; set; }
    }
}
