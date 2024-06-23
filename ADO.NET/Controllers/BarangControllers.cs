using Fujitsu.ADO.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Fujitsu.ADO.NET.Repositories;

namespace Fujitsu.ADO.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IBarangRepository _barangRepository;

        public BarangController(AppDbContext dbContext, IBarangRepository barangRepository)
        {
            _dbContext = dbContext;
            _barangRepository = barangRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Barang>> Get()
        {
            var barangs = _dbContext.Barangs.ToList();
            return Ok(barangs);
        }

        [HttpGet("{kode_barang}")]
        public ActionResult<Barang> Get(int kode_barang)
        {
            var barang = _dbContext.Barangs.Find(kode_barang);
            if (barang == null)
            {
                return NotFound();
            }
            return Ok(barang);
        }

[HttpPost]
public ActionResult Post([FromBody] Barang barang)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    // Tidak perlu memeriksa keberadaan gudang di sini karena Kode_Gudang_ID boleh null
    _dbContext.Barangs.Add(barang);
    _dbContext.SaveChanges();

    return CreatedAtAction(nameof(Get), new { kode_barang = barang.Kode_Barang }, barang);
}


[HttpPut("{kode_barang}")]
public ActionResult Put(int kode_barang, [FromBody] Barang barang)
{
    if (kode_barang != barang.Kode_Barang)
    {
        return BadRequest();
    }

    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    // Misalnya, tidak ada validasi untuk Gudang di sini

    _dbContext.Entry(barang).State = EntityState.Modified;
    _dbContext.SaveChanges();

    return NoContent();
}

        [HttpDelete("{kode_barang}")]
        public ActionResult Delete(int kode_barang)
        {
            var barang = _dbContext.Barangs.Find(kode_barang);
            if (barang == null)
            {
                return NotFound();
            }

            _dbContext.Barangs.Remove(barang);
            _dbContext.SaveChanges();

            return NoContent();
        }

[HttpGet("monitoring")]
public ActionResult<IEnumerable<object>> Monitoring()
{
    var query = from barang in _dbContext.Barangs
                join gudang in _dbContext.Gudangs on barang.Kode_Gudang_ID equals gudang.Kode_Gudang into gj
                from subgudang in gj.DefaultIfEmpty()
                select new
                {
                    Kode_Barang = barang.Kode_Barang,
                    Nama_Barang = barang.Nama_Barang,
                    Expired_Barang = barang.Expired_Barang,
                    Nama_Gudang = subgudang != null ? subgudang.Nama_Gudang : "Tanpa Gudang"
                };

    var barangs = query.OrderBy(b => b.Expired_Barang).ToList();
    return Ok(barangs);
}



    }
}
