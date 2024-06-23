using System;
using System.Collections.Generic;
using Fujitsu.ADO.NET.Models;

namespace Fujitsu.ADO.NET.Repositories
{
    public interface IBarangRepository
    {
        IEnumerable<Barang> GetAllBarang();
        void InsertBarang(Barang barang);
        Barang GetBarangById(int kode_barang);

        void UpdateBarang(Barang barang);
        void DeleteBarang(int kode_barang);
       IEnumerable<object> Monitoring(string namaGudang, DateTime? expiredDate);
    }
}

