using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class VehiclesSpawner : MonoBehaviour
{
    public Vehicles vehicle;

    public float SpawnTime;
    public int orientacao = -1;

    void Start()
    {
        GetTimeSpawn();
        SetVehicleOrientation();
        InvokeRepeating("CreateVehicle", SpawnTime, SpawnTime);

    }

    void GetTimeSpawn()
    {
        SpawnTime = Mathf.Abs(vehicle.speed) / 2.5f;
    }

    void SetVehicleOrientation()
    {
        vehicle.speed = Mathf.Abs(vehicle.speed) * orientacao;
    }

    void CreateVehicle()
    {
        var SpawnPoint = new Vector2(transform.position.x, transform.position.y);
        var Rotation = Quaternion.identity;
        if (orientacao < 0)
        {
            Rotation = Quaternion.Euler(transform.position.x, transform.position.y * -1, transform.position.z);
        }

        Instantiate(vehicle, SpawnPoint, Rotation);
    }

}
