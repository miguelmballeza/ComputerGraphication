using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoTerminado : MonoBehaviour
{
    [SerializeField]
    private GameObject panelJuegoTerminado;

    [SerializeField]
    private Animator panelJuegoTerminadoAnim, estrella1Anim, estrella2Anim, estrella3Anim, txtJuegoTerminadoAnim;
    // Start is called before the first frame update
    void Start() {
        panelJuegoTerminado.SetActive(false);
    }

    public void MuestraPanelJuegoTerminado(int estrellas) {
        StartCoroutine(MuestraPanel(estrellas));
    }

    public void OcultaPanelJuegoTerminado(){
        if(panelJuegoTerminado.activeInHierarchy){ // si se encuentra activo el panel de juego terminado, lo desactivamos.
            StartCoroutine(OcultaPanel());
        }
    }

    IEnumerator MuestraPanel(int estrellas) {
        panelJuegoTerminado.SetActive(true);
        panelJuegoTerminadoAnim.Play("panelJuegoTerminadoEntrada"); // cuidar aqui esto, checar video para corregir.
        yield return new WaitForSeconds(1.7f);

        switch(estrellas){
            case 1:
                estrella1Anim.Play("estrellaEntrada");
                yield return new WaitForSeconds(0.2f);
                txtJuegoTerminadoAnim.Play("textoEntrada");
                break;
            case 2:
                estrella1Anim.Play("estrellaEntrada");
                yield return new WaitForSeconds(0.25f);
                estrella2Anim.Play("estrellaEntrada");
                yield return new WaitForSeconds(0.1f);
                txtJuegoTerminadoAnim.Play("textoEntrada");
                break;
            case 3:
                estrella1Anim.Play("estrellaEntrada");
                yield return new WaitForSeconds(0.25f);
                estrella2Anim.Play("estrellaEntrada");
                yield return new WaitForSeconds(0.25f);
                estrella3Anim.Play("estrellaEntrada");
                yield return new WaitForSeconds(0.1f);
                txtJuegoTerminadoAnim.Play("textoEntrada");
                break;
        }

    }

    IEnumerator OcultaPanel(){
        panelJuegoTerminadoAnim.Play("panelJuegoTerminadoSalida");
        estrella1Anim.Play("estrellaSalida");
        estrella2Anim.Play("estrellaSalida");
        estrella3Anim.Play("estrellaSalida");
        txtJuegoTerminadoAnim.Play("textoSalida");
        yield return new WaitForSeconds(1.5f);
        panelJuegoTerminado.SetActive(false);
    }

}