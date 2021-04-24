using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrdenarCartas : MonoBehaviour
{
    

    [SerializeField]
    private SetupMemorama setupMemorama;

    [SerializeField]
    private Transform memorama0, memorama1, memorama2, memorama3, memorama4; // contenedores por nivel. PARA IR ORDENANDO CARTAS POR CONTE. DEPEND EL NIVEL

    public List<Button> cartasNivel0, cartasNivel1, cartasNivel2, cartasNivel3, cartasNivel4;  // INDICA BOTONES A CARGAR Y SUS ANIMAC. ABAJO.

    public List<Animator> AnimNivel0, AnimNivel1, AnimNivel2, AnimNivel3, AnimNivel4; 

    [SerializeField]
    private Sprite[] imagenesTraseras; // cargar sprites en cada una de las cartas. SPRITE QUE SERÁ CARGADO DEPENDIENTE DEL JUEGO A JUGAR.

    private int nivelMemorama;
    private string memoramaSeleccionado;

    public void OrdenarCartasJuego(int nivel, string memorama) { // DISTINGUIR ENTRE NIVEL Y MEMORAMA. 
        this.nivelMemorama = nivel;
        this.memoramaSeleccionado = memorama;
        setupMemorama.AsignaNivelyMemorama(nivelMemorama, memoramaSeleccionado);
        Memorama();
    }

    //para cargar el memorama como tal:
    void Memorama() { // COMO ORDENAR TODOS LOS BOTONES POR NIVEL , ASIGNANDO A LOS CONTENEDORES.
        switch(nivelMemorama) {
            case 0:
                foreach (Button btn in cartasNivel0) { // para pasar cartas al contenedor correspondiente. 
                   if(!btn.gameObject.activeInHierarchy){ // preguntar si dentro del contenedor ya esta colocada nuestra carta o no,.
                        btn.gameObject.SetActive(true);
                        btn.gameObject.transform.SetParent(memorama0, false); // se asgina al panel correspoindiente. false para que se hagan con respecto a la camara y no respecto al papa, si no gira raro.
                        DibujaImagenesTraseras(btn);    //dibujar las imagenes de la parte de atras de las cartas.
                        setupMemorama.AsignaBotonesyAnimaciones(cartasNivel0, AnimNivel0);
                   } 
                } 

                
                break;
            case 1:
                foreach (Button btn in cartasNivel1) { // para pasar cartas al contenedor correspondiente. 
                   if(!btn.gameObject.activeInHierarchy){ // preguntar si dentro del contenedor ya esta colocada nuestra carta o no,.
                        btn.gameObject.SetActive(true);
                        btn.gameObject.transform.SetParent(memorama1, false); // se asgina al panel correspoindiente. false para que se hagan con respecto a la camara y no respecto al papa, si no gira raro.
                        DibujaImagenesTraseras(btn);    //dibujar las imagenes de la parte de atras de las cartas.
                        setupMemorama.AsignaBotonesyAnimaciones(cartasNivel1, AnimNivel1); // para saber cartas y animac correspondi, para poder dibujar sobre los clones del prefab
                   } 
                } 
                break;
            case 2:
                foreach (Button btn in cartasNivel2) { // para pasar cartas al contenedor correspondiente. 
                   if(!btn.gameObject.activeInHierarchy){ // preguntar si dentro del contenedor ya esta colocada nuestra carta o no,.
                        btn.gameObject.SetActive(true);
                        btn.gameObject.transform.SetParent(memorama2, false); // se asgina al panel correspoindiente. false para que se hagan con respecto a la camara y no respecto al papa, si no gira raro.
                        DibujaImagenesTraseras(btn);    //dibujar las imagenes de la parte de atras de las cartas.
                        setupMemorama.AsignaBotonesyAnimaciones(cartasNivel2, AnimNivel2);
                   } 
                } 
                break;
            case 3:
                foreach (Button btn in cartasNivel3) { // para pasar cartas al contenedor correspondiente. 
                   if(!btn.gameObject.activeInHierarchy){ // preguntar si dentro del contenedor ya esta colocada nuestra carta o no,.
                        btn.gameObject.SetActive(true);
                        btn.gameObject.transform.SetParent(memorama3, false); // se asgina al panel correspoindiente. false para que se hagan con respecto a la camara y no respecto al papa, si no gira raro.
                        DibujaImagenesTraseras(btn);    //dibujar las imagenes de la parte de atras de las cartas.
                        setupMemorama.AsignaBotonesyAnimaciones(cartasNivel3, AnimNivel3);
                   } 
                } 
                break;
            case 4:
                foreach (Button btn in cartasNivel4) { // para pasar cartas al contenedor correspondiente. 
                   if(!btn.gameObject.activeInHierarchy){ // preguntar si dentro del contenedor ya esta colocada nuestra carta o no,.
                        btn.gameObject.SetActive(true);
                        btn.gameObject.transform.SetParent(memorama4, false); // se asgina al panel correspoindiente. false para que se hagan con respecto a la camara y no respecto al papa, si no gira raro.
                        DibujaImagenesTraseras(btn);    //dibujar las imagenes de la parte de atras de las cartas.
                        setupMemorama.AsignaBotonesyAnimaciones(cartasNivel4, AnimNivel4);
                   } 
                } 
                break;
        }
    }

    void DibujaImagenesTraseras(Button btn) { // PERMITE CARGAR IMAGEN DEPENDIENDO EL BOTON QUE SEA SELECCIONADO. 
        if(memoramaSeleccionado == "btnAnimales"){ // para saber que voy a dibujar.
            btn.image.sprite = imagenesTraseras[0]; // estas imagenes se asignaran a manita desde Unity.
        } else if(memoramaSeleccionado == "btnMonstruos"){ // para saber que voy a dibujar.
            btn.image.sprite = imagenesTraseras[1]; // estas imagenes se asignaran a manita desde Unity.
        } else if(memoramaSeleccionado == "btnRobots"){ // para saber que voy a dibujar.
            btn.image.sprite = imagenesTraseras[2]; // estas imagenes se asignaran a manita desde Unity.
        }
    }

}
