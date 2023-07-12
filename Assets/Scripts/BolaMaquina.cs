using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class BolaMaquina : Bola
{
    private bool _shooting;
    private bool _able;
    private void Update()
    {
        if (_able && rb.velocity.magnitude <= 5 && !_shooting)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _shooting = true;
        yield return new WaitForSeconds(Random.Range(0,5));
        if (rb.velocity.magnitude <= 5)
        {
            Transform transformOther = BolasList.GetInstance().GetBolaRandomTransform();
            int fuerza = (int) Random.Range(fuerzaMin, fuerzaMax);
            Vector3 dir = Vector3.Normalize(transformOther.position - transform.position);
            dir = Vector3.RotateTowards(dir,
                new Vector3(dir.x + Random.Range(-1, 1), dir.y, dir.z + Random.Range(-1, 1)),
                0.174533f, 0);
            rb.AddForce(dir * fuerza);
        }
        _shooting = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball")) _able = true;
    }
}