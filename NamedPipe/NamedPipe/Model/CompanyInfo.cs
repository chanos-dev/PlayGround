using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedPipe.Model
{
    public class CompanyInfo
    {
        public int CompanyCD { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public CompanyInfo()
        {

        }

        public override string ToString() => $"CompanyCD : {CompanyCD}\nName : {Name}\nAddress : {Address}";
    }
}
