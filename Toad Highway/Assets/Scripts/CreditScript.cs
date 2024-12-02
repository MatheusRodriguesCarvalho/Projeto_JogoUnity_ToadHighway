using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    void Start()
    {
        Invoke("WaitToEnd", 9f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    public void WaitToEnd()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

}
