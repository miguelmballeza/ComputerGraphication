using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdministrarMemorama : MonoBehaviour
{
    private List<Button> botonesMemorama = new List<Button>();
    private List<Animator> animacionesMemorama = new List<Animator>();

    [SerializeField]
    private JuegoTerminado juegoTerminado;

    [SerializeField]
    private List<Sprite> spriteMemorama = new List<Sprite>();

    private int nivel;
    private string memoramaSeleccionado;

    private bool primeraEleccion, segundaEleccion;
    private int indicePrimeraEleccion, indiceSegundaEleccion;
    private string primeraCartaElegida, segundaCartaElegida;
    private Sprite imagenTraseraCarta;

    private int cuentaIntentos;
    private int paresCorrectos;
    private int paresTotalesxJuego;

    public void SeleccionaUnMemorama() {

        if(!primeraEleccion){
            primeraEleccion = true;

            this.indicePrimeraEleccion = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            Debug.Log("Ipe : "+this.indicePrimeraEleccion);
            primeraCartaElegida = spriteMemorama[indicePrimeraEleccion].name;

            StartCoroutine(VolteaCarta(
            animacionesMemorama[indicePrimeraEleccion],
            botonesMemorama[indicePrimeraEleccion],
            spriteMemorama[indicePrimeraEleccion]
        ));

        } else if(!segundaEleccion){
            segundaEleccion = true;

            this.indiceSegundaEleccion = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            Debug.Log("Ise : "+this.indiceSegundaEleccion);
            segundaCartaElegida = spriteMemorama[indiceSegundaEleccion].name;

            StartCoroutine(VolteaCarta(
            animacionesMemorama[indiceSegundaEleccion],
            botonesMemorama[indiceSegundaEleccion],
            spriteMemorama[indiceSegundaEleccion]
        ));
        cuentaIntentos++;
        StartCoroutine(ChecarCartasIguales(imagenTraseraCarta));

        }
        
    }

    IEnumerator ChecarCartasIguales(Sprite imagenTraseraCarta) {
        yield return new WaitForSeconds(2.5f);
        if(primeraCartaElegida==segundaCartaElegida){
            //Debug.Log("CartasIguales");
            animacionesMemorama[indicePrimeraEleccion].Play("DesaparecerCarta"); // OJO.
            animacionesMemorama[indiceSegundaEleccion].Play("DesaparecerCarta"); // OJO.
            ChecaSiElJuegoTermino();
            //Aumenta el marcador de cartas elegidas correctamente.
        } else {
            Debug.Log("CartasDiferentes");
            StartCoroutine(RegresaCarta(
                animacionesMemorama[indicePrimeraEleccion], 
                botonesMemorama[indicePrimeraEleccion],
                imagenTraseraCarta
            ));
            StartCoroutine(RegresaCarta(
                animacionesMemorama[indiceSegundaEleccion], 
                botonesMemorama[indiceSegundaEleccion],
                imagenTraseraCarta
            ));
        }
        //ChecaSiElJuegoTermino();
        yield return new WaitForSeconds(1.0f);
        //sea cual fuere el caso, vuelva a regresar a mis variables de mi primera y segunda eleccion, regresen a false. para que pueda seguir funcuonando.
        primeraEleccion = segundaEleccion = false;
    }

    void ChecaSiElJuegoTermino(){
        paresCorrectos++;
        if(paresCorrectos==paresTotalesxJuego){
            //Debug.Log("Terminó El Juego.");
            RevisaNumeroIntentos();
        }
    }

    IEnumerator VolteaCarta(Animator anim, Button btn, Sprite imagenCarta) {
        anim.Play("VoltearCarta"); // OJO . exact igual que en unity.
        yield return new WaitForSeconds(0.4f);
        btn.image.sprite = imagenCarta;

    }

    IEnumerator RegresaCarta(Animator anim, Button btn, Sprite imagenCarta){
        anim.Play("RegresarCarta");
        yield return new WaitForSeconds(0.4f);
        btn.image.sprite = imagenCarta;

    } //para que se regrese la carta. este es el segundo estado, el de arriba es para que se volte primero

    void AgregaListeners() {
        // primer seremueventodos los listeners, estos ayudan a obtener la info de los clicks, aqui sera la info de los botones.
        foreach (Button btn in botonesMemorama) {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => SeleccionaUnMemorama()); // boton al del click ,s e agrega un list, mapeado con la funcion : selecciona un memorama. 
            
        }
    }

    public void AsignaBotonesyAnimaciones(List<Button> botones, List<Animator> animaciones) {
        this.botonesMemorama = botones;
        this.animacionesMemorama = animaciones;
        this.paresTotalesxJuego = botonesMemorama.Count / 2;
        //decir cual va a ser la imagen trasera de la carta con :
        imagenTraseraCarta = botonesMemorama[0].image.sprite;
        // además agregamos los listeners. para cuando se den click cargue el  metodo .
        AgregaListeners();
    }

    public void AsignaSpritesMemorama(List<Sprite> spritesMemorama){
        this.spriteMemorama = spritesMemorama;
    }

    public void AsignaNivel(int nivel) {
        this.nivel = nivel;
    }

    public void AsignaMemoramaSeleccionado(string memoramaSeleccionado){
        this.memoramaSeleccionado = memoramaSeleccionado;
    }

    void RevisaNumeroIntentos(){
        int limiteIntentos = 0;
        switch(nivel) {
            case 0:
                limiteIntentos = 5;
                break;
            case 1:
                limiteIntentos = 10;
                break;
            case 2:
                limiteIntentos = 15;
                break;
            case 3:
                limiteIntentos = 20;
                break;
            case 4:
                limiteIntentos = 25;
                break;

        }

        if(cuentaIntentos <= limiteIntentos){
            juegoTerminado.MuestraPanelJuegoTerminado(3);
        } else if(cuentaIntentos > limiteIntentos && cuentaIntentos <=limiteIntentos + 5){ // para dos estrellas, 5 intentos extras.
            juegoTerminado.MuestraPanelJuegoTerminado(2);
        } else {
            juegoTerminado.MuestraPanelJuegoTerminado(1);
        }
    }

    public List<Animator> ResetJuego() {
        primeraEleccion = segundaEleccion = false;
        cuentaIntentos = 0;
        paresCorrectos = 0;
        juegoTerminado.OcultaPanelJuegoTerminado();
        return animacionesMemorama;
    }

}
