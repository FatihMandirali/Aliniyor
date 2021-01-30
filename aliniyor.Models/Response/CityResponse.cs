using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aliniyor.Models.Response
{
    public class CityResponse
    {
      
        public PageInfoResponse PageInfo { get; set; }
        public List<CityContentResponse> CityContentResponse { get; set; }
    }
}
