using System;

namespace Seldino.CrossCutting.Authentication
{
    public class CustomPrincipalSerializeModel
    {
        public CustomPrincipalSerializeModel()
        {
        }

        public CustomPrincipalSerializeModel(Guid id, string email, string name)
        {
            Id = id;
            Email = email;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
