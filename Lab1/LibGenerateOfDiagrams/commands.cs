using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGenerateOfDiagrams
{
    public class Commands
    {
        public List<Command> Lists { get; set; } = new List<Command>(1) { };
        public int Count { get => Lists.Count; }
        public Commands()
        {

        }
        public Commands(List<Command> _Lists)
        {
            Lists = _Lists;
        }
    }
}
