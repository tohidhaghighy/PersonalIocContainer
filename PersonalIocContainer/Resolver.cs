using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalIocContainer
{
    public class Resolver
    {
        private Dictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();

        public void Regester<TFrom, TTo>()
        {
            dependencyMap.Add(typeof(TFrom), typeof(TTo));
        }

        //internal ICreditCard getresolve()
        //{
        //    if (new Random().Next(2) == 1)
        //    {
        //        return new MasterCard();
        //    }
        //    else return new VisaCard();
        //}
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type typetoResolve)
        {
            Type resolvetype = null;
            try
            {
                resolvetype = dependencyMap[typetoResolve];
            }
            catch
            {
                throw new Exception(string.Format("could not find dependency of {0}",typetoResolve));
            }

            var firstconstructor = resolvetype.GetConstructors().First();
            var constroctorparameters = firstconstructor.GetParameters();
            if (constroctorparameters.Count() == 0)
            {
                return Activator.CreateInstance(resolvetype);
            }

            IList<object> parameters = new List<object>();
            foreach (var param in constroctorparameters)
            {
                parameters.Add(Resolve(param.ParameterType));
            }

            return firstconstructor.Invoke(parameters.ToArray());
            
        }
    }
}
