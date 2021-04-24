using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionarMemorama : MonoBehaviour
{

    [SerializeField]
    private AdministrarMemorama administradorMemorama;

    //puede ser privada, pero en unity teendría que serializarse.
    [SerializeField]
    private GameObject menuSeleccionJuego, menuSeleccionNivel; // aqui el objeto. Jalamos las propiedades físicas del objeto desde Unity. 

    [SerializeField]
    private Animator menuSeleccionJuegoAnim, menuSeleccionNivelAnim; // aqui controlamos su animacion. Jalamos las propiedades de Animación desde Unity.
    [SerializeField]
    private SeleccionaNivel seleccionaNivel;

    private string juegoSeleccionado;

    public void JuegoSeleccionado() {
        juegoSeleccionado = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        administradorMemorama.AsignaMemoramaSeleccionado(juegoSeleccionado);

        seleccionaNivel.AsignarMemoramaSeleccionado(juegoSeleccionado);
        //Debug.Log("Objeto Selecionado : " + juegoSeleccionado);
        StartCoroutine(MuestraMenuNivel());
    }
   
    IEnumerator MuestraMenuNivel() { // para las COURUTINAS, ES DECIR, DE FORMA INDIRECTA, SE USA EL IENumerator, OJO, arriba el método de JuegoSeleccionado es el que manda a ejecutar este método. tambien en la clase de Configuracion para cerrar Menu, fue igual.
        menuSeleccionNivel.SetActive(true);
        menuSeleccionJuegoAnim.Play("MenuSalida"); // saca mi menu princ.
        menuSeleccionNivelAnim.Play("NivelesEntrada"); // ingresa menu de niveles.
        yield return new WaitForSeconds(1.0f);
        menuSeleccionJuego.SetActive(false);
    }

}
