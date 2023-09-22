using Microsoft.AspNetCore.Mvc;
using static Frontend.Utils.SD;

namespace Frontend.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
