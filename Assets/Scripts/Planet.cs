using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private MineralInventory _mineralInventory;

    [SerializeField] private float _miningElapsedTime;
    [SerializeField] private float _miningCooldown;

    private BaseMineral _primaryMinedMineral;
    private BaseMineral _secondaryMinedMineral;


    [SerializeField] private MineralMine _primaryMine;
    [SerializeField] private MineralMine _secondaryMine;

    [SerializeField] private int _primaryMineralProduce;
    [SerializeField] private int _secondaryMineralProduce;
    // Start is called before the first frame update
    void Start()
    {
        _primaryMinedMineral = (BaseMineral)Activator.CreateInstance(_primaryMine.Mineral.GetType());
        _primaryMinedMineral.Amount = _primaryMineralProduce;

        _secondaryMinedMineral = (BaseMineral)Activator.CreateInstance(_secondaryMine.Mineral.GetType());
        _secondaryMinedMineral.Amount = _secondaryMineralProduce;

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

                // Reset 
                _miningElapsedTime = 0;
            }

            _miningElapsedTime += Time.deltaTime;
            yield return null;
        }
        
    }
}
