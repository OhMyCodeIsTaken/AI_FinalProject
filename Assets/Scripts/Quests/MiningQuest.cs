using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MiningQuest", order = 1)]
public class MiningQuest : Quest
{
    [SerializeField] private MineralType _mineralToMine;
    [SerializeField] int _amountToMine;

    public MineralType MineralToMine { get => _mineralToMine; }
    public int AmountToMine { get => _amountToMine; }
}