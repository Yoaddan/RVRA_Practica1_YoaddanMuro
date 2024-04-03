using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * Time.fixedDeltaTime * 40000); 
    }

    public void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }

}
