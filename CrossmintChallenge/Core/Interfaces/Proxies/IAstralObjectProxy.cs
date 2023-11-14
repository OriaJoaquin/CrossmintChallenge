using CrossmintChallenge.Core.Entities;
using CrossmintChallenge.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossmintChallenge.Core.Interfaces.Proxies
{
    public interface IAstralObjectProxy
    {
        public Task CreateAstralObject(IAstralObject astralObject);
    }
}
