using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team4_Project2
{
    public class Instruction
    {
        int name = 0;
        int fetch, decode, execute, store = 0;

        public Instruction(int name, int fetch, int decode, int execute, int store)
        {
            this.name = name;
            this.fetch = fetch;
            this.decode = decode;
            this.execute = execute;
            this.store = store;

        }
    }
}
