using System;
using System.IO;

namespace Proyecto
{
	/// <summary>
	/// Description of ReaderFile.
	/// </summary>
	public class ReaderFile
	{
		public ReaderFile()
		{
		}
		
		public ReaderFile(string archivo)
		{
			StreamReader datos=new StreamReader(archivo);
			String linea;
			
			while(!datos.EndOfStream)
			{
				linea=datos.ReadLine();
				string[] token=linea.Split(' ');
				foreach(string x in token)
				{
					Console.WriteLine(x);
				}
				
			}
		}
		
		public Punto[] leer(string archivo)
		{
			int c=0,t=0;
			Punto[] puntos=new Punto[1];
			int[] cuadros=new int[4];
			int[] triangulos=new int[3];
			StreamReader datos=new StreamReader(archivo);
			String linea;
			linea=datos.ReadLine();
			while(!datos.EndOfStream)
			{
				linea=datos.ReadLine();
				
				if(linea=="Indice"){break;}
				string[] token=linea.Split(' ');
				puntos[c]=new Punto();
				puntos[c].x=Convert.ToDouble(token[0]);
				puntos[c].y=Convert.ToDouble(token[1]);
				puntos[c].z=Convert.ToDouble(token[2]);
				
				puntos[c].R=1;
				puntos[c].G=0;
				puntos[c].B=0;
				
				c++;
				Array.Resize(ref puntos,puntos.Length+1);
				
				foreach(string x in token)
				{
					//Console.WriteLine(x);
				}	
			}
			
			
			Array.Resize(ref puntos,puntos.Length-1);
			return (puntos);
		}
		
		public int[] indice_cuadrados(string archivo)
		{
			int c=0,t=0;
			
			int[] cuadros=new int[4];
			StreamReader datos=new StreamReader(archivo);
			String linea;
			linea=datos.ReadLine();
			while(!datos.EndOfStream)
			{
				linea=datos.ReadLine();
				if(linea=="Indice"){break;}
					
			}
			c=t=0;
			
			while(!datos.EndOfStream)
			{
				linea=datos.ReadLine();
                string[] token=linea.Split(' ');
                if(token[0]=="4")
                {
                	cuadros[c]=Convert.ToInt32(token[1]);
                	cuadros[c+1]=Convert.ToInt32(token[2]);
                	cuadros[c+2]=Convert.ToInt32(token[3]);
                	cuadros[c+3]=Convert.ToInt32(token[4]);

                	c=c+4;
                	Array.Resize(ref cuadros,cuadros.Length+4);
                }
                
               
			}
			//if(c==0){return null;}
			Array.Resize(ref cuadros,cuadros.Length-4);
            return (cuadros);
		}
		
		public int[] indice_triangulo(string archivo)
		{
			int t=0;
			Punto[] puntos=new Punto[1];
			int[] cuadros=new int[4];
			int[] triangulos=new int[3];
			StreamReader datos=new StreamReader(archivo);
			String linea;
			linea=datos.ReadLine();
			while(!datos.EndOfStream)
			{
				linea=datos.ReadLine();
				if(linea=="Indice"){break;}
			}
			
			t=0;
			
			while(!datos.EndOfStream)
			{
				linea=datos.ReadLine();
                string[] token=linea.Split(' ');
                if(token[0]=="3")
                {
                	triangulos[t]=Convert.ToInt32(token[1]);
                	triangulos[t+1]=Convert.ToInt32(token[2]);
                	triangulos[t+2]=Convert.ToInt32(token[3]);
                	t=t+3;
                	Array.Resize(ref triangulos,triangulos.Length+3);
                }
               
			}
			
			//if(t==0){return null;}
			Array.Resize(ref triangulos,triangulos.Length-3);
			
			
			return (triangulos);
		}
	}
	
	
}
