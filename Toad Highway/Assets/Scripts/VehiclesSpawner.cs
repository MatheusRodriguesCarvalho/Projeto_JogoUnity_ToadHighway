using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class VehiclesSpawner : MonoBehaviour
{
    public Vehicles vehicle;

    public float SpawnTime;
    public int orientacao;
    public int maxSpeed = 11;

    void Start()
    {
        GetOrientation();
        SetVehicleOrientation();
        GetTimeSpawn();
        InvokeRepeating("CreateVehicle", SpawnTime, SpawnTime);
    }

    void GetOrientation()
    {
        float temp = transform.position.x / Mathf.Abs(transform.position.x) * -1;
        orientacao = Mathf.RoundToInt(temp);
    }

    void SetVehicleOrientation()
    {
        vehicle.speed = Random.Range(3, maxSpeed);
        vehicle.speed = Mathf.Abs(vehicle.speed) * orientacao;
    }

    void GetTimeSpawn()
    {
        float x = Mathf.Abs(vehicle.speed) / 2f;
        if( x > 2)
        {
            SpawnTime = Random.Range(2, x + 1);
            //SpawnTime *= 0.95f;
        }
        else
        {
            SpawnTime = 2f;
        }
    }

    void CreateVehicle()
    {
        var SpawnPoint = new Vector2(transform.position.x, transform.position.y);
        var Rotation = Quaternion.identity;
        
        if (orientacao > 0)
        {
            Rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        Instantiate(vehicle, SpawnPoint, Rotation);

        IncreaseDificulty();
    }

    void IncreaseDificulty()
    {
        vehicle.speed *= 1.005f;
        //SpawnTime *= 0.90f;
    }

}
