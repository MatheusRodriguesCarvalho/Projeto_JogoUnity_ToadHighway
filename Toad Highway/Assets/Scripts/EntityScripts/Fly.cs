using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public int x = 0;
    public int y = -3;
    private Rigidbody2D body;
    //private AudioSource som; pode ser que seja possivel adicionar diferenfes sons para diferentes objetos

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //som = GetComponent<AudioSource>();
    }

    public void Replace()
    {
        //som.Play();
        int randomX = Random.Range(-6, 7);
        int randomY = Random.Range(-3, 0);
        int randomZ = Random.Range(0, 360);
        transform.position = new Vector3(randomX, randomY, randomZ);
        Debug.Log(randomZ);
    }

}
