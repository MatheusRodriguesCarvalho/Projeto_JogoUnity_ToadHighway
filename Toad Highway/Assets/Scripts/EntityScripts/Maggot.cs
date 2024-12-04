using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Maggot : MonoBehaviour
{
    public int x = 6;
    public int y = 4;
    public float spawnTime = 6;
    public Rigidbody2D body;
    //private AudioSource som; pode ser que seja possivel adicionar diferenfes sons para diferentes objetos

    public void Start()
    {
        Destroy(gameObject, 3f);
        body = GetComponent<Rigidbody2D>();
        //som = GetComponent<AudioSource>();
    }
    public void Catch()
    {
        //som.Play();
        Destroy(gameObject, 0.35f);
    }
}
