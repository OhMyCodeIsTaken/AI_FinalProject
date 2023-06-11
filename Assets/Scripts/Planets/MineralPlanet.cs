using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MineralPlanet : Planet
{
    [SerializeField] private float _miningElapsedTime;
    [SerializeField] private float _miningCooldown;

    private BaseMineral _primaryMinedMineral;
    private BaseMineral _secondaryMinedMineral;


    [SerializeField] private MineralMine _primaryMine;
    [SerializeField] private MineralMine _secondaryMine;

    [SerializeField] private int _primaryMineralProduce;
    [SerializeField] private int _secondaryMineralProduce;

    void Start()
    {

        if(_primaryMine == null || _secondaryMine == null)
        {
            return;
        }

        GameManager.Instance.HomePlanet.MineralPlanets.Add(this);

        _primaryMinedMineral = (BaseMineral)Activator.CreateInstance(_primaryMine.Mineral.GetType());
        _primaryMinedMineral.Amount = _primaryMineralProduce;

        _secondaryMinedMineral = (BaseMineral)Activator.CreateInstance(_secondaryMine.Mineral.GetType());
        _secondaryMinedMineral.Amount = _secondaryMineralProduce;

        StartCoroutine(MineMineral());
    }

    private IEnumerator MineMineral()
    {
        while (true)
        {
            if (_miningElapsedTime >= _miningCooldown)
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
