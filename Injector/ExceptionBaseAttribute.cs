using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection
{
	public class ExceptionBaseAttribute : HandlerAttribute
	{
		public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
		{
			return new ExceptionHandler(this.HandleException);
		}

		public virtual void HandleException(IMethodInvocation input, Exception exception)
		{
			Console.WriteLine("Occur error when exec "+input.MethodBase.Name);
			throw exception;
		}
	}
}
