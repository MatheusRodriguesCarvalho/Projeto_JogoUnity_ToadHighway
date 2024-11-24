using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Frog : MonoBehaviour
{
    public Rigidbody2D body;
    public int points;
    private bool isdead = false;
    private float moveSapce = 1;
    private Vector3 target;

    private PointsScript ptScript;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ptScript = GameObject.Find("Pontuation").GetComponent<PointsScript>();
        target = new Vector3(0f, -4f, 0f);
    }

    void Update()
    {
        if (!isdead)
        {
            MoveHorizontal();
            MoveVertical();
            MovementInbounds();
            transform.position = new Vector3(target.x, target.y, 0f);
        }
    }

    public void MovementInbounds()
    {
        if (target.x > 6)
        {
            target.x -= moveSapce;
        }
        else if (target.x < -6)
        {
            target.x += moveSapce;
        }
        else if (target.y > 4)
        {
            target.y -= moveSapce;
        }
        else if (target.y < -4)
        {
            target.y += moveSapce;
        }
    }

    public void MoveHorizontal()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            target.x -= moveSapce;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            target.x += moveSapce;
        }
    }

    public void MoveVertical()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            target.y += moveSapce;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            target.y -= moveSapce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vehicles"))
        {
            Vehicles vehicles = collision.GetComponent<Vehicles>();
            if (vehicles != null)
            {
                Debug.Log("Touched");
                Debug.Log("Collision with: " + collision.gameObject.name);
                Destroy(gameObject);
                vehicles.StopMovement();
                isdead = true;
            }
        }
        else if (collision.gameObject.CompareTag("Fly"))
        {
            Fly fly = collision.GetComponent<Fly>();
            if (fly != null)
            {
                fly.Place();
                ptScript.points++;
            }
        }
        else if (collision.gameObject.CompareTag("Bettle"))
        {
            Bettle bettle = collision.GetComponent<Bettle>();
            if (bettle != null)
            {
                bettle.Hit();
                ptScript.points += 3;
            }
        }
        else if (collision.gameObject.CompareTag("Maggot"))
        {
            Maggot maggot = collision.GetComponent<Maggot>();
            if (maggot != null)
            {
                maggot.Catch();
                ptScript.points += 5;
            }
        }
    }
}
