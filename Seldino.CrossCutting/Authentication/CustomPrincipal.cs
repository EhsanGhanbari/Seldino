
using System;
using System.Security.Principal;

namespace Seldino.CrossCutting.Authentication
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public CustomPrincipal(string name)
        {
            Identity = new GenericIdentity(name);
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
