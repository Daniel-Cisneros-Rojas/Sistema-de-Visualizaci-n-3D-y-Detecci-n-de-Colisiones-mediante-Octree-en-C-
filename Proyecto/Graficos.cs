using System;
using System.Drawing;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Collections.Generic;


namespace Proyecto
{

	public class Graficos
	{
		public Graficos()
		{
		}
		
		public void esfera(Punto a,double radio)
		{
			
			double increRad=Math.PI/40;
			double x,y,z;
			Punto[]vertices=new Punto[4];
			for(int i=0;i<4;i++)
			{
				vertices[i]=new Punto();
			}
			
			for(double teta=0;teta<Math.PI;teta+=increRad)
			{
               for(double phi=0;phi<2*Math.PI;phi+=increRad)
               {
               	vertices[0].z=(radio)*((float) Math.Sin(teta))*((float)Math.Cos(phi));
                vertices[0].x=(radio)*((float) Math.Sin(teta))*((float)Math.Sin(phi));
                vertices[0].y=(radio)*((float) Math.Cos(teta));
                
                vertices[1].z=(radio)*((float) Math.Sin(teta+increRad))*((float)Math.Cos(phi));
                vertices[1].x=(radio)*((float) Math.Sin(teta+increRad))*((float)Math.Sin(phi));
                vertices[1].y=(radio)*((float) Math.Cos(teta+increRad));
                
                vertices[2].z=(radio)*((float) Math.Sin(teta+increRad))*((float)Math.Cos(phi+increRad));
                vertices[2].x=(radio)*((float) Math.Sin(teta+increRad))*((float)Math.Sin(phi+increRad));
                vertices[2].y=(radio)*((float) Math.Cos(teta+increRad));
                    
                vertices[3].z=(radio)*((float) Math.Sin(teta))*((float)Math.Cos(phi+increRad));
                vertices[3].x=(radio)*((float) Math.Sin(teta))*((float)Math.Sin(phi+increRad));
                vertices[3].y=(radio)*((float) Math.Cos(teta));
                
                for(int i=0;i<4;i++)
                {
                	vertices[i].x=vertices[i].x+a.x;
                	vertices[i].y=vertices[i].y+a.y;
                	vertices[i].z=vertices[i].z+a.z;
                }
                
                GL.Begin(PrimitiveType.LineLoop);
			    GL.Color3(Color.Black);
                GL.Vertex3(vertices[0].x,vertices[0].y,vertices[0].z);
                GL.Vertex3(vertices[1].x,vertices[1].y,vertices[1].z);
                GL.Vertex3(vertices[2].x,vertices[2].y,vertices[2].z);
                GL.Vertex3(vertices[3].x,vertices[3].y,vertices[3].z);
                GL.End();
                }
             }
			
			
			 
		}
		
		public void dibujar(Punto[] a,int[]cuadros,int[]triangulos)
		{
			
            GL.Begin(PrimitiveType.Quads);
			foreach(int x in cuadros)
			{
				GL.Color3(a[x].Colores());
				GL.Vertex3(a[x].x,a[x].y,a[x].z);
				//Console.WriteLine(a[x].x+","+a[x].y+","+a[x].z);
			}
			GL.End();
			
		
			GL.Begin(PrimitiveType.Triangles);
			foreach(int x in triangulos)
			{
				GL.Color3(a[x].Colores());
				GL.Vertex3(a[x].x,a[x].y,a[x].z);
				//Console.WriteLine(a[x].x+","+a[x].y+","+a[x].z);
			}
			GL.End();
			
			
		}
		
		public void mallado(Punto[] a,int[]cuadros,int[]triangulos)
		{
			int c=0;
			GL.Begin(PrimitiveType.LineLoop);
			foreach(int x in cuadros)
			{
				if(c==4){
					c=0;
					GL.End();
					GL.Begin(PrimitiveType.LineStrip);
				}
				GL.Color3(Color.Black);
				GL.Vertex3(a[x].x,a[x].y,a[x].z);
				c++;
				//Console.WriteLine(a[x].x+","+a[x].y+","+a[x].z);
			}
			GL.End();
			c=0;
			GL.Begin(PrimitiveType.LineLoop);
			foreach(int x in triangulos)
			{
				if(c==3){
					c=0;
					GL.End();
					GL.Begin(PrimitiveType.LineStrip);
				}
				GL.Color3(Color.Black);
				GL.Vertex3(a[x].x,a[x].y,a[x].z);
				c++;
				//Console.WriteLine(a[x].x+","+a[x].y+","+a[x].z);
			}
			GL.End();
		}
	}
}
