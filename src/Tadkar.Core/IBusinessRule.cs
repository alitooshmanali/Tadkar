﻿namespace Tadkar.Core
{
    public interface IBusinessRule
    {
        string Message { get; }

        bool IsBroken();
    }
}
