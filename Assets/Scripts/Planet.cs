using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private MineralInventory _mineralInventory;

    private float _miningElapsedTime;
    private float _miningCooldown;

    private BaseMineral _primaryMinedMineral;
    private BaseMineral _secondaryMinedMineral;

    [SerializeField] private MineralMine _primaryMine;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MineMineral());
    }

    private IEnumerator MineMineral()
    {
        while(true)
        {
            if(_miningElapsedTime >= _miningCooldown)
            {
                _mineralInventory.AddMineralToInventory(_primaryMinedMineral);
                _mineralInventory.AddMineralToInventory(_secondaryMinedMineral);
            }

            return null;
        }
        
    }
}
