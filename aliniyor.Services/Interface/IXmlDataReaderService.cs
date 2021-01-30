using aliniyor.Models.DTO;
using aliniyor.Models.Enum;
using aliniyor.Models.Response;
using aliniyor.Services.Paged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aliniyor.Services.Interface
{
    public interface IXmlDataReaderService
    {
        List<AddressInfoCity> XmlDateReaderFilterList(string cityName,string cityCode,string districtName,QueueTypeEnum queueType);
        PagedList<CityContentResponse> XmlDateReaderList(List<AddressInfoCity> addressInfoCities,int page,int size);
    }
}
