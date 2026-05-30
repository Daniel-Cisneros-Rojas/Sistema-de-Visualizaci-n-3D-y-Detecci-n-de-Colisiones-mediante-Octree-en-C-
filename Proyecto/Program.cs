
using System;

namespace Proyecto
{
	class Program
	{
		public static void Main(string[] args)
		{
			Pantalla game=new Pantalla();
			game.Run(1.0/60.0);
		}
	}
}