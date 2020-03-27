using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalIocContainer
{
    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "this is master card";
        }
    }
}
