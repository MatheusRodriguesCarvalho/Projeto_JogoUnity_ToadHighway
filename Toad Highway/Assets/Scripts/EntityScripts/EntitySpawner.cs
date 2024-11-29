using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    public Bettle bettle;
    public Maggot maggot;
    public Fly fly;

    public int SpawnTime;

    void Start()
    {
        SpawnFly();
        InvokeRepeating("SpawnBettle", 1f, bettle.spawnTime);
        InvokeRepeating("SpawnMaggot", 1f, maggot.spawnTime);
    }

    void SpawnBettle()
    {
        int randomX = Random.Range( -bettle.x, bettle.x + 1);
        int randomY = Random.Range( +bettle.y, bettle.y + 2);
        float randomRotation = Random.Range(0, 360);

        var SpawnPoint = new Vector2(randomX, randomY);
        var Rotation = Quaternion.Euler(0f, 0f, randomRotation);

        Instantiate(bettle, SpawnPoint, Rotation);
    }
    void SpawnMaggot()
    {
        int randomX = Random.Range(-maggot.x, maggot.x + 1);
        int randomY = GetRandomValue(-4);
        float randomRotation = Random.Range(0, 360);

        var SpawnPoint = new Vector2(randomX, randomY);
        var Rotation = Quaternion.Euler(0f, 0f, randomRotation);

        Instantiate(maggot, SpawnPoint, Rotation);
    }

    void SpawnFly()
    {
        //var SpawnPoint = new Vector2(fly.x, fly.y);
        float randomRotation = Random.Range(0, 360);

        var SpawnPoint = new Vector2(0, -3);
        var Rotation = Quaternion.Euler(0f, 0f, 0f);
        Instantiate(fly, SpawnPoint, Rotation);
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
