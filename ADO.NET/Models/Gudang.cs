using System.ComponentModel.DataAnnotations;

namespace Fujitsu.ADO.NET.Models
{
    public class Gudang
    {
        [Key]
        public int Kode_Gudang { get; set; }

        [Required(ErrorMessage = "Warehouse name cannot be empty")]
        public string Nama_Gudang { get; set; }
    }
}
