using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rd;

    public GameManager gameManager;
    public AudioClip flap;
    private AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = flap;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rd.velocity = Vector2.up * velocity;
            AudioSource.Play();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.perdiste();
    }
}
