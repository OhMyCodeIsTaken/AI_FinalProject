using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private float _movementMod;
    [SerializeField] private Planet _occupyingPlanet;
    [SerializeField] private Planet _targetPlanet;

    [SerializeField] private Quest _currentMiningQuest;

    public bool IsQuestOngoing = false;

    [SerializeField] private MineralInventory _mineralInventory;

    public Quest CurrentMiningQuest { get => _currentMiningQuest; set => _currentMiningQuest = value; }
    public float MovementMod { get => _movementMod; set => _movementMod = value; }
    public Planet OccupyingPlanet { get => _occupyingPlanet; set => _occupyingPlanet = value; }
    public Planet TargetPlanet { get => _targetPlanet; set => _targetPlanet = value; }
    public MineralInventory MineralInventory { get => _mineralInventory; }
}
