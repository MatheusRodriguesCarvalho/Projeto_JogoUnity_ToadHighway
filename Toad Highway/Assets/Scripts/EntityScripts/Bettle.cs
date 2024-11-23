using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bettle : MonoBehaviour
{
    public int x = 6;
    public int y = 1;

    public void Hit()
    {
        Destroy(gameObject);
    }
    public void Place()
    {
        int randomX = Random.Range(-x, x + 1);
        int randomY = Random.Range(+y, y + 2);
        transform.position = new Vector3(randomX, randomY, 0f);
    }

}
