using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection
{
	class LoggingHandler:ICallHandler
	{
		Action<IMethodInvocation> before;
		Action<IMethodInvocation> end;

		public LoggingHandler(Action<IMethodInvocation> before, Action<IMethodInvocation> end)
		{
			this.before=before;
			this.end=end;
		}

		public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
		{
			IMethodReturn result=null;

			before(input);
			var next=getNext();
			result=next(input,getNext);
			end(input);

			return result ?? getNext()(input, getNext);
		}

		public int Order
		{
			get;
			set;
		}
	}
}
