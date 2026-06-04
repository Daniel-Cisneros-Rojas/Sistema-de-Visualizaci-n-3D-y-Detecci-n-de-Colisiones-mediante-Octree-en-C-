# Sistema-de-Visualizacion-3D-y-Deteccion-de-Colisiones-mediante-Octree-en-C-

Este proyecto consiste en una aplicación gráfica desarrollada en C# utilizando OpenTK 1.1 y SharpDevelop, enfocada en la representación de modelos tridimensionales, visualización de estructuras espaciales y detección de colisiones en tiempo real. 

El sistema permite cargar modelos en formato PLY, renderizarlos mediante primitivas OpenGL y realizar pruebas de colisión utilizando una esfera controlada por el usuario. Para optimizar la detección de intersecciones, se implementa una estructura de subdivisión espacial basada en Octree, permitiendo dividir el volumen de trabajo en múltiples regiones cúbicas jerárquicas.

#Características principales
Carga de modelos tridimensionales desde archivos PLY.
Renderizado de polígonos triangulares y cuadrangulares.
Visualización de malla (wireframe).
Representación de esfera móvil para pruebas de colisión.
Generación automática de hitbox global a partir del modelo.
Subdivisión espacial mediante Octree.
Detección de colisiones entre esfera y regiones del Octree.
Cambio dinámico de color durante eventos de colisión.
Visualización de distancia mínima a colisión.
Sistema de iluminación básica.
Múltiples vistas de cámara para inspección de la escena.

#Controles

#Movimiento de la esfera
Tecla	Acción
X	Mover sobre eje X
Y	Mover sobre eje Y
Z	Mover sobre eje Z
I	Invertir dirección del movimiento

#Tamaño de la esfera
Tecla	Acción
G	Aumentar tamaño
C	Disminuir tamaño

#Cámaras
Tecla	Vista
1	Frontal
2	Lateral
3	Isométrica
4	Posterior

#Detección de colisiones

El modelo cargado es encapsulado inicialmente dentro de una caja delimitadora (Hit Box). Posteriormente, esta región se subdivide recursivamente utilizando un esquema Octree.

Cuando la esfera entra en contacto con alguna de las regiones generadas:

La región cambia de color.
Se registra la distancia entre la esfera y la zona de colisión.
Se actualiza la visualización en tiempo real.

Cuando la esfera abandona la región afectada, ésta recupera automáticamente su color predeterminado

<img width="520" height="458" alt="image" src="https://github.com/user-attachments/assets/e3398c60-4817-4da2-bdaa-b7970a249ca6" />


<img width="1247" height="939" alt="image" src="https://github.com/user-attachments/assets/d11aa14e-edd3-4726-957e-83e2e5fce6f7" />

<img width="451" height="471" alt="image" src="https://github.com/user-attachments/assets/ea491ca1-e63c-4ae3-a587-d1f2e4f091ee" />


