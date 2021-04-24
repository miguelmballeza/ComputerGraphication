using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAComputadora : MonoBehaviour
{
    //Config. FACIL INTERM Y EXPER, CON UNA VARIA STATIC QUE CONFIG VELOCIDAD INICIAL, DE LA PC Y DE LOS JUGADORES SI SE SELECCIONAN AMBOS.
    // RAPIDO AMBOS EN VERTICAL LOS JUGADORES Y PELOTA EN SI MÁS RÁPIDA.

    public GameObject jugadorDer; // este jugador se va a estar moviendo, le pego el vector3towards, con transform moveposition.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Settings.tipoJuego == 1){ // se juega contra la PC.
            //aqui va el vector 3.
            //Vector3.MoveTowards();
            //transform.position.y
            //SE DEBE HACER QUE EL JUGADOR DE LA DERECHA SE MUEVA EN Y SIGUIENDO LA PELOTA, Y ESTO DEPENDERA DE LA DIFICULTAD EN EL SCRIPT DE "Settings".
        }
    }
}
