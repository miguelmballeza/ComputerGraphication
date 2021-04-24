using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public static int tipoJuego = 1; // 1.- Jugar contra la computadora . 2.- Jugar contra otro jugador.
    public Text señalaOp1, señalaOp2;
    // Start is called before the first frame update
    void Awake() { // este método se carga justo al inicio del juego, previo al primer frame
    // y start después del primer frame.
        tipoJuego = 1;
        señalaOp1.gameObject.SetActive(true); // muestra opcion 1 por default.
        señalaOp2.gameObject.SetActive(false); // oculta la opción dos.

    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1)) {
            BorraSeñalizacionOpciones();
            señalaOp1.gameObject.SetActive(true);
            tipoJuego = 1;
        }
        if(Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2)) {
            BorraSeñalizacionOpciones();
            señalaOp2.gameObject.SetActive(true);
            tipoJuego = 2;
        }
        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("Main");
        }
    }

    public void BorraSeñalizacionOpciones() {
        señalaOp1.gameObject.SetActive(false);
        señalaOp2.gameObject.SetActive(false);
    }


}
