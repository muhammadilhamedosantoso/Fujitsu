using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fujitsu.ADO.NET.Models;
using Fujitsu.ADO.NET.Repositories;

namespace Fujitsu.ADO.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GudangController : ControllerBase
    {
        private readonly IGudangRepository _gudangRepository;

        public GudangController(IGudangRepository gudangRepository)
        {
            _gudangRepository = gudangRepository;
        }

        // GET: api/gudang
        [HttpGet]
        public IEnumerable<Gudang> Get()
        {
            return _gudangRepository.FindAll();
        }

        // GET: api/gudang/5
        [HttpGet("{kode_gudang}")]
        public ActionResult<Gudang> Get(int kode_gudang)
        {
            var gudang = _gudangRepository.FindById(kode_gudang);

            if (gudang == null)
            {
                return NotFound();
            }

            return gudang;
        }

        // POST: api/gudang
        [HttpPost]
        public ActionResult<Gudang> Post(Gudang gudang)
        {
            try
            {
                _gudangRepository.InsertGudang(gudang);
                return CreatedAtAction(nameof(Get), new { kode_gudang = gudang.Kode_Gudang }, gudang);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/gudang/1
        [HttpPut("{kode_gudang}")]
        public IActionResult Put(int kode_gudang, Gudang gudang)
        {
            if (kode_gudang != gudang.Kode_Gudang)
            {
                return BadRequest("Kode Gudang tidak sesuai");
            }

            try
            {
                _gudangRepository.UpdateGudang(gudang);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/gudang/1
        [HttpDelete("{kode_gudang}")]
        public IActionResult Delete(int kode_gudang)
        {
            try
            {
                _gudangRepository.DeleteGudang(kode_gudang);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
