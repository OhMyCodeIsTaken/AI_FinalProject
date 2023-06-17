using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private HomePlanet _homePlanet;
    [SerializeField] private List<MineralPlanet> _mineralPlanets = new List<MineralPlanet>();
    [SerializeField] private List<PiratePlanet> _piratePlanets = new List<PiratePlanet>();
    private System.Random rand = new System.Random();
    private int randomIndex;

    public HomePlanet HomePlanet { get => _homePlanet;}


    public List<MineralPlanet> MineralPlanets { get => _mineralPlanets; }
    public List<PiratePlanet> PiratePlanets { get => _piratePlanets; set => _piratePlanets = value; }

    public PiratePlanet GetRandomPiratePlanet()
    {
        randomIndex = rand.Next(0, PiratePlanets.Count);
        return PiratePlanets[randomIndex];
    }

    private MineralPlanet GetRandomMineralPlanet()
    {
        randomIndex = rand.Next(0, MineralPlanets.Count);
        return MineralPlanets[randomIndex];
    }
}
