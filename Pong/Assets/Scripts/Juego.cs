using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Juego : MonoBehaviour
{
    public AudioSource audio; // aqui es Publico, en lo otro privado, para ver como se hace.
    public AudioClip sndSilbato, sndGameOver;
    public Text txtGameOver;
    private GameObject txtMarcador;
    // GameObject padre de todos los elementos.
    private GameObject pelota;
    public static float velBola = 5.0f, velJugador = 4.5f; // para que tengan velocidades difere. y se pueda perder más facilmente. 
    // para acceder a esta var. desde otra clase.
    public int signo1, signo2, velocidad = 1; // signos para modifica de forma dina para mov vert o horiz.
    //signo1 afecta en x, signo2 afecta dirección en y.


    // Start is called before the first frame update
    void Start() {
        txtGameOver.gameObject.SetActive(false);
        //instr. para probar el programa : para ver si sirve o no :
        //Debug.Log("Ejecuta método Start");
        audio = GetComponent<AudioSource>();
        pelota = GameObject.Find("pelota");
        txtMarcador = GameObject.Find("txtMarcador");
        txtMarcador.GetComponent<Text>().text = "0 - 0";

        if (Random.Range(0,1) > 0.5f) {
            signo1 = 1; // se va a la derecha .
        } else {
            signo1 = -1; // se va a la izquierda, a mi parecer.
        }
        //corutina, para desfazar el inicio para el audio del silbato e inicio del juego.
        StartCoroutine(ArbitroPitaInicio());
        //StartCoroutine("ArbitroPitaInicio"); puede ser por esta tambien, el llamado de corutina.
    }

    // Update is called once per frame
    void Update()
    {
        //60 frames por segundo, este método se ejecuta.
        if(Pelota.golesJugadorDer == 3 || Pelota.golesJugadorIzq == 3){
            if(Input.anyKey){
                SceneManager.LoadScene("Menu");
                Pelota.golesJugadorDer=0;
                Pelota.golesJugadorIzq=0;
            }
        }
        if(Input.GetKey(KeyCode.Escape)) {
                SceneManager.LoadScene("Menu");
                Pelota.golesJugadorDer=0;
                Pelota.golesJugadorIzq=0;
        }
    }

    IEnumerator ArbitroPitaInicio() {
        yield return new WaitForSeconds(1.0f); // se espera 4s mientras se reproduce el sonido.
        audio.clip = sndSilbato;
        audio.Play(); // aqui se ejecuta el audio anterior.
        LanzaPelota();
    } // generación de corutina.

    public void LanzaPelota() {
        pelota.transform.position = gameObject.transform.position = new Vector3(0, 0, 0); // puede ser 3.0
        signo2 = Random.Range(0,1) > 0.5f ? 1 : -1; // instrucción de if else, poderosa.
        // ahora par decirle que se mueva es :
        pelota.GetComponent<Rigidbody2D>().velocity = new Vector2(signo1*velocidad, signo2*velocidad);
        // pendiente unitaria, un angulo de 45grados. MOVERLA EN DIAGONAL, POR DECIRLO ASI, HACIA LAS 4 ESQUINAS DE LA PANTALLA.

    }

    public void EscribeMarcador() {
        txtMarcador.GetComponent<Text>().text = Pelota.golesJugadorIzq.ToString() + " - " + Pelota.golesJugadorDer.ToString();
        if(Pelota.golesJugadorDer == 3 || Pelota.golesJugadorIzq == 3) {
            txtGameOver.gameObject.SetActive(true);
            audio.clip=sndGameOver;
            audio.Play();
        } else {
            StartCoroutine(ArbitroPitaInicio()); // vuelve a lanzar la pelota si no se ha ganado, es decir, ninguno a llegado a los 3 goles. 
        }
    }


}
