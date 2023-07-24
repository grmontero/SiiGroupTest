using Newtonsoft.Json;

namespace SiiTestModel
{
   
    public  class ServiceResponse<T>
    {
        public string? status { get; set; }
        public T data { get; set; }
        public string? message { get; set; }
    }
}