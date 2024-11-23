using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Vector3 pos;
    public int x = 5;
    public int y = 3;
    public Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Place()
    {
        int randomX = Random.Range(-6, 7);
        int randomY = Random.Range(-3, 0);
        transform.position = new Vector3(randomX, randomY, 0f);
    }

}