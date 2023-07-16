using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Action<Spaceship> OnEnteringPlanet;
    private Vector3 _planetRotation = Vector3.up;

    [SerializeField] private MineralInventory _mineralInventory;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private List<Spaceship> _visitingSpaceships = new List<Spaceship>();

    public MineralInventory MineralInventory { get => _mineralInventory; set => _mineralInventory = value; }
    public List<Spaceship> VisitingSpaceships { get => _visitingSpaceships; }

    protected void RotatePlanet()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void Update()
    {
        RotatePlanet();
    }

    public bool AreThereSpecificVisitingShips(SpaceshipType[] typesToCheck)
    {
        foreach (Spaceship spaceship in VisitingSpaceships)
        {
            foreach (SpaceshipType type in typesToCheck)
            {
                if (spaceship.SpaceshipType == type)
                {
                    return true;
                }
            }

            
        }

        return false;
    }

    public void EnterPlanet(Spaceship spaceship)
    {
        _visitingSpaceships.Add(spaceship);
        OnEnteringPlanet?.Invoke(spaceship);
        ChangeVisitingSpaceshipsOrbit();

    }

    public void LeavePlanet(Spaceship spaceship)
    {
        _visitingSpaceships.Remove(spaceship);

        ChangeVisitingSpaceshipsOrbit();
    }

    private void ChangeVisitingSpaceshipsOrbit()
    {
        if(_visitingSpaceships.Count < 1)
        {
            // in case the last ship left the planet
            return;
        }

        float anglePerShip = 360 / _visitingSpaceships.Count;

        for (int i = 0; i < _visitingSpaceships.Count; i++)
        {
            _visitingSpaceships[i].CapsulePivot.transform.eulerAngles = new Vector3(anglePerShip * i, 0, 0);
        }
    }
}
