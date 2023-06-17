using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private MineralInventory mineralInventory;

    Vector3 planetRotation = Vector3.up;

    [SerializeField] private int rotationSpeed;

    [SerializeField] private List<Spaceship> _visitingSpaceships = new List<Spaceship>();

    public MineralInventory MineralInventory { get => mineralInventory; set => mineralInventory = value; }
    public List<Spaceship> VisitingSpaceships { get => _visitingSpaceships; }

    protected void RotatePlanet()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void Update()
    {
        RotatePlanet();
    }
}
