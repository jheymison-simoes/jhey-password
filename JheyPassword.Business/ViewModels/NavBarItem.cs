using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JheyPassword.Business.ViewModels;

public record NavBarItem(string Icon, string Description, string RedirecTo)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool Active { get; set; }
};

