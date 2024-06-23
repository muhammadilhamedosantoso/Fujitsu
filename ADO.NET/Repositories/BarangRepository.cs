using Fujitsu.ADO.NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fujitsu.ADO.NET.Repositories
{
    public class BarangRepository : IBarangRepository
    {
        private readonly AppDbContext _appDbContext;

        public BarangRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Barang> GetAllBarang()
        {
            return _appDbContext.Barangs.ToList();
        }

        public void InsertBarang(Barang barang)
        {
            try
            {
                _appDbContext.Barangs.Add(barang);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to insert Barang", ex);
            }
        }

        public Barang GetBarangById(int kode_barang)
        {
            return _appDbContext.Barangs.Find(kode_barang);
        }

        public void UpdateBarang(Barang barang)
        {
            _appDbContext.Barangs.Update(barang);
            _appDbContext.SaveChanges();
        }

        public void DeleteBarang(int kode_barang)
        {
            var barang = _appDbContext.Barangs.Find(kode_barang);
            if (barang != null)
            {
                _appDbContext.Barangs.Remove(barang);
                _appDbContext.SaveChanges();
            }
        }

                public IEnumerable<object> Monitoring(string namaGudang, DateTime? expiredDate)
        {
            var query = from barang in _appDbContext.Barangs
                        join gudang in _appDbContext.Gudangs on barang.Kode_Gudang_ID equals gudang.Kode_Gudang into gj
                        from subgudang in gj.DefaultIfEmpty()
                        select new
                        {
                            Nama_Barang = barang.Nama_Barang,
                            Expired_Barang = barang.Expired_Barang,
                            Nama_Gudang = subgudang != null ? subgudang.Nama_Gudang : "Tanpa Gudang"
                        };

            if (!string.IsNullOrEmpty(namaGudang))
            {
                query = query.Where(b => b.Nama_Gudang.ToLower() == namaGudang.ToLower());
            }

            if (expiredDate.HasValue)
            {
                query = query.Where(b => b.Expired_Barang.Date <= expiredDate.Value.Date);
            }

            return query.ToList();
        }

    }
}
