using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteEscena : MonoBehaviour
{
    public static int siguienteEscena = 0;

    // Esta función calcula que escena es la que sigue.
    public void GoToNextScene(){
        siguienteEscena += 1;
        if(siguienteEscena == SceneManager.sceneCountInBuildSettings)
            siguienteEscena = 0;
        print("Escena siguiente:"+siguienteEscena);
        print("Escenas:"+SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene(siguienteEscena);
    }

}
