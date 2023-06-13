using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Mineral
{
    public MineralType MineralType;
    public int Amount;

    public Mineral(MineralType givenMineralType)
    {
        MineralType = givenMineralType;
        Amount = 0;
    }
}
