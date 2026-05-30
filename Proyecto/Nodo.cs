using System;

namespace Proyecto
{
	/// <summary>
	/// Description of Nodo.
	/// </summary>
	public class Nodo
	{
		double dato;
		Nodo izdo;
		Nodo dcho;
		
		public Nodo(double valor)
		{
			dato=valor;
			izdo=dcho=null;
		}
		
		public Nodo(Nodo ramaIzdo,double valor,Nodo ramaDcho)
		{
			this.dato=valor;
			izdo=ramaIzdo;
			dcho=ramaDcho;
		}
	}
}
