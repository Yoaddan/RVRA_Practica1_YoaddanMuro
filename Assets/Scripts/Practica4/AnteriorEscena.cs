using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnteriorEscena : MonoBehaviour
{

    // Esta función calcula que escena es la que sigue.
    public void GoToPreviousScene(){
        SiguienteEscena.siguienteEscena -= 1;
        if(SiguienteEscena.siguienteEscena < 0)
            SiguienteEscena.siguienteEscena = SceneManager.sceneCountInBuildSettings-1;
        print("Escena siguiente:"+SiguienteEscena.siguienteEscena);
        print("Escenas:"+SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene(SiguienteEscena.siguienteEscena);
    }

}
