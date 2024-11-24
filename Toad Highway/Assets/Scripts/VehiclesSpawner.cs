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

    void Start()
    {
        GetTimeSpawn();
        GetOrientation();
        SetVehicleOrientation();
        InvokeRepeating("CreateVehicle", SpawnTime, SpawnTime);
    }

    void GetTimeSpawn()
    {
        SpawnTime = Mathf.Abs(vehicle.speed) / 2f;
    }

    void GetOrientation()
    {
        float temp = transform.position.x / Mathf.Abs(transform.position.x) * -1;
        orientacao = Mathf.RoundToInt(temp);
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

        Instantiate(vehicle, SpawnPoint, Quaternion.identity);//TODO ser capaz de inverter o veiculo no eixo y
        IncreaseDificulty();
    }

    void IncreaseDificulty()
    {
        vehicle.speed *= 1.001f;
        SpawnTime *=  0.97f;
    }

}
