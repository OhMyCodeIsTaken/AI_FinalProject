using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlanet : Planet
{
    [SerializeField] private List<MineralPlanet> _mineralPlanets = new List<MineralPlanet>();

    public List<MineralPlanet> MineralPlanets { get => _mineralPlanets; }

    public QuestManager QuestManager;
}
