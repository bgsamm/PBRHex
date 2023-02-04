using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.Core
{
    internal class Project
    {
        public string Name { get; private set; }

        public Project(string name) {
            Name = name;
        }
    }
}
