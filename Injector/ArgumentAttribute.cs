using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Injection
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ArgumentAttribute : HandlerAttribute
	{
		public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
		{
			return new ArgumentHandler();
		}
	}

	[AttributeUsage(AttributeTargets.Parameter)]
	public abstract class ArgumentValidateAttribute : Attribute
	{
		public abstract void Validate(string argName, object argValue);
	}

	public class RequireAttribute : ArgumentValidateAttribute
	{
		public override void Validate(string argName,object argValue)
		{
			if (argValue == null)
			{
				throw new ArgumentNullException(string.Format("argument {0} cannot be null", argName));
			}
		}
	}
}
