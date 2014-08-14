using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection
{
	public class LoggingBaseAttribute : HandlerAttribute
	{
		public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
		{
			return new LoggingHandler(this.Before,this.End);
		}

		public virtual void Before(IMethodInvocation input)
		{
			Console.WriteLine("Before:");
		}

		public virtual void End(IMethodInvocation input)
		{
			Console.WriteLine("End:");
		}
	}
}
