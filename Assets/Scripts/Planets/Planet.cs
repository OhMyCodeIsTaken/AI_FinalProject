using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private MineralInventory mineralInventory;

    public MineralInventory MineralInventory { get => mineralInventory; set => mineralInventory = value; }
}
