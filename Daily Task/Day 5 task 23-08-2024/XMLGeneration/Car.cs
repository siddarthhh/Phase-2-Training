    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneration
{
    class Car
    {
        public int Cid;
        public string Cname;
        public int Cduration;

        public Car(int cid, string cname, int cduration)
        {
            Cid = cid;
            Cname = cname;
            Cduration = cduration;
        }
    }
}
