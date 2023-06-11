using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/BismorMine", order = 1)]
public class BismorMine : MineralMine
{
    [SerializeField] private Bismor _bismor;
}
