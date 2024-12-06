using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerController : MonoBehaviour
{
    public float hunger;
    public float maxHunger = 20f;

    public Image hungerBar;
    public Text hungerUI;
    public Frog player;

    void Start()
    {
        player = GetComponent<Frog>();
        hunger = maxHunger;
        hungerUI.text = "Fome: " + hunger;

    }
    void Update()
    {
        hunger = Mathf.Clamp(hunger, 0f, maxHunger + 1f);

        if (hunger > 0)
        {
            HungerCountdown();
            updateHungerUI();
        }
        else
        {
            player.die();
        }
    }

    void HungerCountdown()
    {
        hungerUI.text = "Fome: " + Mathf.Round(hunger);
        hunger -= 1 * Time.deltaTime;
    }

    void updateHungerUI()
    {
        hungerBar.fillAmount = hunger / maxHunger;
    }
}
