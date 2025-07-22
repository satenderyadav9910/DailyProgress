

namespace EmployeeAdminPortal.Models
{
public class ResponseModel<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public ResponseModel(bool isSuccess, string? message = null, T? data = default)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
}   
}
