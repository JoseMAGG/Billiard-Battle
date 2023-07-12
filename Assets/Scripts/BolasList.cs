using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BolasList : MonoBehaviour
{
    public List<Bola> bolas;

    private static BolasList _instance;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(GetComponent<BolasList>());
    }
    
    public static BolasList GetInstance()
    {
        return _instance;
    }

    public Transform GetBolaRandomTransform()
    {
        int rnd = Random.Range(0, bolas.Count);
        return bolas[rnd].transform;
    }

    public void RemoveBola(Bola bola)
    {
        bolas.Remove(bola);
    }
}