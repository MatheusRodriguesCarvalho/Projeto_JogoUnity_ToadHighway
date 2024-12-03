using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    public int points;
    public bool isdead = false;
    private float moveSapce = 1;
    private int flyStreak = 0;
    private Vector3 target;

    public Rigidbody2D body;
    public Sprite[] deadSprite;
    public Animator playerAnimator;

    private SpriteRenderer playerSprite;
    private PointsScript ptScript;
    private HungerController hgrControl;

    void Start()
    {
        GettingThings(); //it gets things
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
        else
        {
            playerAnimator.SetFloat("xinput", 0f);
            playerAnimator.SetFloat("yinput", 0f);
            LoadCredits();
        }
    }

    void GettingThings()
    {
        body = GetComponent<Rigidbody2D>();
        ptScript = GameObject.Find("Pontuation").GetComponent<PointsScript>();
        hgrControl = GetComponent<HungerController>();
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    public void MovementInbounds()
    {
        target.x = Mathf.Clamp(target.x, -6f, 6f);
        target.y = Mathf.Clamp(target.y, -4f, 4f);
    }

    public void MoveHorizontal()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            target.x -= moveSapce;
            playerAnimator.SetFloat("xinput", -1f);
            playerAnimator.SetFloat("yinput", 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            target.x += moveSapce;
            playerAnimator.SetFloat("xinput", 1f);
            playerAnimator.SetFloat("yinput", 0f);
        }
    }

    public void MoveVertical()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            target.y += moveSapce;
            playerAnimator.SetFloat("xinput", 0f);
            playerAnimator.SetFloat("yinput", 1f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            target.y -= moveSapce;
            playerAnimator.SetFloat("xinput", 0f);
            playerAnimator.SetFloat("yinput", -1f);
        }
    }

    public void kill()
    {
        //Destroy(gameObject);
        isdead = true;
        playerAnimator.SetBool("hit", true);
        //TODO CONGELAR A BARRA DE FOME
    }
    public void die()
    {
        //Destroy(gameObject);
        isdead = true;
        playerAnimator.SetBool("starve", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vehicles"))
        {
            Vehicles vehicles = collision.GetComponent<Vehicles>();
            if (vehicles != null)
            {
                //Debug.Log("Touched");
                //Debug.Log("Collision with: " + collision.gameObject.name);
                //vehicles.StopMovement();
                kill();
                //SceneManager.LoadScene("MenuPrincipal");
            }
        }
        else if (collision.gameObject.CompareTag("Fly"))
        {
            Fly fly = collision.GetComponent<Fly>();
            if (fly != null)
            {
                fly.Replace();
                flyStreak += 1;
                ptScript.points += 1 * flyStreak;
                hgrControl.hunger += 0;
            }
        }
        else if (collision.gameObject.CompareTag("Bettle"))
        {
            Bettle bettle = collision.GetComponent<Bettle>();
            if (bettle != null)
            {
                bettle.Hit();
                ptScript.points += 10;
                hgrControl.hunger += 5;
                flyStreak = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Maggot"))
        {
            Maggot maggot = collision.GetComponent<Maggot>();
            if (maggot != null)
            {
                maggot.Catch();
                ptScript.points += 4;
                hgrControl.hunger *= 1.75f;
                flyStreak = 0;
            }
        }
    }

    IEnumerator LoadCredits()
    {
        yield return new WaitForSeconds(1f); //TODO fazer esperar um tempo antes de chamar a cena de Credito

        SceneManager.LoadScene("Credits");
    }

}
