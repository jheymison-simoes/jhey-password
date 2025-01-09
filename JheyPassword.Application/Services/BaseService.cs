using JheyPassword.Business.Exceptions;

namespace JheyPassword.Application.Services;

public abstract class BaseService
{
    public NotFoundException NotFound(string message) => new(message);
}