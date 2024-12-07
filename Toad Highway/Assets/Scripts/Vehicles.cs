using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;

    void Start()
    {
        setVelocity();
    }

    public void setVelocity()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector3(speed, 0f, 0f);
    }

    public void StopMovement()
    {
        speed = 0;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bettle"))
        {
            Bettle bettle = collision.GetComponent<Bettle>();
            if (bettle != null)
            {
                bettle.Hit();
            }
        }
    }
}
