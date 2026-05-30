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
	public class Pantalla: GameWindow
	{
		bool colision = false;
        double distancia = 0;
        
		Graficos graficos=new Graficos();
		Tools herramientas=new Tools();
		ReaderFile lee_archivo=new ReaderFile();
		Punto[] vertices;
		Punto[] hitbox_Grande;
		int[] indice_c;
		int[] indice_t;
		double px=-3,py=0,pz=0,incremento=0.1,tam_e=1;
		int camaraActual=1;
		
		Punto luz=new Punto(-4,4,4,0f,0f,0f);
		Punto esfera=new Punto(0,0,0,0f,0f,1f);
		string archivo="Among.ply";
		
		
		Punto[]vertice=new Punto[]{
			new Punto(-2,2,2,1f,0f,0f),//0
			new Punto(2,2,2,0f,1f,0f),//1
			new Punto(-2,-2,2,0f,0f,1f),//2
			new Punto(2,-2,2,1f,1f,0f),//3
			new Punto(-2,2,-2,0f,1f,1f),//4
			new Punto(2,2,-2,1f,0f,1f),
			new Punto(2,-2,-2,1f,1f,1f),//6
			new Punto(-2,-2,-2,0f,0f,0f),//7
			
};
		int[]indice=new int[]{
			0,1,3,2,
			1,5,7,3,
			7,6,2,3,
			0,4,5,1,
			4,5,7,6,
		
		};
		
		
		
		
		public Pantalla() : base(1000, 1000, GraphicsMode.Default, "3D")
		{
			
		}
		
		protected override void OnLoad(EventArgs e)
		{
			/*GL.ClearColor(Color.White);
			//Matrix4 lookAt = Matrix4.LookAt(5,-3,5,0,0,0,0,1,1);
			Matrix4 lookAt = Matrix4.LookAt(0,0,5,0,0,0,0,1,0);
		//	Matrix4 lookAt = Matrix4.CreateLookAt(new Vector3(5, 5, 5), Vector3.Zero, Vector3.UnitY);

			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref lookAt);
			
			
			
			vertices=lee_archivo.leer(archivo);
			indice_c=lee_archivo.indice_cuadrados(archivo);
			indice_t=lee_archivo.indice_triangulo(archivo);
			hitbox_Grande=herramientas.maximo_minimo(vertices);
			herramientas.dividir_en_8(hitbox_Grande,vertices,2);
			
			GL.ClearColor(Color.White);*/
			Console.WriteLine("i=invertir\n c=hacer pequeña\n g=hacer grande");
            GL.ClearColor(Color.White);
			GL.Enable(EnableCap.DepthTest);
			
			CambiarCamara();
			
			vertices = lee_archivo.leer(archivo);
			indice_c = lee_archivo.indice_cuadrados(archivo);
			indice_t = lee_archivo.indice_triangulo(archivo);
			
			hitbox_Grande = herramientas.maximo_minimo(vertices);
			herramientas.LimpiarOctree();
		
			herramientas.dividir_en_8(
			    hitbox_Grande,
			    vertices,
			    5);
					
			// color inicial azul
			for(int i=0;i<vertices.Length;i++)
			{
			    vertices[i].R = 0f;
			    vertices[i].G = 0.4f;
			    vertices[i].B = 1f;
			}
				
			GL.ClearColor(Color.White);
		}

		protected override void OnUpdateFrame(FrameEventArgs e)
		{

			GL.Clear(ClearBufferMask.ColorBufferBit); //| ClearBufferMask.DepthBufferBit);
			
			
			esfera.x = px;
			esfera.y = py;
			esfera.z = pz;
			
			/*colision =
			    herramientas.ColisionEsferaCaja(
			        esfera,
			        tam_e,
			        hitbox_Grande);
			 distancia =
			    herramientas.DistanciaCaja(
			        esfera,
			        hitbox_Grande);*/
			colision=
			herramientas.ColisionOctree(
			    esfera,
			    tam_e);
			distancia=
			herramientas.DistanciaOctree(
			    esfera);
			
			
			if(colision)
			{
			    for(int i=0;i<vertices.Length;i++)
			    {
			        vertices[i].R = 1f;
			        vertices[i].G = 0f;
			        vertices[i].B = 0f;
			    }
			}
			else
			{
			    for(int i=0;i<vertices.Length;i++)
			    {
			        vertices[i].R = 0f;
			        vertices[i].G = 0.4f;
			        vertices[i].B = 1f;
			    }
			}
			
			Title =
			    "Distancia: "
			    + distancia.ToString("0.00")
			    + (colision ? "  COLISION" : "");
			
		}
		protected override void OnRenderFrame(FrameEventArgs e)
		{
			/*//.Clear(ClearBufferMask.ColorBufferBit);
			//herramientas.ejes();
			
			
			graficos.dibujar(vertices,indice_c,indice_t);
			graficos.mallado(vertices,indice_c,indice_t);
			
			graficos.esfera(esfera,tam_e);
			herramientas.grilla();
			//herramientas.dibujar_cara(hitbox_Grande,2);
			//herramientas.dividir_en_8(hitbox_Grande,vertices,5); //dibujar hitboxes
			
			SwapBuffers();*/
			
						GL.Clear(
			    ClearBufferMask.ColorBufferBit |
			    ClearBufferMask.DepthBufferBit);
			
			graficos.dibujar(vertices,indice_c,indice_t);
			graficos.mallado(vertices,indice_c,indice_t);
			
			graficos.esfera(esfera,tam_e);
			
			herramientas.grilla();
			
			//herramientas.dibujarHitbox(hitbox_Grande);
			herramientas.DibujarOctree();
			
			SwapBuffers();
		}
		// ...
	
		protected override void OnResize(EventArgs e)
		{
			
			GL.Viewport(0,0,Width,Height);
			float aspectRadio = (float) Width/(float)(Height);
			//Matrix4 perspectiva =Matrix4.CreatePerspectiveFieldOfView(MathHelper);
			Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, aspectRadio, 0.2f, 100.0f);

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref perspectiva);
			
		}
		
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if(e.KeyChar=='x')
			{
				
				px+=incremento;
			}
			
			if(e.KeyChar=='y')
			{
				
				py+=incremento;
			}
			
			if(e.KeyChar=='z')
			{
				
				pz+=incremento;
			}
			
			if(e.KeyChar=='i')
			{
				
				incremento=incremento*-1;
			}
			
			if(e.KeyChar=='c')
			{
				
				tam_e+=-0.1;;
			}
			
			if(e.KeyChar=='g')
			{
				
				tam_e+=0.1;
			}
			//cambiar camara
			if(e.KeyChar=='1')
			{
			    camaraActual=1;
			    CambiarCamara();
			}
			
			if(e.KeyChar=='2')
			{
			    camaraActual=2;
			    CambiarCamara();
			}
			
			if(e.KeyChar=='3')
			{
			    camaraActual=3;
			    CambiarCamara();
			}
			
			if(e.KeyChar=='4')
			{
			    camaraActual=4;
			    CambiarCamara();
			}
						
			base.OnKeyPress(e);
		}
		
		void CambiarCamara()
		{
		    Matrix4 lookAt;
		
		    switch(camaraActual)
		    {
		        // Frontal
		        case 1:
		            lookAt = Matrix4.LookAt(
		                0,0,8,
		                0,0,0,
		                0,1,0);
		        break;
		
		        // Lateral derecha
		        case 2:
		            lookAt = Matrix4.LookAt(
		                8,0,0,
		                0,0,0,
		                0,1,0);
		        break;
		
		        // Vista superior inclinada
		        case 3:
		            lookAt = Matrix4.LookAt(
		                6,6,6,
		                0,0,0,
		                0,1,0);
		        break;
		
		        // Vista trasera
		        default:
		            lookAt = Matrix4.LookAt(
		                0,0,-8,
		                0,0,0,
		                0,1,0);
		        break;
		    }
		
		    GL.MatrixMode(MatrixMode.Modelview);
		    GL.LoadMatrix(ref lookAt);
		}
		
	}

	
}