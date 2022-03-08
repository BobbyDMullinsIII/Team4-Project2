using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team4_Project2
{
    class Instruction
    {
        string name = String.Empty;
        int fetch, decode, execute, store = 0;

        public Instruction(string name, int Fetch, int decode, int execute, int store)
        {
            this.name = name; 
        }
    }
}
