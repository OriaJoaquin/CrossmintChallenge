using CrossmintChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossmintChallenge.Core.Interfaces.Proxies
{
    public interface IComethProxy
    {
        public Task CreateCometh(Cometh cometh);
    }
}
