using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalIocContainer
{
    public class Shopper
    {
        private readonly ICreditCard creditcard;
        public Shopper(ICreditCard creditcard)
        {
            this.creditcard = creditcard;
        }

        public void ChargeMassage()
        {
            var massage = creditcard.Charge();
            Console.WriteLine(massage);
        }
    }
}
