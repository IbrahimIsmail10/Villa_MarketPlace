using static Utility.SD;

namespace MagicVilla_Web.Models
{
    public class APIRequest
    {
        public APITYPE ApiType { get; set; } = APITYPE.GET;

        public string Url { get; set; }

        public object Data { get; set; }
    }
}
