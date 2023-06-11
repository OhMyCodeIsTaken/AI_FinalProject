using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float _movementMod;
    [SerializeField] private Planet _occupyingPlanet;
    [SerializeField] private Planet _targetPlanet;

    public float MovementMod { get => _movementMod; set => _movementMod = value; }
    public Planet OccupyingPlanet { get => _occupyingPlanet; protected set => _occupyingPlanet = value; }
    public Planet TargetPlanet { get => _targetPlanet; set => _targetPlanet = value; }
}
