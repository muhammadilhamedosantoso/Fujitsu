// IGudangRepository.cs
using System.Collections.Generic;
using Fujitsu.ADO.NET.Models;

namespace Fujitsu.ADO.NET.Repositories
{
    public interface IGudangRepository
    {
        IEnumerable<Gudang> FindAll();
        Gudang FindById(int kode_gudang);
        void InsertGudang(Gudang gudang);
        void UpdateGudang(Gudang gudang);
        void DeleteGudang(int kode_gudang);
    }
}
