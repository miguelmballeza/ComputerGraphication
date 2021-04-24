using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Juego miJuego;
    private AudioSource audio; // Como el reproductor de sonidos ( stereo )
    public AudioClip snd1, snd2, sndGol, sndPared; // USB, discos. etc.
    public static int numToques = 0, golesJugadorIzq = 0, golesJugadorDer =0;
    // Start is called before the first frame update
    void Start() {
        audio = GetComponent<AudioSource>();
        miJuego = GameObject.Find("Juego").gameObject.GetComponent<Juego>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D colision) { // verifica con que colisiona la pelota.
        float compX, compY;

        if(colision.CompareTag("gol")){ // Colision con porterias, para marcar los goles.
            //Debug.Log("gol");
           audio.clip = sndGol;
           audio.Play();
           numToques = 0;
           GameObject nombrePorteria = colision.gameObject;
           if(nombrePorteria.name == "porteriaIzq"){
               golesJugadorDer++;
           } else if (nombrePorteria.name == "porteriaDer") {
               golesJugadorIzq++;
           }
           miJuego.EscribeMarcador();
        }
        if(colision.CompareTag("jugadorIzq")){
            audio.clip = snd1;
            audio.Play();
            numToques ++;
            // altura de la colision :
            float alturaColisionIzq = GameObject.Find("jugadorIzq").gameObject.transform.position.y - transform.position.y;
            // primera posic. en y del jugador de la izquierda, y la otra ...
            // para determin si es arriba ,en la mitad, o abajo la colisi con el objeto.
            compX = Mathf.Cos(alturaColisionIzq); // colis a la mitad x = 1, y = 0, por las ident. trign con ese valor del angulo. 0. cos(0) = 1,  y sen(0) = 0
            compY = Mathf.Sin(alturaColisionIzq);
            if(alturaColisionIzq >= 0) {
                //si colisi de la mitad para arriba, entonces se pondra un angulo positivo, para que regresa a la parte superior.
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * Juego.velBola + numToques, compY * (Juego.velBola * -1) - numToques/2); // se va a modiifi aparte por num de toques y velocid de la pelota.
            } else {
                // caso contrario.
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * Juego.velBola + numToques, compY * (Juego.velBola * -1) + numToques/2);
            }
            Debug.Log("CompY : " + compY);
            //Debug.Log("jugadorIzq");

        }
        if(colision.CompareTag("jugadorDer")){
            audio.clip = snd2;
            audio.Play();
            numToques ++;



            float alturaColisionDer = GameObject.Find("jugadorDer").gameObject.transform.position.y - transform.position.y;
            // primera posic. en y del jugador de la izquierda, y la otra ...
            // para determin si es arriba ,en la mitad, o abajo la colisi con el objeto.
            compX = Mathf.Cos(alturaColisionDer); // colis a la mitad x = 1, y = 0, por las ident. trign con ese valor del angulo. 0. cos(0) = 1,  y sen(0) = 0
            compY = Mathf.Sin(alturaColisionDer);
            if(alturaColisionDer >= 0) {
                //si colisi de la mitad para arriba, entonces se pondra un angulo positivo, para que regresa a la parte superior.
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * (Juego.velBola * -1) - numToques, compY * (Juego.velBola * -1) -numToques/2); // se va a modiifi aparte por num de toques y velocid de la pelota.
            } else {
                // caso contrario.
                GetComponent<Rigidbody2D>().velocity = new Vector2(compX * (Juego.velBola * -1) - numToques, compY * (Juego.velBola * -1) + numToques/2);
            }
            Debug.Log("CompY : " + compY);


            //Debug.Log("jugadorDer");
        }
        if(colision.CompareTag("pared")){
            audio.clip = sndPared;
            audio.Play();
            //Debug.Log("pared");
        }
    }



}
