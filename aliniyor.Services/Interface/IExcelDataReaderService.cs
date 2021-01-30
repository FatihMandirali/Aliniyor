using aliniyor.Models.DTO;
using aliniyor.Models.Enum;
using aliniyor.Services.Paged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aliniyor.Services.Interface
{
    public interface IExcelDataReaderService
    {
        List<CsvReaderDto> ExcelDateReaderList();
        PagedList<CsvReaderDto> ExcelDateReaderFilterList(List<CsvReaderDto> csvReaderDtos,string cityName, string cityCode, string districtName,int page,int size,QueueTypeEnum queueType);

    }
}
