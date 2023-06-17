using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private HomePlanet _homePlanet;

    public HomePlanet HomePlanet { get => _homePlanet;}

    [SerializeField] private List<MineralPlanet> _mineralPlanets = new List<MineralPlanet>();

    public List<MineralPlanet> MineralPlanets { get => _mineralPlanets; }
}
