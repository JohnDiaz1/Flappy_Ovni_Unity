using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{
    public float velocidad;

    void Update()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}
