
namespace App.Domain.Core.General.Dto;

public class ResultDto<T>
{
    public bool IsSucceed { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}
