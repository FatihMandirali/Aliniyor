using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace aliniyor.Models
{
    public class ApiResultModel
    {
        public enum ProcessStatusCodes
        {
            [HttpStatusCode(HttpStatusCode.OK)]
            Success = 200,
            [HttpStatusCode(HttpStatusCode.BadRequest)]
            BadRequest = 400,


        }
        [DataContract]
        public class ResponseModel<T>
        {
            [DataMember]
            public T Data { get; set; }

            [DataMember]
            public ProcessStatusModel ProcessStatus { get; set; }

            [DataMember]
            public FriendlyMessageModel FriendlyMessage { get; set; }



            public static ResponseModel<object> Create(ProcessStatusCodes processStatus = ProcessStatusCodes.Success, FriendlyMessageModel friendlyMessage = null)
            {
                return ResponseModel<object>.Create(null, processStatus, friendlyMessage);
            }
            public static ResponseModel<T> Create(T data, ProcessStatusCodes processStatus = ProcessStatusCodes.Success, FriendlyMessageModel friendlyMessage = null)
            {
                var response = new ResponseModel<T>
                {
                    Data = data,
                    ProcessStatus = ProcessStatusModel.Create(processStatus),
                    FriendlyMessage = friendlyMessage
                };

                return response;
            }

            public static ResponseModel<object> CreateMessageInData(T data, ProcessStatusCodes processStatus = ProcessStatusCodes.Success, FriendlyMessageModel message = null, FriendlyMessageModel friendlyMessage = null)
            {
                var resultObject = new MessageInData<T> { Response = data, Message = message };
                var response = new ResponseModel<object>
                {
                    Data = resultObject,
                    ProcessStatus = ProcessStatusModel.Create(processStatus),
                    FriendlyMessage = friendlyMessage
                };

                return response;
            }


            public class MessageInData<T>
            {
                public T Response { get; set; }
                public FriendlyMessageModel Message { get; set; }
            }

            public static ResponseModel<System.Exception> CreateException(System.Exception ex, ProcessStatusCodes processStatus, FriendlyMessageModel friendlyMessage = null)
            {
                var response = new ResponseModel<System.Exception>
                {
                    Data = ex,
                    ProcessStatus = ProcessStatusModel.Create(processStatus),
                    FriendlyMessage = friendlyMessage
                };

                return response;
            }
        }

        [DataContract]
        public class ProcessStatusModel
        {
            [IgnoreDataMember]
            public ProcessStatusCodes ProcessStatusCode { get; set; }

            [DataMember(Name = "code")]
            public int ProcessStatusCodeInt
            {
                get { return (int)ProcessStatusCode; }
                set { ProcessStatusCode = (ProcessStatusCodes)value; }
            }

            [DataMember]
            public string Description => ProcessStatusCode.ToString();

            [DataMember]
            public bool Success => ProcessStatusCode == ProcessStatusCodes.Success;

            public static ProcessStatusModel Create(ProcessStatusCodes processStatusCode)
            {
                return new ProcessStatusModel { ProcessStatusCode = processStatusCode };
            }
        }


        [DataContract]
        public class FriendlyMessageModel
        {


            [DataMember]
            public string Title { get; set; }

            [DataMember]
            public string Description { get; set; }



            public static FriendlyMessageModel Create(string title, string description)
            {
                var friendlyMessageModel = new FriendlyMessageModel
                {
                    Title = title,
                    Description = description
                };



                return friendlyMessageModel;
            }
        }
    }
}
