using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<MiningQuest> _miningQuests = new List<MiningQuest>();

    [SerializeField] private List<MineralPlanet> _distressedPlanets = new List<MineralPlanet>();

    public List<MiningQuest> MiningQuests { get => _miningQuests; }
    public List<MineralPlanet> DistressedPlanets { get => _distressedPlanets; }

}
