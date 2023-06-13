using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseMineral
{
    public MineralType MineralType;
    public int Amount;

    public BaseMineral(MineralType givenMineralType)
    {
        MineralType = givenMineralType;
        Amount = 0;
    }
}
