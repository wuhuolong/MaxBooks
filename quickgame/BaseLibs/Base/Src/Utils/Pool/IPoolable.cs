using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGameEngine
{
    public interface IPoolable
    {
        void OnGetFromPool();
        void OnFreeToPool();
    }
}
