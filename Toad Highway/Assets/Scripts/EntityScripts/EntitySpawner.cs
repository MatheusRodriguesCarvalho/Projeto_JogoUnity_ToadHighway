using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public Bettle bettle;
    public Maggot maggot;

    public int SpawnTime;

    void Start()
    {

        InvokeRepeating("SpawnBettle", 1f, bettle.spawnTime);
        InvokeRepeating("SpawnMaggot", 1f, maggot.spawnTime);
    }

    void SpawnBettle()
    {
        int randomX = Random.Range( -bettle.x, bettle.x + 1);
        int randomY = Random.Range( +bettle.y, bettle.y + 2);

        var SpawnPoint = new Vector2(randomX, randomY);
        Instantiate(bettle, SpawnPoint, Quaternion.identity);
    }
    void SpawnMaggot()
    {
        int randomX = Random.Range(-maggot.x, maggot.x + 1);
        int randomY = GetRandomValue(-4);

        var SpawnPoint = new Vector2(randomX, randomY);
        Instantiate(maggot, SpawnPoint, Quaternion.identity);
    }

    int GetRandomValue(int value)
    {
        int num = Random.Range(0, 3);
        switch (num)
        {
            case 0: return 0;
            case 1: return value;
            case 2: return value * -1;
        }
        return 0;
    }

}
