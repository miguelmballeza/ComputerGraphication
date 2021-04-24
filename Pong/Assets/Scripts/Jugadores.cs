using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadores : MonoBehaviour
{
    public KeyCode teclaArriba, teclaAbajo;
    private Rigidbody2D rb2D;
    //permiten obtener la tecla que será asignada alas tecladas declar. poster. en UNity.
    // Start is called before the first frame update
    void Start() {
        rb2D = GetComponent<Rigidbody2D>(); // accede a la fisica que se la asigno al jugador, y almcena. en RB2D.
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(teclaArriba)) {
            rb2D.MovePosition(rb2D.position + (Vector2.up * Time.deltaTime * Juego.velJugador) + new Vector2(0, (float)Pelota.numToques / 100.0f));//arreglarle factor de 20 si es necesario // se va en y hacia arriba una unidad, con ese metodo.
            // se estaria yendo muy rapido el elemento. por eso hicimos esto, la multipl, por una varia .de tiempo.
            // velocidad va a ir a la veloc del refresco de este método.
            //FALTA MODIFICAR LA VELOCIDAD DEL JUGADOR EN FUNCIÓN DE UNA CONDICIÓN INICIAL Y DEL NÚMERO DE TOQUES DE LA PELOTA.
            // A MAYOR DURAC. DE LJUEGO, MAYOR VELOCIDAD, DEPENDIENDO EL NÚMERO DE TOQUES.
        }
        if (Input.GetKey(teclaAbajo)) {
            rb2D.MovePosition(rb2D.position + (Vector2.down * Time.deltaTime * Juego.velJugador) - new Vector2(0, (float)Pelota.numToques / 100.0f)); // se va en y hacia arriba una unidad, con ese metodo.
            // se estaria yendo muy rapido el elemento.
        }
    }
}
