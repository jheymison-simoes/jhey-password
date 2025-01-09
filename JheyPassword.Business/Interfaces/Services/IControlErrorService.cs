namespace JheyPassword.Business.Interfaces.Services;

public interface IControlErrorService
{
    void Add(string key);
    bool Get(string key);
}

