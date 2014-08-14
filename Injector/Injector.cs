using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection
{
    public class Injector
    {
		public static From GetInstance<From, To>() where To : From
		{
			var container = new UnityContainer().AddNewExtension<Interception>();
			container.RegisterType<From, To>();
			container.Configure<Interception>().SetInterceptorFor<From>(new InterfaceInterceptor());

			var instance = container.Resolve<From>();

			return instance;
		}
    }
}
