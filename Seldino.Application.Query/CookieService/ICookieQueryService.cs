using System;

namespace Seldino.Application.Query.CookieService
{
    public interface ICookieQueryService
    {
        void Save(string key, string value, DateTime expires);

        string Retrieve(string key);
    }
}
