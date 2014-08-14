using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection
{
	class ArgumentHandler : ICallHandler
	{
		public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
		{
			var args = input.Arguments;

			if (args != null && args.Count > 0)
			{
				for (var i = 0; i < args.Count; i++)
				{
					var arg = args.GetParameterInfo(i);
					var attributes = arg.GetCustomAttributes(typeof(ArgumentValidateAttribute), true);

					if (attributes != null && attributes.Length > 0)
					{
						foreach (ArgumentValidateAttribute attribute in attributes)
						{
							attribute.Validate(arg.Name,input.Arguments[i]);
						}
					}
				}
			}

			return getNext()(input, getNext);
		}

		public int Order
		{
			get;
			set;
		}

	}
}
