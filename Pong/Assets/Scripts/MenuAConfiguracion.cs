using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAConfiguracion : MonoBehaviour
{
    
    // Update is called once per frame
    void Update() {
        //puede ser anyKey.
        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene("Settings");
        }    
    }



}
