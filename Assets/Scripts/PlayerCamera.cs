using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private enum CameraState
    {
        Rotate,
        MoveUp,
        MoveDown,
        Idle
    }

    private CameraState currentState;
    private float currentHeight;
    private Quaternion targetRotation;
    private float rotationSpeed = 20.0f; // Velocidad de rotación en grados por segundo
    private float moveSpeed = 0.01f; // Velocidad de movimiento hacia arriba y hacia abajo
    private float maxHeight = 40.3f;
    private float minHeight = 0.0f;
    private float rotationCounter = 0f; // Contador de rotación
    private bool passedMaxHeight = false;
    private bool passedCentralHeight = false;


    void Start()
    {
        currentState = CameraState.Rotate;
    }

    void Update()
    {
        switch (currentState)
        {
            case CameraState.Rotate:
                Rotate();
                break;
            case CameraState.MoveUp:
                MoveUp();
                break;
            case CameraState.MoveDown:
                MoveDown();
                break;
        }
    }

    

    void Rotate()
    {
        // Incrementar el contador de rotación
        rotationCounter += rotationSpeed * Time.deltaTime;

        // Aplicar la rotación gradual
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Comprobar si se ha completado una vuelta completa (360 grados)
        if (rotationCounter >= 360f)
        {
            // Reiniciar el contador de rotación
            rotationCounter = 0f;
            if(passedMaxHeight)
                currentState = CameraState.MoveDown;
            else
                currentState = CameraState.MoveUp;
        }
    }



    void MoveUp()
    {
        // Mover la cámara hacia arriba
        transform.Translate(Vector3.up * moveSpeed);

        currentHeight = transform.position.y;

        if (currentHeight >= maxHeight)
        {
            passedMaxHeight = true;
            currentState = CameraState.Rotate;
        }
    }

    void MoveDown()
    {
        // Mover la cámara hacia abajo
        transform.Translate(Vector3.down * moveSpeed);

        currentHeight = transform.position.y;

        if(currentHeight <= 19.9f && passedMaxHeight && !passedCentralHeight)
        {
            passedCentralHeight = true;
            currentState = CameraState.Rotate;
        }

        if (currentHeight <= minHeight)
        {
            passedMaxHeight = false;
            passedCentralHeight = false;
            currentState = CameraState.Rotate;
        }
    }

}

