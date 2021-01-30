using aliniyor.Models.DTO;
using aliniyor.Models.Enum;
using aliniyor.Services.Interface;
using aliniyor.Services.Paged;
using CsvHelper;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;

namespace aliniyor.Services
{
    public class ExcelDataReaderService : IExcelDataReaderService
    {
        public PagedList<CsvReaderDto> ExcelDateReaderFilterList(List<CsvReaderDto> csvReaderDtos, string cityName, string cityCode, string districtName, int page, int size, QueueTypeEnum queueType)
        {
            if (cityName != null || cityCode != null || districtName != null)
                csvReaderDtos = csvReaderDtos.Where(x => x.CityName == cityName || x.CityCode == cityCode || x.DistrictName == districtName).ToList();

            return queueType == QueueTypeEnum.DESC ?
                PagedList<CsvReaderDto>.ToPagedList(csvReaderDtos.OrderByDescending(x => x.CityName).ToList(),page,size) :
                PagedList<CsvReaderDto>.ToPagedList(csvReaderDtos,page,size);
        }

        public List<CsvReaderDto> ExcelDateReaderList()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CityMapping csvMapper = new CityMapping();
            CsvParser<CsvReaderDto> csvParser = new CsvParser<CsvReaderDto>(csvParserOptions, csvMapper);
            var result = csvParser
                         .ReadFromFile(@"./Data/sample_data.csv", Encoding.ASCII)
                         .ToList();

            var csvReaderDtos = new List<CsvReaderDto>();

            foreach (var item in result)
                csvReaderDtos.Add(item.Result);


            return csvReaderDtos;
        }
    }
}