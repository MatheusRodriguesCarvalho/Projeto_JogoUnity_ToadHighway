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
    private int flyStreak = 0;
    private float moveSpace = 1;
    private float timer = 0;
    private Vector3 target;

    public Rigidbody2D body;
    public Sprite[] deadSprite;
    public Animator playerAnimator;

    [SerializeField] private AudioSource AudioPlayer;
    [SerializeField] private AudioClip[] sounds;
    private SpriteRenderer playerSprite;
    private PointsScript ptScript;
    private HungerController hgrControl;

    void Start()
    {
        GettingThings(); // it gets things
        target = new Vector3(0f, -4f, 0f);
    }

    void Update()
    {
        if (!isdead) // the froggy is very living :)
        {
            MoveHorizontal();
            MoveVertical();
            MovementInbounds();
            transform.position = new Vector3(target.x, target.y, 0f);
        }
        else // the froggy is no living :(
        {
            playerAnimator.SetFloat("xinput", 0f);
            playerAnimator.SetFloat("yinput", 0f);
            LoadCredits();
        }
    }

    //it gets things
    void GettingThings()
    {
        body = GetComponent<Rigidbody2D>();
        hgrControl = GetComponent<HungerController>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        ptScript = GameObject.Find("Pontuation").GetComponent<PointsScript>();
    }

    //Assegura que o Player ficara confinado dentro do mapa
    public void MovementInbounds()
    {
        target.x = Mathf.Clamp(target.x, -6f, 6f);
        target.y = Mathf.Clamp(target.y, -4f, 4f);
    }

    //Realiza a movimentacao vertical e horizontal
    public void MoveHorizontal()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            target.x -= moveSpace;
            playerAnimator.SetFloat("xinput", -1f);
            playerAnimator.SetFloat("yinput", 0f);
            AudioPlayer.PlayOneShot(sounds[1]);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            target.x += moveSpace;
            playerAnimator.SetFloat("xinput", 1f);
            playerAnimator.SetFloat("yinput", 0f);
            AudioPlayer.PlayOneShot(sounds[1]);
        }
    }
    public void MoveVertical()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            target.y += moveSpace;
            playerAnimator.SetFloat("xinput", 0f);
            playerAnimator.SetFloat("yinput", 1f);
            AudioPlayer.PlayOneShot(sounds[1]);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            target.y -= moveSpace;
            playerAnimator.SetFloat("xinput", 0f);
            playerAnimator.SetFloat("yinput", -1f);
            AudioPlayer.PlayOneShot(sounds[1]);
        }
    }

    //O Player morreu atropelado
    public void kill()
    {
        isdead = true;
        playerAnimator.SetBool("hit", true);
        //AudioPlayer.PlayOneShot(sounds[2]);
    }

    //O Player morreu de fome
    public void die()
    {
        isdead = true;
        playerAnimator.SetBool("starve", true);
        AudioPlayer.PlayOneShot(sounds[2]);
    }

    //Valida e verifica se o Player colidiu com algum Objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vehicles"))
        {
            Vehicles vehicles = collision.GetComponent<Vehicles>();
            if (vehicles != null)
            {
                kill();
                hgrControl.hunger = 0.1f; // hunger = hunger - maxHunger;
            }
        }
        else if (collision.gameObject.CompareTag("Fly"))
        {
            Fly fly = collision.GetComponent<Fly>();
            if (fly != null)
            {
                AudioPlayer.PlayOneShot(sounds[0]);
                fly.Replace();
                flyStreak += 1;
                ptScript.points += 1 * flyStreak;
                hgrControl.hunger += 1;
            }
        }
        else if (collision.gameObject.CompareTag("Bettle"))
        {
            Bettle bettle = collision.GetComponent<Bettle>();
            if (bettle != null)
            {
                AudioPlayer.PlayOneShot(sounds[0]);
                bettle.Hit();
                ptScript.points += 10;
                hgrControl.hunger += 5;
                hgrControl.maxHunger += 1;
                flyStreak = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Maggot"))
        {
            Maggot maggot = collision.GetComponent<Maggot>();
            if (maggot != null)
            {
                AudioPlayer.PlayOneShot(sounds[0]);
                maggot.Catch();
                ptScript.points += 4;
                hgrControl.hunger *= 1.4f;
                flyStreak = 0;
            }
        }
    }

    //Carrega a tela de Creditos dentro de alguns segundos
    void LoadCredits()
    {
        timer += 1f * Time.deltaTime;

        if (timer > 3f)
        {
            SceneManager.LoadScene("Credits");
        }
    }



}
