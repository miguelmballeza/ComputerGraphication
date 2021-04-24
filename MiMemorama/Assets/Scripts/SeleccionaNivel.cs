using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionaNivel : MonoBehaviour
{

    [SerializeField]
    private AdministrarMemorama administradorMemorama;
    [SerializeField]
    private GameObject menuSeleccionJuego, menuSeleccionNivel; // aqui el objeto.
    [SerializeField]
    private Animator menuSeleccionJuegoAnim, menuSeleccionNivelAnim;
    private string memoramaSeleccionado;
    [SerializeField]
    private CargaMemorama cargaMemorama;

    public void RegresaMenuSeleccionJuego() {
        StartCoroutine(MuestraMenuSeleccionJuego());
    }

    IEnumerator MuestraMenuSeleccionJuego() {
        menuSeleccionJuego.SetActive(true);
        menuSeleccionJuegoAnim.Play("MenuEntrada");
        menuSeleccionNivelAnim.Play("NivelesSalida");
        yield return new WaitForSeconds(1.0f);
        menuSeleccionNivel.SetActive(false); 
        //cuando le demos click al tache de los niveles,  se activa menu y su animacion ...
    }

    public void SeleccionaNivelMemorama() {
        int nivel = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        administradorMemorama.AsignaNivel(nivel);
        cargaMemorama.CargaJuego(nivel, memoramaSeleccionado);
    }

    public void AsignarMemoramaSeleccionado(string memoSeleccionado) {
        memoramaSeleccionado = memoSeleccionado;
        Debug.Log("memorama seleccionado : " + memoSeleccionado);
    }


}
