using aliniyor.Models.DTO;
using aliniyor.Models.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aliniyor.Mapper
{
    public class CitiesMapper : Profile
    {
        public CitiesMapper()
        {
            CreateMap<CsvReaderDto, CityContentResponse>();
        }
    }
}

