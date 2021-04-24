using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuracion : MonoBehaviour
{
    [SerializeField]
    private GameObject menuConfiguracion; // aqui el objeto. en este caso, el panel asociaco  ya en Unity lo arrastramos. 

    [SerializeField]
    private Animator menuConfiguracionAnim; // aqui controlamos su animacion.
    
    public void AbrirMenu() {
        menuConfiguracion.SetActive(true);
        menuConfiguracionAnim.Play("ConfiguracionEntrada");
    }

    public void CerrarMenu() {
        StartCoroutine(EjecutaCerrarMenu()); // lo hicimos de forma indirecta. para poder usar el IENumerator. y suspender ejecución de forma temporal. 
    }

    IEnumerator EjecutaCerrarMenu() {
        menuConfiguracionAnim.Play("ConfiguracionSalida"); // yo no pued omostrar o ocultar el menu hasta que termine esta animación 60 frames = 1 s.
        yield return new WaitForSeconds(1.0f); // por eso primer ejecutamos la animación y después que espere 1 segundo, dado a los 60 frames, para que una vez termine de animarse, ahora si, OCULTE EL MENU DE CONFIG.
        menuConfiguracion.SetActive(false);
    }

}
