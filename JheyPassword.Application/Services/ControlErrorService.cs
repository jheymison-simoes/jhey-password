using JheyPassword.Business.Interfaces.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JheyPassword.Application.Services;

public class ControlErrorService : IControlErrorService
{
    private ConcurrentDictionary<string, bool> _controlErrors = new();

    public void Add(string key)
    {
        _controlErrors.TryAdd(key, true);
    }

    public bool Get(string key)
    {
        _controlErrors.TryGetValue(key, out bool result);
        return result;
    }
}

