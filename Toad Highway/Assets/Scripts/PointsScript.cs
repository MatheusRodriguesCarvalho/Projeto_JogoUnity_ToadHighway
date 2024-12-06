using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    public Text pointsUI;
    public Text recordUI;

    public int points;
    void Update()
    {
        PlayerPrefs.SetInt("Record", 0);
        if(points > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", points);
        }

        pointsUI.text = "Pontuacao: " + points;
        recordUI.text = "Recorde: " + PlayerPrefs.GetInt("Record");

    }
}
