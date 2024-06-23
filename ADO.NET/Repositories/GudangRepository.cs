using System;
using System.Collections.Generic;
using System.Linq;
using Fujitsu.ADO.NET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Fujitsu.ADO.NET.Repositories
{
    public class GudangRepository : IGudangRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<GudangRepository> _logger;

        public GudangRepository(AppDbContext appDbContext, ILogger<GudangRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public IEnumerable<Gudang> FindAll()
        {
            return _appDbContext.Gudangs.ToList();
        }

        public Gudang FindById(int kode_gudang)
        {
            return _appDbContext.Gudangs.Find(kode_gudang);
        }

        public void InsertGudang(Gudang gudang)
        {
            try
            {
                _appDbContext.Gudangs.Add(gudang);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving Gudang");
                throw;
            }
        }

        public void UpdateGudang(Gudang gudang)
        {
            _appDbContext.Gudangs.Update(gudang);
            _appDbContext.SaveChanges();
        }

        public void DeleteGudang(int kode_gudang)
        {
            var gudang = _appDbContext.Gudangs.Find(kode_gudang);
            if (gudang != null)
            {
                _appDbContext.Gudangs.Remove(gudang);
                _appDbContext.SaveChanges();
            }
        }
    }
}
