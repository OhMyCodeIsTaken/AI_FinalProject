using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MiningQuest", order = 1)]
public class MiningQuest : Quest
{
    [SerializeField] private MineralMine _mineralToMine;
    [SerializeField] int _amountToMine;
}