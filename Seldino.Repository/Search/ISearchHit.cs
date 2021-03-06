﻿using System;

namespace Seldino.Repository.Search
{
    public interface ISearchHit
    {
        int ContentItemId { get; }

        float Score { get; }

        int GetInt(string name);

        double GetDouble(string name);

        bool GetBoolean(string name);

        string GetString(string name);

        DateTime GetDateTime(string name);
    }
}