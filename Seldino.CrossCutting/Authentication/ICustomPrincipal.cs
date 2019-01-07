using System;
using System.Security.Principal;

namespace Seldino.CrossCutting.Authentication
{
    /// <summary>
    /// http://stackoverflow.com/questions/1064271/asp-net-mvc-set-custom-iidentity-or-iprincipal
    /// </summary>
    public interface ICustomPrincipal : IPrincipal
    {
        Guid Id { get; set; }
        string Email { get; set; }
        string Name { get; set; }
    }
}