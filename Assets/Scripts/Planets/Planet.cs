using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private MineralInventory mineralInventory;

    Vector3 planetRotation = Vector3.up;

    [SerializeField] private int rotationSpeed;

    public MineralInventory MineralInventory { get => mineralInventory; set => mineralInventory = value; }

    protected void RotatePlanet()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void Update()
    {
        RotatePlanet();
    }
}
