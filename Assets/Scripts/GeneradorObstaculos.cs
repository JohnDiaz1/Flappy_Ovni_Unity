using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObstaculos : MonoBehaviour
{
    public float tiempoMax = 1;
    private float tiempoIni = 0;
    public GameObject tubos;
    public float altura;

    // Start is called before the first frame update
    void Start()
    {
        GameObject nuevoTubo = Instantiate(tubos);
        nuevoTubo.transform.position = transform.position + new Vector3(0, 0, 0);
        Destroy(gameObject, 25);
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoIni > tiempoMax)
        {
            GameObject nuevoTubo = Instantiate(tubos);
            nuevoTubo.transform.position = transform.position + new Vector3(0, Random.Range(-altura, altura), 0);
            Destroy(gameObject, 25);
            tiempoIni = 0;
        }
        else
        {
            tiempoIni += Time.deltaTime; 
        }
    }
}
