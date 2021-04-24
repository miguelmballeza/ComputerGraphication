using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreaCartasYAnimaciones : MonoBehaviour
{
    [SerializeField]
    private OrdenarCartas ordenaCartas;

    [SerializeField]
    private Button carta;

    private int juegoMemorama0 = 6; // 3 pares, 6 cartas. 
    private int juegoMemorama1 = 12;
    private int juegoMemorama2 = 18;
    private int juegoMemorama3 = 24;
    private int juegoMemorama4 = 30;

    private List<Button> cartasNivel0 = new List<Button>(); //listas para almcena. botones, por cada uno de los niveles.
    private List<Button> cartasNivel1 = new List<Button>();
    private List<Button> cartasNivel2 = new List<Button>();
    private List<Button> cartasNivel3 = new List<Button>();
    private List<Button> cartasNivel4 = new List<Button>();

    private List<Animator> animacionesNivel0 = new List<Animator>();
    private List<Animator> animacionesNivel1 = new List<Animator>();
    private List<Animator> animacionesNivel2 = new List<Animator>();
    private List<Animator> animacionesNivel3 = new List<Animator>();
    private List<Animator> animacionesNivel4 = new List<Animator>();

    void Awake(){ // justo a la carga de nivel se invoca este.
        CreaCartas();
        ObtenerAnimaciones();
    }

    void Start() {
        AsignarCartasYAnimaciones();
    }

    void CreaCartas() {
        for(int i = 0; i< juegoMemorama0; i++) {
            Button btn = Instantiate(carta);
            btn.gameObject.name = "" + i;
            cartasNivel0.Add(btn);
        }
        for(int i = 0; i< juegoMemorama1; i++) {
            Button btn = Instantiate(carta);
            btn.gameObject.name = "" + i;
            cartasNivel1.Add(btn);
        }
        for(int i = 0; i< juegoMemorama2; i++) {
            Button btn = Instantiate(carta);
            btn.gameObject.name = "" + i;
            cartasNivel2.Add(btn);
        }
        for(int i = 0; i< juegoMemorama3; i++) {
            Button btn = Instantiate(carta);
            btn.gameObject.name = "" + i;
            cartasNivel3.Add(btn);
        }
        for(int i = 0; i< juegoMemorama4; i++) {
            Button btn = Instantiate(carta);
            btn.gameObject.name = "" + i;
            cartasNivel4.Add(btn);
        }
    }

    void ObtenerAnimaciones(){
        for(int i = 0; i< cartasNivel0.Count; i++) {
            animacionesNivel0.Add(cartasNivel0[i].gameObject.GetComponent<Animator>());
            cartasNivel0[i].gameObject.SetActive(false);
        }
        for(int i = 0; i< cartasNivel1.Count; i++) {
            animacionesNivel1.Add(cartasNivel1[i].gameObject.GetComponent<Animator>());
            cartasNivel1[i].gameObject.SetActive(false);
        }
        for(int i = 0; i< cartasNivel2.Count; i++) {
            animacionesNivel2.Add(cartasNivel2[i].gameObject.GetComponent<Animator>());
            cartasNivel2[i].gameObject.SetActive(false);
        }
        for(int i = 0; i< cartasNivel3.Count; i++) {
            animacionesNivel3.Add(cartasNivel3[i].gameObject.GetComponent<Animator>());
            cartasNivel3[i].gameObject.SetActive(false);
        }
        for(int i = 0; i< cartasNivel4.Count; i++) {
            animacionesNivel4.Add(cartasNivel4[i].gameObject.GetComponent<Animator>());
            cartasNivel4[i].gameObject.SetActive(false);
        }
    }

    //
    void AsignarCartasYAnimaciones() {
        ordenaCartas.cartasNivel0 = cartasNivel0; // pasa el valor generado desde el inuicio en la clase de OrdenarCartas.
        ordenaCartas.cartasNivel1 = cartasNivel1;
        ordenaCartas.cartasNivel2 = cartasNivel2;
        ordenaCartas.cartasNivel3 = cartasNivel3;
        ordenaCartas.cartasNivel4 = cartasNivel4;

        ordenaCartas.AnimNivel0 = animacionesNivel0;
        ordenaCartas.AnimNivel1 = animacionesNivel1;
        ordenaCartas.AnimNivel2 = animacionesNivel2;
        ordenaCartas.AnimNivel3 = animacionesNivel3;
        ordenaCartas.AnimNivel4 = animacionesNivel4;
    }

}
