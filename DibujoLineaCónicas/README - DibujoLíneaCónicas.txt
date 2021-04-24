CONICAS 

Importante realizar método para reseteo de variables de elementos de la interfaz de usuario, dentro de Unity.
Text, Slider, etc.

Un método por cada botón para poder cambiar el valor de una variable entera y llamar así inmediatamente el método que va a llamar
a los otros métodos específicos para dibujar la opción seleccionada por el botón presionado, todo esto con el uso de Switch Case.

Variables de tipo Text, Slider, Material, Int, Vector3[], float ,etc 
Text para las etiquetas de cada Slider, como del título cambiante de acuerdo al botón seleccionado.
Slider para poder asignarlos adecuadamente dentro de Unity y jugar con ellos de forma dinámica.
Material para poder asignar el valor del Objeto "LineRenderer" .material = materialDeclarado y con valor asignado desde Unity.
Int para la variable que cambiara de acuerdo a cada botón presionado, y también para la RESOLUCIÓN, que no es más que el conjunto
de punto a vectores 3d ( segmentos de recta en 3 dimensiones ) que serán utilizados por la variable de tipo Vector3[].
Vector3[], arreglo de vectores de 3 dimensiones, o como ya se menciono, también son puntos, ya que un vector en su forma más simple
es un punto en tres dimensiones, en este caso de tipo de Variable.
float para los valores que se estarán asignando para cada valor de forma dinámica, cambiado desde los Sliders. 
y listo.

Método de DibujarConicas, que es al que se llamará, una vez se presionaron uno de los botones, para asi trabajar con el Switch Case, 
de acuerdo al botón específico seleccionado. 
Dentro de este método, se coloca un ciclo condicional para que se entre una vez se este por sentado que se presiono un botón,
es decir, !0 ( 0 fue el valor inicial declarado como arranque) . Y dentro de cada Case : ahora si :
se declara Variable de tipo LineRenderer para poder DIBUJAR LINEAS FLOTANTES LIBRES, PARA CADA CÓNICA O LÍNEA RECTA. 

Se debe colocar además, el valor flotando de forma dinámica de cada Slider asociado correctamente, desde Unity.
AHORA SI, en cada caso debe incluir :
* Texto de título principal, NO INCLUIDO EN EL MÉTODO DE RESETEO.
* asignación de materiales por objeto LineRenderer, clase "material" a las variables material anteriormente declaradas.
* EJECUCIÓN DEL MÉTODO PARA RESETEO DE ELEMENTOS DE INTERFAZ DE USUARIO.
* Textos que se visualizaran y como se mostrara, es decir, con que textos ?.
* MANDAR A LLAMAR Y A ASIGNAR A LA VARIABLE DE TIPO Vector3[] de forma simultanea, al método correspondiente de acuerdo al case
en cuestión, y eso de acuerdo al botón presionado, usando los valores flotantes de nuestros Sliders, de forma dinámica, como parametros
para nuestro método llamado.
*BREAK;

AL FINALIZAR CADA CASE DEL SWITH CASE, entonces tenemos que VACIAR LO QUE TENEMOS EN NUESTRO Vector3, en el Objeto LineRenderer.
con un for de 0 a la <= a la resolución, para poder abarcar todo lo declarado.


Y CLARO, LOS MÉTODOS PARA DIBUJAR, CADA UNO CONTENDRA DE LEY:

* Arreglo Vector3 inicializado con el número de elementos de RESOLUCIÓN+1.
* valores flotantes necesarios, ejemplo, la recta necesita delta x y delta y, para poder ejecutar su algorit. matematico parametrización
* En ocasiones, se requiere traslación en x y y, para Circunferencia, Elipse, Parábola e Hiperbola.
	Se necesita otro Vector3, con los valores de x y y a desplazar con h y k, correspondientemente.
* En ocasiones, se requiere rotación, para eso declara una variable de tipo Quaternion, con el método AngleAxis, con parametro de TETHA y
CON EL DEL EJE DEL ANGULO A TRATAR.
	Este método de AngleAxis, lo que nos permite es devolver un valor de retorno de Rotación de grados del angulo alrededor del eje,
	Se utiliza como Eje, la función "Vector3.forward" que es la representación de un Vector de 3 Dimensiones en su forma (0,0,1).
* Ciclo for que va de 0 a <= resolucion, donde EN OCASIONES, circun, elip, para, hiperb se calculara ANGULO : 
	float angulo = ((float) i / (float) resolucion) * 2.0f * Mathf.PI;  
EN OTRAS SOLO SE COLOCA LA Inicialización de Vector3[i] para poder asignarles con los parametros lo necesario para su representación.
	para la línea recta : posPuntos[i] = new Vector3(ax+dx*(i/resolucion), ay+dy*(i/resolucion), 0);

	Circunferencia : posPuntos[i]= new Vector3(r*Mathf.Cos(angulo), r*Mathf.Sin(angulo), 0);
	más su traslación en x y y : posPuntos[i]= posPuntos[i] + centro;

	Elipse : posPuntos[i]= new Vector3(a*Mathf.Cos(angulo),b*Mathf.Sin(angulo), 0); 
	Más su rotación y traslación (variable llamada centro) en su eje angular :  posPuntos[i]= q * posPuntos[i] + centro;

	Parábola: posPuntos[i]= new Vector3(i-(resolucion/2), (1/(4*p))*Mathf.Pow(i-(resolucion/2), 2), 0);
	Más su rotación y traslación (variable llamada centro) en su eje angular :  posPuntos[i]= q * posPuntos[i] + vertice; 

	Hiperbola: posPuntos[i]= new Vector3(a/Mathf.Cos(angulo),b*Mathf.Tan(angulo), 0);
	Más su rotación y traslación (variable llamada centro) en su eje angular :  posPuntos[i]= q * posPuntos[i] + centro;


LISTO
	
