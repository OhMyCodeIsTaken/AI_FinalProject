using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float _movementMod;
    [SerializeField] private Planet _occupyingPlanet;
    [SerializeField] private Planet _targetPlanet;

    [SerializeField] private Quest _currentQuest;

    public bool IsQuestOngoing = false;

    public Quest CurrentQuest { get => _currentQuest; set => _currentQuest = value; }
    public float MovementMod { get => _movementMod; set => _movementMod = value; }
    public Planet OccupyingPlanet { get => _occupyingPlanet; set => _occupyingPlanet = value; }
    public Planet TargetPlanet { get => _targetPlanet; set => _targetPlanet = value; }

    public void LeaveOccupyingPlanet()
    {
        OccupyingPlanet.VisitingSpaceships.Remove(this);
        OccupyingPlanet = null;
    }

    public void OccupyPlanet(Planet planet)
    {
        planet.VisitingSpaceships.Add(this);
        OccupyingPlanet = planet;
        TargetPlanet = null;
    }
}
