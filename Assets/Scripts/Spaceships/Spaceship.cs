using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] private Damagable _damagable;
    [SerializeField] private float _movementMod;
    [SerializeField] private Planet _occupyingPlanet;
    [SerializeField] private Planet _targetPlanet;
    [SerializeField] protected SpaceshipType _spaceshipType;

    [SerializeField] private Quest _currentQuest;

    [SerializeField] private FloatingHealthbar _healthbar;

    public bool IsQuestOngoing = false;

    public Quest CurrentQuest { get => _currentQuest; set => _currentQuest = value; }
    public float MovementMod { get => _movementMod; set => _movementMod = value; }
    public Planet OccupyingPlanet { get => _occupyingPlanet; set => _occupyingPlanet = value; }
    public Planet TargetPlanet { get => _targetPlanet; set => _targetPlanet = value; }
    public SpaceshipType SpaceshipType { get => _spaceshipType; }
    public Damagable Damagable { get => _damagable; }

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

    private void Awake()
    {
        InitSpaceship();
    }

    private void Start()
    {
        _damagable.TakeDamage(0);   // for testing and refreshing healthbar
    }

    protected virtual void InitSpaceship()
    {
        SubscribeEvents();
    }

    protected virtual void SubscribeEvents()
    {
        _damagable.OnTakeDamage += _healthbar.UpdateHealthbar;
        _damagable.OnHeal += _healthbar.UpdateHealthbar;
    }
}
