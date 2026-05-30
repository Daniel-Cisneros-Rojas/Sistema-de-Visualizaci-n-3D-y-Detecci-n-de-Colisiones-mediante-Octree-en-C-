using System;
using System.Drawing;

namespace Proyecto
{

	public class Punto
	{
		double cx,cy,cz;
		float cr,cg,cb;
		public Punto()
		{
			cx=cy=cz=0;
		}
		
		public Punto(double x,double y, double z)
		{
			cx=x;
			cy=y;
			cz=z;
			
			cr=0;
			cg=0;
			cb=0;
		}
		
		public Punto(double x,double y, double z,float r,float g,float b)
		{
			cx=x;
			cy=y;
			cz=z;
			
			cr=r;
			cg=g;
			cb=b;
		}
		
		public void setcolor(float r,float g,float b)
		{
			cr=r;
			cg=g;
			cb=b;
		}
		
		public float R
		{
			set{cr=value;}
			get{return cr;}
		}
		
		public float G
		{
			set{cg=value;}
			get{return cg;}
		}
		
		public float B
		{
			set{cb=value;}
			get{return cb;}
		}
		
		public float[] Colores()
		{
			return new float[]{cr,cg,cb};
		}
		
		public double x
		{
			get{return cx;}
			set{cx=value;}
		}
		
		
		public double y
		{
			get{return cy;}
			set{cy=value;}
		}
		
		public double z
		{
			get{return cz;}
			set{cz=value;}
		}
		
		
	}
}