using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerCameraPractica3 : MonoBehaviour
{

    private enum CameraState
    {
        Cilinder,
        Sphere,
        Skybox
    }

    private CameraState currentState;

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }
 
    // Start is called before the first frame update
    void Start()
    {
        currentState = CameraState.Cilinder;
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            Touch activeTouch = Touch.activeTouches[0];
            switch (currentState)
            {
                case CameraState.Cilinder:
                    Cilinder(activeTouch);
                    break;
                case CameraState.Sphere:
                    Sphere(activeTouch);
                    break;
                case CameraState.Skybox:
                    Skybox(activeTouch);
                    break;
            }
        }
        
    }

    void Cilinder(Touch activeTouch){
        transform.position = new Vector3(0.0f,0.0f,0.0f);
        if(activeTouch.phase == UnityEngine.InputSystem.TouchPhase.Began){
            currentState = CameraState.Sphere;
        }
    }

    void Sphere(Touch activeTouch){
        transform.position = new Vector3(0.0f,5.0f,0.0f);
        if(activeTouch.phase == UnityEngine.InputSystem.TouchPhase.Began){
            currentState = CameraState.Skybox;
        }
    }

    void Skybox(Touch activeTouch){
        transform.position = new Vector3(0.0f,0.0f,2000.0f);
        if(activeTouch.phase == UnityEngine.InputSystem.TouchPhase.Began){
            currentState = CameraState.Cilinder;
        }
    }

}
