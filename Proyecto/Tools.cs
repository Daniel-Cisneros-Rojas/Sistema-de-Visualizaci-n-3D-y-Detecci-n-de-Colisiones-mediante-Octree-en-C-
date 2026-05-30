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
	
	public class Tools
	{
		public List<Punto[]> cajasFinales =
        new List<Punto[]>();
		
		Punto luz=new Punto(-4,4,4,0f,0f,0f);
		Punto[]vertice=new Punto[]{
			new Punto(-2,2,2,1f,0f,0f),//0
			new Punto(2,2,2,0f,1f,0f),//1
			new Punto(2,-2,2,0f,0f,1f),//2
			new Punto(-2,-2,2,1f,1f,0f),//3
			new Punto(-2,2,-2,0f,1f,1f),//4
			new Punto(2,2,-2,1f,0f,1f),
			new Punto(2,-2,-2,1f,1f,1f),//6
			new Punto(-2,-2,-2,0f,0f,0f),//7
			
};
		int[]indice=new int[]{
			0,1,3,2,
			7,6,2,3,
			0,4,2,3,
			0,4,5,6,
			
				
		};
		
		
		
		int[]secuencia=new int[]{
			4,5,6,7,
			1,2,6,5,
			0,3,7,4,
			2,3,7,6,
			0,1,5,4,
			
			0,1,2,3,
	};
		
		Punto[]esquinas=new Punto[]
		{
			new Punto(),//0
			new Punto(),//1
			new Punto(),//2
			new Punto(),//3
			new Punto(),//4
			new Punto(),
			new Punto(),//6
			new Punto(),//7
		};
		float rojo=1;
		public Tools()
		{
			
		}
		
		public void LimpiarOctree()
		{
		    cajasFinales.Clear();
		}
		
		public double distancia_puntos(Punto a,Punto b)
		{
			double distancia;
			distancia=Math.Sqrt(Math.Pow((b.x-a.x),2)+Math.Pow((b.y-a.y),2)+Math.Pow((b.z-a.z),2));
			return distancia;
		}
		
			public void dibujar_cubo(Punto a,int tam,int color)
		{
			double distancia;
			GL.Begin(PrimitiveType.Quads);
			esquinas[0]=new Punto(a.x,a.y,a.z,0f,0f,0f);
			esquinas[1]=new Punto(a.x+tam,a.y,a.z,0f,0f,0f);
			esquinas[2]=new Punto(a.x+tam,a.y+tam,a.z,0f,0f,0f);
			esquinas[3]=new Punto(a.x,a.y+tam,a.z,0f,0f,0f);
			
			esquinas[4]=new Punto(a.x,a.y,a.z+tam,0f,0f,0f);
			esquinas[5]=new Punto(a.x+tam,a.y,a.z+tam,0f,0f,0f);
			esquinas[6]=new Punto(a.x+tam,a.y+tam,a.z+tam,0f,0f,0f);
			esquinas[7]=new Punto(a.x,a.y+tam,a.z+tam,0f,0f,0f);
			
			for(int i=0;i<8;i++)
			{
				distancia=distancia_puntos(luz,esquinas[i]);
				distancia=5/distancia;
				if(distancia>1)
				{
					distancia=1;
				}
				Console.WriteLine(distancia);
				if(color==1)
				{
				  esquinas[i].R=(float)distancia;	
				}
				if(color==2)
				{
				  esquinas[i].G=(float)distancia;	
				}
				if(color==3)
				{
				  esquinas[i].B=(float)distancia;	
				}
				
			}
			
			foreach(int x in secuencia)
			{
				GL.Color3(esquinas[x].Colores());
				GL.Vertex3(esquinas[x].x,esquinas[x].y,esquinas[x].z);
			}
            
			GL.End();
		}
			
			public void cubo_luz(Punto a, int tam)
			{
			GL.Begin(PrimitiveType.Quads);
			esquinas[0]=new Punto(a.x,a.y,a.z,1f,0f,0f);
			esquinas[1]=new Punto(a.x+tam,a.y,a.z,rojo,0f,0f);
			esquinas[2]=new Punto(a.x+tam,a.y+tam,a.z,1f,0f,0f);
			esquinas[3]=new Punto(a.x,a.y+tam,a.z,1f,0f,0f);
			
			esquinas[4]=new Punto(a.x,a.y,a.z+tam,1f,0f,0f);
			esquinas[5]=new Punto(a.x+tam,a.y,a.z+tam,1f,0f,0f);
			esquinas[6]=new Punto(a.x+tam,a.y+tam,a.z+tam,1f,0f,0f);
			esquinas[7]=new Punto(a.x,a.y+tam,a.z+tam,1f,0f,0f);
			
			
			foreach(int x in secuencia)
			{
				GL.Color3(esquinas[x].Colores());
				GL.Vertex3(esquinas[x].x,esquinas[x].y,esquinas[x].z);
			}
            
			GL.End();
			}
		
		public void cubo()
		{
			GL.Begin(PrimitiveType.Quads);
			foreach(int x in indice)
			{
				GL.Color3(vertice[x].Colores());
				 GL.Vertex3(vertice[x].x,vertice[x].y,vertice[x].z);
			}
			
           
			GL.End();
		}
		
		public void ejes()
		{
			GL.LineWidth(2);
			GL.Begin(PrimitiveType.Lines);
			GL.Color4(Color4.Aqua);
			GL.Vertex3(0,0,0);GL.Vertex3(1,0,0);
			GL.Color4(Color4.Aquamarine);
			GL.Vertex3(0,0,0);GL.Vertex3(0,1,0);
			GL.Color4(Color4.BlueViolet);
			GL.Vertex3(0,0,0); GL.Vertex3(0,0,1);
			GL.Color4(Color4.AntiqueWhite);
			GL.End();
			
		}
		public void grilla()
		{
			GL.Begin(PrimitiveType.Lines);
			GL.Color4(Color4.AntiqueWhite);
			for (double t=-5; t <5; t +=0.5)
			{
				GL.Vertex3(t,0,-5);
				GL.Vertex3(t,0,5);
				GL.Vertex3(-5,0,t);
				GL.Vertex3(5,0,t);
			}
			GL.End();
		}
		
		public void multi_mat(int[,]a,int[,]b)
		{
			int[,]c=new int[a.GetLength(0),b.GetLength(1)];
			
			if(a.GetLength(1)==b.GetLength(0))
			{
				//poner en 0 la matriz
				for(int i=0;i<a.GetLength(0);i++)
				{
					for(int j=0;j<b.GetLength(1);j++)
					{
						c[i,j]=0;
					}
				}
				//operaciones
				for(int i=0;i<a.GetLength(0);i++)
				{
					for(int j=0;j<b.GetLength(1);j++)
					{
						for(int k=0;k<a.GetLength(1);k++)
						{
							c[i,j]=c[i,j]+(a[i,k]*b[k,j]);
						}
					}
				}
				//imprimir resultado
				for(int i=0;i<a.GetLength(0);i++)
				{
					for(int j=0;j<b.GetLength(1);j++)
					{
						Console.WriteLine("c["+i+","+j+"] = "+c[i,j]);
					}
				}
			}
			else
			{
				Console.WriteLine("No se puede realizar esta operacion");
			}
		}
		
		
		
		public Punto[] maximo_minimo(Punto[]a)
		{
			double[]max=new double[3];
			double[]min=new double[3];
			Punto[] coordenadas=new Punto[2];
			max[0]=a[0].x;
			max[1]=a[1].y;
			max[2]=a[2].z;
			
			min[0]=a[0].x;
			min[1]=a[0].y;
			min[2]=a[0].z;
			for(int i=0;i<a.Length;i++)
			{
				//x
				if(max[0]<a[i].x)
				{
					max[0]=a[i].x;
				}
				if(min[0]>a[i].x)
				{
					min[0]=a[i].x;
				}
				//y
				if(max[1]<a[i].y)
				{
					max[1]=a[i].y;
				}
				if(min[1]>a[i].y)
				{
					min[1]=a[i].y;
				}
                //z
				if(max[2]<a[i].z)
				{
					max[2]=a[i].z;
				}
				if(min[2]>a[i].z)
				{
					min[2]=a[i].z;
				}
			}
			
			coordenadas[0]=new Punto(max[0],max[1],max[2],1,0,0);
			coordenadas[1]=new Punto(min[0],min[1],min[2],1,0,0);
			return coordenadas;
			
		}
		
		
		public void dividir_en_8(Punto[]a,Punto[] vertices,int division)
		{
			//1 minimo
			//0 maximo
			
			int contador=-1,dentro=0;
			Punto[] cubo1=new Punto[2];
			Punto[] cubo2=new Punto[2];
			Punto[] cubo3=new Punto[2];
			Punto[] cubo4=new Punto[2];
			Punto[] cubo5=new Punto[2];
			Punto[] cubo6=new Punto[2];
			Punto[] cubo7=new Punto[2];
			Punto[] cubo8=new Punto[2];
			//Console.WriteLine(a[0].x+"min"+a[1].x);
			
			do
			{
				contador++;
				if(vertices[contador].x>a[1].x&&vertices[contador].x<a[0].x&&vertices[contador].y>a[1].y&&vertices[contador].y<a[0].y&&vertices[contador].z>a[1].z&&vertices[contador].z<a[0].z)
				{
					dentro=1;
					//Console.WriteLine(division);
				}
			}while(dentro==0&&contador<vertices.Length-1);
			
			if(dentro==1)
			{
				    cubo1[1]=new Punto(a[1].x,a[1].y,(a[0].z+a[1].z)/2);
					cubo1[0]=new Punto((a[0].x+a[1].x)/2,(a[0].y+a[1].y)/2,(a[0].z));
				    
					cubo2[1]=new Punto((a[0].x+a[1].x)/2,a[1].y,(a[0].z+a[1].z)/2);
					cubo2[0]=new Punto(a[0].x,(a[0].y+a[1].y)/2,a[0].z);
				    
					cubo3[1]=new Punto(a[1].x,(a[0].y+a[1].y)/2,(a[0].z+a[1].z)/2);
					cubo3[0]=new Punto((a[0].x+a[1].x)/2,(a[0].y),(a[0].z));
					
					cubo4[1]=new Punto((a[0].x+a[1].x)/2,(a[0].y+a[1].y)/2,(a[0].z+a[1].z)/2);
					cubo4[0]=new Punto(a[0].x,(a[0].y),a[0].z);
					
					cubo5[1]=new Punto(a[1].x,a[1].y,(a[1].z));
					cubo5[0]=new Punto((a[0].x+a[1].x)/2,(a[0].y+a[1].y)/2,(a[0].z+a[1].z)/2);
					
					cubo6[1]=new Punto((a[0].x+a[1].x)/2,a[1].y,(a[1].z));
					cubo6[0]=new Punto(a[0].x,(a[0].y+a[1].y)/2,(a[0].z+a[1].z)/2);
					
					cubo7[1]=new Punto(a[1].x,(a[0].y+a[1].y)/2,(a[1].z));
					cubo7[0]=new Punto((a[0].x+a[1].x)/2,(a[0].y),(a[0].z+a[1].z)/2);
					
					cubo8[1]=new Punto((a[0].x+a[1].x)/2,(a[0].y+a[1].y)/2,(a[1].z));
					cubo8[0]=new Punto(a[0].x,(a[0].y),(a[0].z+a[1].z)/2);
				
				if(division>1)
				{
					
				    
				    
				   dividir_en_8(cubo1,vertices,division-1);
				   dividir_en_8(cubo2,vertices,division-1);
				   dividir_en_8(cubo3,vertices,division-1);
				   dividir_en_8(cubo4,vertices,division-1);
				   dividir_en_8(cubo5,vertices,division-1);
				   dividir_en_8(cubo6,vertices,division-1);
				   dividir_en_8(cubo7,vertices,division-1);
				   dividir_en_8(cubo8,vertices,division-1);
				}
				
					if(division==1)
				{
				    cajasFinales.Add(cubo1);
				    cajasFinales.Add(cubo2);
				    cajasFinales.Add(cubo3);
				    cajasFinales.Add(cubo4);
				    cajasFinales.Add(cubo5);
				    cajasFinales.Add(cubo6);
				    cajasFinales.Add(cubo7);
				    cajasFinales.Add(cubo8);
				}
				
				
				
			}
			
			Console.WriteLine("fin"+division);
			
		}
		
		public void dibujar_cara(Punto[]a,int color)
		{
			GL.Begin(PrimitiveType.Quads);
			if(color==1)
			{
			 GL.Color3(Color.Green);	
			}
			if(color==2)
			{
				GL.Color3(Color.CornflowerBlue);
			}
			
			GL.Vertex3(a[1].x,a[1].y,a[0].z);
			GL.Vertex3(a[0].x,a[1].y,a[0].z);
			GL.Vertex3(a[0].x,a[0].y,a[0].z);
			GL.Vertex3(a[1].x,a[0].y,a[0].z);
			GL.End();
		}
		
		
		
		public bool ColisionEsferaCaja(
		    Punto esfera,
		    double radio,
		    Punto[] caja)
		{
		    double x =
		        Math.Max(caja[1].x,
		        Math.Min(esfera.x,caja[0].x));
		
		    double y =
		        Math.Max(caja[1].y,
		        Math.Min(esfera.y,caja[0].y));
		
		    double z =
		        Math.Max(caja[1].z,
		        Math.Min(esfera.z,caja[0].z));
		
		    double dx = esfera.x - x;
		    double dy = esfera.y - y;
		    double dz = esfera.z - z;
		
		    return
		        dx*dx +
		        dy*dy +
		        dz*dz
		        <=
		        radio*radio;
		}
		
		
		
		public void DibujarOctree()
		{
		    foreach(Punto[] caja in cajasFinales)
		    {
		        dibujarHitbox(caja);
		    }
		}
		
		public bool ColisionOctree(
		    Punto esfera,
		    double radio)
		{
		    foreach(Punto[] caja in cajasFinales)
		    {
		        if(
		            ColisionEsferaCaja(
		                esfera,
		                radio,
		                caja))
		        {
		            return true;
		        }
		    }
		
		    return false;
		}
		
		public double DistanciaOctree(
		    Punto esfera)
		{
		    double minima =
		        double.MaxValue;
		
		    foreach(Punto[] caja in cajasFinales)
		    {
		        double d =
		            DistanciaCaja(
		                esfera,
		                caja);
		
		        if(d < minima)
		            minima = d;
		    }
		
		    return minima;
		}
		//
		public double DistanciaCaja(
		    Punto esfera,
		    Punto[] caja)
		{
		    double dx=0;
		    double dy=0;
		    double dz=0;
		
		    if(esfera.x<caja[1].x)
		        dx=caja[1].x-esfera.x;
		    else if(esfera.x>caja[0].x)
		        dx=esfera.x-caja[0].x;
		
		    if(esfera.y<caja[1].y)
		        dy=caja[1].y-esfera.y;
		    else if(esfera.y>caja[0].y)
		        dy=esfera.y-caja[0].y;
		
		    if(esfera.z<caja[1].z)
		        dz=caja[1].z-esfera.z;
		    else if(esfera.z>caja[0].z)
		        dz=esfera.z-caja[0].z;
		
		    return Math.Sqrt(
		        dx*dx+
		        dy*dy+
		        dz*dz);
		}
				
			public void dibujarHitbox(Punto[] caja)
		{
		    Punto min = caja[1];
		    Punto max = caja[0];
		
		    GL.Color3(Color.Lime);
		
		    GL.Begin(PrimitiveType.LineLoop);
		
		    GL.Vertex3(min.x,min.y,min.z);
		    GL.Vertex3(max.x,min.y,min.z);
		    GL.Vertex3(max.x,max.y,min.z);
		    GL.Vertex3(min.x,max.y,min.z);
		
		    GL.End();
		
		    GL.Begin(PrimitiveType.LineLoop);
		
		    GL.Vertex3(min.x,min.y,max.z);
		    GL.Vertex3(max.x,min.y,max.z);
		    GL.Vertex3(max.x,max.y,max.z);
		    GL.Vertex3(min.x,max.y,max.z);
		
		    GL.End();
		
		    GL.Begin(PrimitiveType.Lines);
		
		    GL.Vertex3(min.x,min.y,min.z);
		    GL.Vertex3(min.x,min.y,max.z);
		
		    GL.Vertex3(max.x,min.y,min.z);
		    GL.Vertex3(max.x,min.y,max.z);
		
		    GL.Vertex3(max.x,max.y,min.z);
		    GL.Vertex3(max.x,max.y,max.z);
		
		    GL.Vertex3(min.x,max.y,min.z);
		    GL.Vertex3(min.x,max.y,max.z);
		
		    GL.End();
		}
		
		
		
		
		
	}
}