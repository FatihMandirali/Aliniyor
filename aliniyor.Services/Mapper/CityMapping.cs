using aliniyor.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace aliniyor.Services
{
    public class CityMapping : CsvMapping<CsvReaderDto>
    {
        public CityMapping()
            : base()
        {
            MapProperty(0, x => x.CityName);
            MapProperty(1, x => x.CityCode);
            MapProperty(2, x => x.DistrictName);
            MapProperty(3, x => x.ZipCode);
        }
    }
}
