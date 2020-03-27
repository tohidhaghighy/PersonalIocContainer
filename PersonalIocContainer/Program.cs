using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalIocContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            ICreditCard creditcard = new MasterCard();
            //var shop = new Shopper(creditcard);
            Resolver resolver = new Resolver();
            resolver.Regester<Shopper, Shopper>();
            resolver.Regester<ICreditCard, MasterCard>();
            resolver.Regester<ICreditCard, VisaCard>();
            //var shop = new Shopper(resolver.getresolve());
            var shop = resolver.Resolve<Shopper>();
            shop.ChargeMassage();
            Console.Read();
        }
    }
}
