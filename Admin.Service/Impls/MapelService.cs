using Admin.Common.Commands;
using Admin.Common.Dtos;
using Admin.Repository;
using Admin.Repository.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Service.Impls
{
    public class MapelService : IMapelService
    {
        private readonly IMapelDao mapelDao;
        private readonly IMapper mapper;

        public MapelService(IMapelDao mapelDao, IMapper mapper)
        {
            this.mapelDao = mapelDao;
            this.mapper = mapper;
        }

        public int AddMapel(AddMapel command)
        {
            mapel mapel = mapper.Map<mapel>(command);
            mapel = mapelDao.Save(mapel);

            return mapel.Id;
        }

        public void DeleteNilai(int id)
        {
            
            mapelDao.Delete(id);
        }

        public MapelDto GetNilaiById(int id)
        {
            var mapel = mapelDao.Get(id);
            MapelDto dto = mapper.Map<MapelDto>(mapel);

            return dto;
        }

        public MapelDto GetNilaiByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateNilaiData(int id, AddMapel command)
        {
            
            mapelDao.Delete(id);

            mapel mapel1 = mapper.Map<mapel>(command);
            mapel1 = mapelDao.Save(mapel1);
        }
    }
}
