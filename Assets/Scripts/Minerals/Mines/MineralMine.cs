using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/MineralMine", order = 1)]
abstract public class MineralMine : ScriptableObject
{
    public BaseMineral Mineral;
}
