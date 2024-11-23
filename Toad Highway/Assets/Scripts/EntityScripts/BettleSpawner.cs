using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BettleSpawner : MonoBehaviour
{
    public Bettle bettle;

    public int SpawnTime;

    void Start()
    {
        SpawnTime = 3;
        InvokeRepeating("PlacingBettle", 1f, SpawnTime);
    }

    void PlacingBettle()
    {
        int randomX = Random.Range( -bettle.x, bettle.x + 1);
        int randomY = Random.Range( +bettle.y, bettle.y + 2);

        var SpawnPoint = new Vector2(randomX, randomY);
        Instantiate(bettle, SpawnPoint, Quaternion.identity);
    }
}
