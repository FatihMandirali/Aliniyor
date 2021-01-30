using aliniyor.Models.DTO;
using aliniyor.Models.Enum;
using aliniyor.Models.Response;
using aliniyor.Services.Interface;
using aliniyor.Services.Paged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace aliniyor.Services
{
    public class XmlDataReaderService : IXmlDataReaderService
    {
        public List<AddressInfoCity> XmlDateReaderFilterList(string cityName, string cityCode, string districtName, QueueTypeEnum queueType)
        {
            using (var fileStream = File.Open(@"./Data/sample_data.xml", FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AddressInfo));
                var addressInfo = (AddressInfo)serializer.Deserialize(fileStream);

                var citys = addressInfo.City.ToList();


                var addressInfoCities = new List<AddressInfoCity>();

                if (districtName != null)
                    foreach (var item in citys)
                    {
                        if (item.District.Where(x => x.name == districtName).ToList().Count > 0)
                            addressInfoCities.Add(item);
                    }

                if (cityName != null || cityCode != null)
                {
                    citys = citys.Where(x => x.name == cityName || x.code == cityCode).ToList();
                    citys.AddRange(addressInfoCities);
                }

                citys = addressInfoCities;



                citys = queueType == QueueTypeEnum.ASC ? citys : citys.OrderByDescending(x => x.name).ToList();
                return citys;
            }
        }

        public PagedList<CityContentResponse> XmlDateReaderList(List<AddressInfoCity> addressInfoCities, int page, int size)
        {
            var cityResponses = new List<CityContentResponse>();

            foreach (var item in addressInfoCities)
            {
                for (int i = 0; i < item.District.Length; i++)
                {

                    foreach (var item1 in item.District[i].Zip)
                    {
                        cityResponses.Add(new CityContentResponse()
                        {
                            CityCode = item.code,
                            CityName = item.name,
                            DistrictName = item.District[i].name,
                            ZipCode = item1.code
                        });
                    }

                }
            }
            return PagedList<CityContentResponse>.ToPagedList(cityResponses, page, size);
        }
    }

}
