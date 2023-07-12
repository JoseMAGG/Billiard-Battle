using System;
using UnityEngine;

public class Bola : MonoBehaviour
{   protected static float fuerzaMin = 3000;
    protected static float fuerzaMax = 20000;
    
    protected Rigidbody rb;
    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        BolasList.GetInstance().RemoveBola(this);
        if(other.CompareTag("Hole"))
            Destroy(gameObject, 1);
    }
}