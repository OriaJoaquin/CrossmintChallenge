using CrossmintChallenge.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossmintChallenge.Core.Entities
{
    public class Soloon : IAstralObject
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string Color { get; set; }
    }
}
