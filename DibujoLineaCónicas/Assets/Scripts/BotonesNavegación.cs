﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesNavegación : MonoBehaviour
{
    public void EjecutaBtnInicioMain() {
        SceneManager.LoadScene("Main");
        // permite regresar o ir a la escena que este aquí entrecomillado.
    }

    public void EjecutaBtnRegresar(){
        SceneManager.LoadScene("Initial");
    }


    public void EjecutaBtnInfo(){
        SceneManager.LoadScene("Info");
    }

}
