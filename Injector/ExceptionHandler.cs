using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection
{
	class ExceptionHandler:ICallHandler
	{
		Action<IMethodInvocation, Exception> handleException;

		public ExceptionHandler(Action<IMethodInvocation, Exception> handleException)
		{
			this.handleException=handleException;
		}

		public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
		{
			//这之前插入方法执行前的处理  
			IMethodReturn result = getNext()(input, getNext);//在这里执行方法  
			if (result.Exception != null) // retvalue.Exception=null说明函数执行时没有抛出异常
			{
				this.handleException(input,result.Exception);
				result.Exception = null; // 将retvalue.Exception设为null表示异常已经被处理过了，
				// 如果不把retvalue.Exception设为null，Unity会再次抛出此异常。
			}
			//这之后插入方法执行后的处理  
			return result;
		}

		public int Order
		{
			get;
			set;
		}
	}
}
