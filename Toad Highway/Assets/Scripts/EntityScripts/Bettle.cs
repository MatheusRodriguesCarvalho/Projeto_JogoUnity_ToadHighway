using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bettle : MonoBehaviour
{
    public int x = 6;
    public int y = 1;
    public float spawnTime = 1.5f;
    public Rigidbody2D body;
    //private AudioSource som; pode ser que seja possivel adicionar diferenfes sons para diferentes objetos

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //som = GetComponent<AudioSource>();
    }

    public void Hit()
    {
        //som.Play();
        Destroy(gameObject);
    }

}
