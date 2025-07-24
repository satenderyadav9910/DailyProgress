namespace DailyProgress.VideoGameApi.Models
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }


        public ResponseModel(T data, bool success,string message)
        {
            Data = data;
            Message = message;
            Success = success;
        }
        
    }
}