using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Conicas : MonoBehaviour
{
    
    public Text txtConicas; 
    public Slider sl_a,sl_b,sl_h,sl_k,sl_t;
    public Text lbl_a,lbl_b,lbl_h,lbl_k,lbl_t;

    public Material matLinea, matCircunferencia, matParabola, matElipse, matHiperbola;
    private int conicaSeleccionada=0; // 0.- Sin selección, 1.- Recta, 2.- Circunferencia, 3.- Elipse, 4.- Parábola, 5.- Hipérbola.
    private int resolucion = 1000; // manejaremos esa reolusion, pero puede ser más.
    private Vector3[] posPuntos;
    private float a, b, h, k, tetha;
    public void DibujaConicas() {
        if(conicaSeleccionada != 0) {
            LineRenderer lr = GetComponent<LineRenderer>();
            #pragma warning disable CS0618 // The type or the member are obsolete.
            lr.SetVertexCount(resolucion + 1); //vertices o puntitos que estaré dibujando con este objeto LineRenderer.
            //De mi objeto que es "Conicas" aacede a sus propiedades/componentes, y trae LineRenderer. TODO ESTO CON GetComponents.
            a = sl_a.value; // este valor se alimentara de forma dinámica, agarrara el valor dependiendo del valor del Slider.
            b = sl_b.value;
            k = sl_k.value;
            h = sl_h.value;
            tetha = sl_t.value;
        switch(conicaSeleccionada) {
            case 1:
                txtConicas.text = "Recta";
                lr.material = matLinea;
                MuestraSlidersYEtiquetas();
                lbl_a.text = "ax";
                lbl_b.text = "ay";
                lbl_h.text = "bx";
                lbl_k.text = "by";
                sl_t.gameObject.SetActive(false);
                lbl_t.gameObject.SetActive(false);
                posPuntos = CrearRecta(a, b, h, k, resolucion);
                break;
                //VISUALIZANDO ax, ay, bx y by.
            case 2:
                txtConicas.text = "Circunferencia";
                lr.material = matCircunferencia;
                MuestraSlidersYEtiquetas();
                lbl_a.gameObject.SetActive(false);
                sl_a.gameObject.SetActive(false);
                sl_t.gameObject.SetActive(false);
                lbl_t.gameObject.SetActive(false);
                lbl_b.text = "r";
                posPuntos = CrearCircunferencia(b, h, k, resolucion);
                break;
                //VISUALIZANDO r, h y k.
            case 3:
                txtConicas.text = "Elipse";
                lr.material = matElipse;
                MuestraSlidersYEtiquetas();
                posPuntos = CrearElipse(a, b, h, k, tetha, resolucion);
                break;
                //VISUALIZANDO a, b, h, k y t.
            case 4:
                txtConicas.text = "Parábola";
                lr.material = matParabola;
                MuestraSlidersYEtiquetas(); // reseteo de los Sliders y Etiquetas.
                lbl_a.gameObject.SetActive(false);
                sl_a.gameObject.SetActive(false);
                lbl_b.text = "p";
                posPuntos = CrearParabola(b, h, k, tetha, resolucion);
                //VISUALIZANDO p, h y k.
                break;
            case 5:
                txtConicas.text = "Hipérbola";
                lr.material = matHiperbola;
                MuestraSlidersYEtiquetas();
                posPuntos = CrearHiperbola(a ,b, h, k, tetha, resolucion);
                break;
                //VISUALIZANDO a, b, h, k y t.
        } 
        for(int i=0; i<=resolucion; i++) {
            // VE LO QUE TENGO EN EL VECTOR DE 3 DIMENSIONES, AHORA SI LO VACIO AL LineRenderer.
            lr.SetPosition(i,posPuntos[i]); // ASI YA SE DIBUJARAN LOS PUNTOS DE LA LINEA RECTA, CIRCUN, ELIPSE, ETC. TODO.
            // objeto LineRenderer, ya se le dice que lo almacene en i, con la posic. de x y y, de todas las cónicas y la línea recta.
        }
        }
    }

    public void BtnRecta() {
        conicaSeleccionada=1;
        DibujaConicas();
    }


    Vector3[] CrearRecta(float ax, float ay, float bx, float by, int resolucion) {
        //resolucion, para ver con CUANTOS PUNTOS se estará dibujando, en este caso, la línea recta.
        //Vector3[] por que regresara un vector en 3 dimensiones en 'x','y' y 'z'.
        //VAMOS A CODIFICAR EN BASE A SU ALGORITMO MATEMATICO PARAMETRIZADO.
        // VECTOR DIRECTOR, Y VECTOR DE POSICIO. CUALQUIER DE UN PUNTO DE LA LÍNEA RECTA.
        posPuntos = new Vector3[resolucion + 1] ;
        //Vector de 3 dimensiones llamado "posPuntos" podrá almacenar "resolucion" elementos, declara su tamaño del Vector en otras palabras.
        // el + 1 para acceder a ellos con una iteración de ciclo for, para desfazarlo con respecto a 0, con el que se inicia con cada uno de los Vectores en Unity.
        float dx=bx - ax;
        float dy=by-ay; // YA TENGO EL DELTA Y Y DELTA X, PARA SACAR LA PENDIENTE DE LA LÍNEA RECTA.
        //vamos a dibujar los puntos de mi línea recta :
        // AX Y AY, SE LA SUMARÁ EL VECTOR DIRECTOR MULTIPLI POR CIERTA ITERAC. DEL FOR, PARA PODER DIBUJAR CON ESE PUNTO AX Y AY, TODOS Y CADA UNO DE LOS PUNTOS RESTANTES DE LA LÍNEA RECTA.
        for(int i=0; i<=resolucion; i++) { // 
            posPuntos[i] = new Vector3(ax+dx*(i/resolucion), ay+dy*(i/resolucion), 0); // AX se la suma el DX, es decir, cuanto se esta desplazando en X, y se muliplicará por "i" es el valor de iterac. ENTRE la resolucion.
            // LO QUE SE HACE, ES QUE A UN PUNTO INICIAL SE SUMA UN DESPLAZAMIENTO, ESE DESPALZA. SE MULTIPL UN VALOR DE 0 HASTA RESOLUCION, SI ES DIVIDI ENTRE LA RESOLU, SE OBTENDRA UN VALOR ENTRE 0 Y 1 .
            // CUANDO i = resolu, será 1, es decir, ax + desplaza total en X y CON ESO SE LLEGARÁ AL PUNTO FINAL DE LA LÍNEA RECTA.
            // CONCLUSION : Cuando i/resolucion sea igual a 1, entonces la suma de ax y dx será igual a la del ultimo punto de la recta, es decir, en este caso bx. Y CON Y ES EXACTAMENT. LO MISMO. 
            // Y ASI SE HACE EL BARRIDO POR COMPLETO CON ESE ALGORTIMO MATEMÁTICO, PARA ese vector de 3 dimensiones.

        }
        return posPuntos;
    }

    public void BtnCircunferencia() {
        conicaSeleccionada=2;
        DibujaConicas();
    }

    Vector3[] CrearCircunferencia(float r, float h, float k, int resolucion) {
        posPuntos = new Vector3[resolucion + 1] ;
        Vector3 centro = new Vector3(h, k, 0);
        for(int i=0; i<=resolucion;i++) {
            //ANGULO CON EL QUE TRABAJRE MIS FUNC. TRIGONOMETRICAS :
            float angulo = ((float) i/ (float) resolucion) * 2.0f * Mathf.PI;   //2PI son los 360 grados, en Unity funcionan en Rad, Vamos a manejar una fraccion de 2PI que vaya relacionado con el valor del indice i y con la iteraci. corresp. del ciclo.
            // este resultado dará un cocien de 0-1 que se multiplicara por 2.0f y 2PI, es decir, se va a estar escribiendo fracciones de 2PI, cuando sea max será 2PI y menor será 0, de 0 a 2PI.
            // que sería nuestro conjunto de valores para Tetha, ES DECIR , 0 < tetha < 2PI.
            posPuntos[i]= new Vector3(r*Mathf.Cos(angulo), r*Mathf.Sin(angulo), 0); // YA SE TENDRÍAN LAS COMPONENTES EN X y en Y, y en Z que es cero en este caso.
            //Gracias a la ecuac. cartesiana en su forma ordinaria de la circunferencia, podemos trazar esta circunferencia de forma gráfica, conforme va cambiando su radio, a través del correspondiente Slider.
            posPuntos[i]= posPuntos[i] + centro; // y asi se tiene además en cosideración los valores de k y h generados, igualmente, por los correspondientes Sliders.
        }
        return posPuntos;
    }

    public void BtnElipse() {
        conicaSeleccionada=3;
        DibujaConicas();
    }

    Vector3[] CrearElipse(float a, float b, float h, float k, float theta, int resolucion) {
        posPuntos = new Vector3[resolucion + 1];
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward); // 
        Vector3 centro = new Vector3(h, k, 0);
        for(int i=0; i<=resolucion;i++) {
            float angulo = ((float) i / (float) resolucion) * 2.0f * Mathf.PI;  
            posPuntos[i]= new Vector3(a*Mathf.Cos(angulo),b*Mathf.Sin(angulo), 0); 
            posPuntos[i]= q * posPuntos[i] + centro;
        }
        return posPuntos;
    }

    public void BtnParabola() {
        conicaSeleccionada=4;
        DibujaConicas();
    }

    Vector3[] CrearParabola(float p, float h, float k, float theta, int resolucion) {
        posPuntos = new Vector3[resolucion + 1] ;
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);  // FALTA SABER EL SIGNIFICADO EXPECÍFICO 
        Vector3 vertice = new Vector3(h, k, 0); // para que desplace en h y k lo que se reciba, pero se va a modif. el vertice de nuestra parabola.
        for(int i=0; i<=resolucion;i++) {
            float angulo = ((float) i/ (float) resolucion) * 2.0f * Mathf.PI;   
            posPuntos[i]= new Vector3(i-(resolucion/2), (1/(4*p))*Mathf.Pow(i-(resolucion/2), 2), 0); // falta la ecuac. para parametri la parabola.
            // cuando llegue a la mitad de la resoluci, estara en la componen 0 de x, es decir, vertice, entonces ... 
            // 
            posPuntos[i]= q * posPuntos[i] + vertice; // y asi se tiene además en cosideración los valores de k y h generados, igualmente, por los correspondientes Sliders.
        }
        return posPuntos;
    }

    public void BtnHiperbola() {
        conicaSeleccionada=5;
        DibujaConicas();
    }

    Vector3[] CrearHiperbola(float a, float b, float h, float k, float theta, int resolucion) {
        posPuntos = new Vector3[resolucion + 1] ;
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);
        Vector3 vertice = new Vector3(h, k, 0);
        for(int i=0; i<=resolucion;i++) {
            float angulo = ((float) i / (float) resolucion) * 2.0f * Mathf.PI;  
            posPuntos[i]= new Vector3(a/Mathf.Cos(angulo),b*Mathf.Tan(angulo), 0);
            posPuntos[i]= q * posPuntos[i] + vertice;
        }
        return posPuntos;
    }

    public void MuestraSlidersYEtiquetas() {
        /*
        FUncion para redibujar lo que es necesario o no, 
        SLIDERS Y ETIQUETAS ADECUADAS QUE UTILIZARPE DE 
        ACUERDO A LA RECTA O CÓNICA SELECCIONADA.
        */
        //GameObject componente, para decirle que no se muestre, para setActive.
        sl_a.gameObject.SetActive(true);
        sl_b.gameObject.SetActive(true);
        sl_h.gameObject.SetActive(true);
        sl_k.gameObject.SetActive(true);
        sl_t.gameObject.SetActive(true);

        lbl_a.gameObject.SetActive(true);
        lbl_b.gameObject.SetActive(true);
        lbl_h.gameObject.SetActive(true);
        lbl_k.gameObject.SetActive(true);
        lbl_t.gameObject.SetActive(true);

        lbl_a.text = "a";
        lbl_b.text = "b";
        lbl_h.text = "h";
        lbl_k.text = "k";
        lbl_t.text = "t";
        //por default tambien se colocan las etiquetas o labels.
        
    }



}
