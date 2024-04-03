using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemigoScript : MonoBehaviour
{
//
    public Transform user;
    private NavMeshAgent enemyAgent;
    public bool userDetect;
    public float delay; //Segundos a esperar para destruir tras animación de muerte.
    public float stoppingDistance = 1.5f; // Distancia de tolerancia para detenerse frente al jugador.
    public float detectionRadius = 10f; // Radio de detección
    private Animator enemyAnimator;
    private bool disparado = false;
    private Vector3 originalPosition; // Posición original del enemigo

    public void OnTriggerEnter(Collider other)
    {
        userDetect = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();  
        originalPosition = transform.position; // Almacena la posición original al inicio
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colision");
        if(other.transform.tag == "BalaP5" && !disparado)
        {
            Debug.Log("Bala");
            enemyAnimator.SetInteger("action",3);
            float animTime = enemyAnimator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(this.gameObject, animTime + delay);
            disparado = true;
        }
    }

    void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanceToUser = Vector3.Distance(transform.position, user.position);
        // Calcula la distancia entre la posición actual y la posición original
        float distanceToOriginal = Vector3.Distance(transform.position, originalPosition);

        if(disparado)
        {
            enemyAnimator.SetInteger("action",3);
            return;
        }

        // Verifica si el jugador está dentro del radio de detección
        if(distanceToUser <= detectionRadius)
        {
            userDetect = true;
        }
        else
        {
            userDetect = false;
        }

        // Si el jugador ha sido detectado, persigue al jugador
        if(userDetect)
        {
            // Si el enemigo está lo suficientemente cerca del jugador, detenerse y reproducir la animación de ataque
            if(distanceToUser <= stoppingDistance)
            {
                enemyAnimator.SetInteger("action", 2);
            }
            else
            {
                enemyAnimator.SetInteger("action", 1);
                enemyAgent.destination = user.position;
            }  

        }
        else
        {
            // Si el jugador no ha sido detectado, regresa a su posición original
            if (distanceToOriginal <= 0.5f) // Ajusta la tolerancia según sea necesario
            {
                // Si el enemigo está en su posición original, cambia a la animación Idle
                enemyAnimator.SetInteger("action",0);
                //Debug.Log("Cambio a IDLE");
            }
            else
            {
                enemyAgent.destination = originalPosition;
            }
        }
    }

}
