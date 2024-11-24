using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bettle : MonoBehaviour
{
    public int x = 6;
    public int y = 1;
    public float spawnTime = 3;
    public Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

}
