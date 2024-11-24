using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maggot : MonoBehaviour
{
    public int x = 6;
    public int y = 4;
    public float spawnTime = 6;
    public Rigidbody2D body;

    public void Start()
    {
        Destroy(gameObject, 3f);
        body = GetComponent<Rigidbody2D>();
    }
    public void Catch()
    {
        Destroy(gameObject);
    }
}
