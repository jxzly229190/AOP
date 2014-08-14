using Injection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
			var dog = Injector.GetInstance<IEat, Dog>();
			dog.Eat("bread");

			//dog.Bark();

			Console.Read();			
        }
    }

	public interface IEat
	{
		void Eat([Require]string food);

		void Bark();
	}
	
	public class Dog : IEat
	{
		[LoggingBase]
		[ExceptionBase]
		[Argument]
		public void Eat(string food)
		{
			Console.WriteLine("Dog Eat "+food);
			//throw new Exception("New Exception");
		}

		public void Bark()
		{
			Console.WriteLine("Dog Bark ");
		}
	}
}
