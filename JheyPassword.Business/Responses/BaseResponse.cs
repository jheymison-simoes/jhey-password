namespace JheyPassword.Business.Responses;

public class BaseResponse<T>
{
    public bool Error { get; set; }
    public string MessageError { get; set; }
    public T Result { get; set; }
    
    public static BaseResponse<T> Success(T result) => new BaseResponse<T> { Error = false, Result = result };
    public static BaseResponse<T> Failure(string mensagemErro) => new BaseResponse<T> { Error = true, MessageError = mensagemErro };
}