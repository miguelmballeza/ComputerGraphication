using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargaMemorama : MonoBehaviour
{
    [SerializeField]
    private AdministrarMemorama administrarMemorama;

    [SerializeField]
    private OrdenarCartas ordenaCartas;

    [SerializeField]
    private GameObject panelNivel; // para el panel dentro del Panel de MemoramaNivel0, en este caso tenemos a CartasNivel0, el panel dentro del panel.
     [SerializeField]
    private Animator panelNivelAnim; // para saber que nivel estoy seleccionando. 
    // Start is called before the first frame update
    [SerializeField]
    private GameObject memorama0, memorama1, memorama2, memorama3, memorama4; // para las cartas del memorama. me parece. 
    
    [SerializeField]
    private Animator memoramaAnim0, memoramaAnim1, memoramaAnim2, memoramaAnim3, memoramaAnim4;
    
    private int nivelMemorama;
    private string juegoSeleccionado;
    private List<Animator> animaciones;

    public void CargaJuego(int nivel, string memorama) { // parametros para saber si es animales, robots, etc y su correspondiente nivel. 
        this.nivelMemorama = nivel;
        this.juegoSeleccionado = memorama;

        ordenaCartas.OrdenarCartasJuego(nivel, memorama);
        //Carga el memorama.
        switch (nivelMemorama)
        {
            case 0:
                StartCoroutine(CargaPanelMemorama(memorama0,memoramaAnim0));
               break;
            case 1:
                StartCoroutine(CargaPanelMemorama(memorama1,memoramaAnim1));
                break;
            case 2:
                StartCoroutine(CargaPanelMemorama(memorama2,memoramaAnim2));
                break;
            case 3:
                StartCoroutine(CargaPanelMemorama(memorama3,memoramaAnim3));
                break;
            case 4:
                StartCoroutine(CargaPanelMemorama(memorama4,memoramaAnim4));
                break;
            
        }

    }

    public void RegresaMenuNiveles() {

        animaciones = administrarMemorama.ResetJuego(); // cada vez qye regresemos se resete el juego por completo. 

        switch (nivelMemorama)
        {
            case 0:
                StartCoroutine(CargaMenuNiveles(memorama0,memoramaAnim0));
               break;
            case 1:
                StartCoroutine(CargaMenuNiveles(memorama1,memoramaAnim1));
                break;
            case 2:
                StartCoroutine(CargaMenuNiveles(memorama2,memoramaAnim2));
                break;
            case 3:
                StartCoroutine(CargaMenuNiveles(memorama3,memoramaAnim3));
                break;
            case 4:
                StartCoroutine(CargaMenuNiveles(memorama4,memoramaAnim4));
                break;
            
        }
    }

    IEnumerator CargaMenuNiveles(GameObject panelMemorama, Animator animPanelMemorama) {
        panelNivel.SetActive(true);
        panelNivelAnim.Play("NivelesEntrada"); // entrando el panel "niveles".
        animPanelMemorama.Play("MemoramaSalida"); // sacar el memorama como tal. 
        yield return new WaitForSeconds(1.0f);

        foreach (Animator anim in animaciones) {
            anim.Play("cartaEstatica"); // volver a cargar las cartas para volver a jugar, para que aparezcan.
        }

        yield return new WaitForSeconds(0.5f);
        panelMemorama.SetActive(false);
    }

    IEnumerator CargaPanelMemorama(GameObject panelMemorama, Animator animPanelMemorama) {
        panelMemorama.SetActive(true);
        animPanelMemorama.Play("MemoramaEntrada");
        panelNivelAnim.Play("NivelesSalida");  // aqui le cambie. 
        yield return new WaitForSeconds(1.0f);
        panelNivel.SetActive(false); 
        }


}
