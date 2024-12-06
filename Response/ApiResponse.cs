namespace Consultorio.Response
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public string Message {  get; set; }
        public bool Status {  get; set; }
        public ApiResponse(object data, string message, bool status = true) 
        {
            Data = data;
            Message = message;
            Status = status;
        }
        
    }
}
