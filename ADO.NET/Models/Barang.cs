using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fujitsu.ADO.NET.Models
{
    public class Barang
    {
        [Key]
        public int Kode_Barang { get; set; }

        [Required(ErrorMessage = "Nama barang tidak boleh kosong")]
        [Column(TypeName = "varchar(100)")]
        public string Nama_Barang { get; set; }

        [Required(ErrorMessage = "Harga barang tidak boleh kosong")]
        public int Harga_Barang { get; set; }

        [Required(ErrorMessage = "Jumlah barang tidak boleh kosong")]
        public int Jumlah_Barang { get; set; }

        [Required(ErrorMessage = "Tanggal kedaluwarsa tidak boleh kosong")]
        public DateTime Expired_Barang { get; set; }

        public int? Kode_Gudang_ID { get; set; }
    }
}
