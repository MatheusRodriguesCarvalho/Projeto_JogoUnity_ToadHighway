using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerController : MonoBehaviour
{
    public Text hungerUI;
    public float hungerValue = 10;

    public Frog player;

    void Start()
    {
        player = GetComponent<Frog>();
        hungerUI.text = "Fome: " + hungerValue;

    }
    void Update()
    {
        HungerCountdown();
        if (hungerValue < 0)
        {
            player.kill();
        }
    }

    void HungerCountdown()
    {
        hungerUI.text = "Fome: " + hungerValue;
        hungerValue -= 1 * Time.deltaTime;
    }

}
