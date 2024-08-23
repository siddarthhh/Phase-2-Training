using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGeneration
{
    internal class Course
    {
        public int Cid;
        public string Cname;
        public int Cduration;

        public Course(int cid, string cname, int cduration)
        {
            Cid = cid;
            Cname = cname;
            Cduration = cduration;
        }
    }
}
