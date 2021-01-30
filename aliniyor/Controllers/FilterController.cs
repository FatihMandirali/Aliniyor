using aliniyor.Models.DTO;
using aliniyor.Models.Enum;
using aliniyor.Models.Request;
using aliniyor.Models.Response;
using aliniyor.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static aliniyor.Models.ApiResultModel;

namespace aliniyor.Controllers
{
    [Route("api/[controller]")]
    public class FilterController : ControllerBase
    {
        private readonly IXmlDataReaderService _xmlDataReaderService;
        private readonly IExcelDataReaderService _excelDataReaderService;
        private readonly IMapper _mapper;
        private AppSettings _appSettings { get; set; }

        public FilterController(IXmlDataReaderService xmlDataReaderService, IExcelDataReaderService excelDataReaderService, AppSettings appSettings, IMapper mapper)
        {
            _xmlDataReaderService = xmlDataReaderService;
            _excelDataReaderService = excelDataReaderService;
            _appSettings = appSettings;
            _mapper = mapper;
        }

        /// <summary>
        /// service used to filter data
        /// </summary>
        /// <param name="cityName">the parameter for entering the city name</param>
        /// <param name="cityCode">the parameter in which the plate code is entered</param>
        /// <param name="districtName">the parameter in which the district information is entered</param>
        /// <param name="page">mandatory parameter that brings up the requested page</param>
        /// <param name="size">mandatory parameter indicating the size of the page</param>
        /// <param name="queueType">The parameter that changes the city name order</param>
        /// <returns></returns>
        [HttpGet("GetDataFilter")]
        public ResponseModel<object> GetDataFilter([FromQuery] string cityName, [FromQuery] string cityCode, [FromQuery] string districtName, [FromQuery][Required] int page, [FromQuery][Required] int size, [FromQuery] QueueTypeEnum queueType)
        {

            if(!ModelState.IsValid)
                return ResponseModel<object>.Create(ProcessStatusCodes.BadRequest, new FriendlyMessageModel() { Title = "Dikkat", Description = "Lütfen girdiğiniz değeri kontrol ediniz." });


            var cityResponse = new CityResponse();
            // var response = _xmlDataReaderService.XmlDateReaderFilterList(cityName, cityCode, districtName, zipCode, queueType);
            if (_appSettings.FileType == "Excel")
            {
                var csvReaderDtos = _excelDataReaderService.ExcelDateReaderList();
                var filterData = _excelDataReaderService.ExcelDateReaderFilterList(csvReaderDtos, cityName, cityCode, districtName, page, size, queueType);

                var cityResponses = _mapper.Map<List<CityContentResponse>>(filterData);
                cityResponse.CityContentResponse = cityResponses;
                cityResponse.PageInfo = new PageInfoResponse(filterData.CurrentPage, filterData.TotalPages, filterData.PageSize, filterData.TotalCount, filterData.HasPrevious, filterData.HasNext);

                return ResponseModel<object>.Create(cityResponse, ProcessStatusCodes.Success, new FriendlyMessageModel() { Title = "Başarılı", Description = "Filtre işleminiz gerçekleşti." });

            }
            else if(_appSettings.FileType == "XML")
            {
                var addressInfoCities = _xmlDataReaderService.XmlDateReaderFilterList(cityName, cityCode, districtName, queueType);
                var cities = _xmlDataReaderService.XmlDateReaderList(addressInfoCities,page,size);

                cityResponse.CityContentResponse = cities;
                cityResponse.PageInfo = new PageInfoResponse(cities.CurrentPage, cities.TotalPages, cities.PageSize, cities.TotalCount, cities.HasPrevious, cities.HasNext);

                return ResponseModel<object>.Create(cities, ProcessStatusCodes.Success, new FriendlyMessageModel() { Title = "Başarılı", Description = "Filtre işleminiz gerçekleşti." });
            }
            else
                return ResponseModel<object>.Create(ProcessStatusCodes.BadRequest, new FriendlyMessageModel() { Title = "Dikkat", Description = "Dosya tipi bulunmamaktadır." });


        }

        /// <summary>
        /// service that changes the file control type
        /// </summary>
        /// <param name="filterFileChangeRequest">The model that changes the file control type</param>
        /// <returns></returns>
        [HttpPost("PostChangeFilterFile")]
        public ResponseModel<object> PostChangeFilterFile([FromBody] FilterFileChangeRequest filterFileChangeRequest)
        {
            if (!ModelState.IsValid)
                return ResponseModel<object>.Create(ProcessStatusCodes.BadRequest, new FriendlyMessageModel() { Title = "Dikkat", Description = "Lütfen girdiğiniz değeri kontrol ediniz." });

            _appSettings.FileType = filterFileChangeRequest.Name.ToString();
            return ResponseModel<object>.Create(ProcessStatusCodes.Success, new FriendlyMessageModel() { Title = "Başarılı", Description = "Filtre tipi değiştirildi." });
        }
    }
}
