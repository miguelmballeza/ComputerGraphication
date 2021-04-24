using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetupMemorama : MonoBehaviour
{
    [SerializeField]
    private AdministrarMemorama administradorMemorama;

    //aqui ya necesitamos como tal, dibujar las respectivas cartas, animales, monstruos y robots.
    private Sprite[] sprAnimales, sprMonstruos, sprRobots; // aqui se pondran las imagenes de las cartas de cada uno de los juegos.
    private List<Sprite> spritesMemorama = new List<Sprite>();
    private List<Button> botonesMemorama = new List<Button>(); //para botones.
    private List<Animator> animacionesMemorama = new List<Animator>(); // para animac.

    private int nivel;
    private int limiteLoop;
    private string memoramaSeleccionado;

    void Awake() { // los sprites seran mapeados a lo que tenemos nosotros en nuestras respect imagen, se leera la ruta completa de la carpeta de Resources.
        sprAnimales = Resources.LoadAll<Sprite>("Cartas/animales");
        sprMonstruos = Resources.LoadAll<Sprite>("Cartas/monstruos");
        sprRobots = Resources.LoadAll<Sprite>("Cartas/robots");
    }

    void PreparaSpritesJuego () {
        spritesMemorama.Clear(); // primero se limpia, ya que se jugara varias veces.
        spritesMemorama = new List<Sprite>();
        int indice = 0;

        switch(nivel){ // limite que me va a permitir dibujar por nivel, la carga de 50 imag, por carpeta NO, solo los deseados, dependiendo el nivel seleccionado.
            case 0:
                limiteLoop = 6;
            break;
            case 1:
                limiteLoop = 12;
            break;
            case 2:
                limiteLoop = 18;
            break;
            case 3:
                limiteLoop = 24;
            break;
            case 4:
                limiteLoop = 30;
            break;
        }

        switch(memoramaSeleccionado){
            case "btnAnimales":

                for(int i = 0; i<limiteLoop; i++){ // solo dibujar las cartas necesarias.
                    //3 pares distintos de cartas, son 6, necesito que se dibujen dos veces.
                    if(indice == (limiteLoop/2)){
                        indice = 0;
                    }
                    spritesMemorama.Add(sprAnimales[indice]);
                    indice++;
                }

                break;
            case "btnMonstruos":

                for(int i = 0; i<limiteLoop; i++){ // solo dibujar las cartas necesarias.
                    //3 pares distintos de cartas, son 6, necesito que se dibujen dos veces.
                    if(indice == (limiteLoop/2)){
                        indice = 0;
                    }
                    spritesMemorama.Add(sprMonstruos[indice]);
                    indice++;
                }

                break;
            case "btnRobots":

                for(int i = 0; i<limiteLoop; i++){ // solo dibujar las cartas necesarias.
                    //3 pares distintos de cartas, son 6, necesito que se dibujen dos veces.
                    if(indice == (limiteLoop/2)){
                        indice = 0;
                    }
                    spritesMemorama.Add(sprRobots[indice]);
                    indice++;
                }
                break;
                //necesitan que sea de forma ALEATORIA.
        }
        Barajar(spritesMemorama);
    }

    void Barajar(List<Sprite> lista){
        for(int i = 0; i < lista.Count; i++){
            Sprite temp = lista[i]; // vamos a suponer que almacene el dibujo de una vaca, y que este en la primera iteracion en pos 0.
            int indiceAleatorio = Random.Range(i,lista.Count); // random que se genera entre el inice y el no de elementos, me permite generar el nu aleat ej = 3.
            lista[i] = lista[indiceAleatorio]; // la posic 0 de la lista es igual a lista pos = 3. Lista[0] = Lista[3] ( perro)
            lista[indiceAleatorio] = temp; // lista[3] = vaca. Y ASI CAMBIO EL DIBUJO DE LA VACA CON EL DIBUJO DEL PERRO. 
        }
    }

    public void AsignaNivelyMemorama(int nivel, string memoramaSeleccionado){ //
        this.nivel = nivel;
        this.memoramaSeleccionado = memoramaSeleccionado;
        PreparaSpritesJuego();
        administradorMemorama.AsignaSpritesMemorama(spritesMemorama);
    }

    public void AsignaBotonesyAnimaciones(List<Button> botonesMemorama, List<Animator> animacionesMemorama){
        // encargado de asign boto y boto a memor con sus respecti animaciones.
        this.botonesMemorama = botonesMemorama;
        this.animacionesMemorama = animacionesMemorama;
        administradorMemorama.AsignaBotonesyAnimaciones(botonesMemorama, animacionesMemorama);
    }


}
