using System;
using System.Collections.Generic;
using System.Text;
using Admin.Common.Commands;
using Admin.Common.Dtos;

namespace Admin.Service
{
    public interface IMapelService
    {
        int AddMapel(AddMapel command);
        MapelDto GetNilaiById(int id);
        MapelDto GetNilaiByName(string name);
        void DeleteNilai(int id);
        void UpdateNilaiData(int id, AddMapel command);
    }
}
