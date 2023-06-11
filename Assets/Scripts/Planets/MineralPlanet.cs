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

    public BaseMineral PrimaryMinedMineral { get => _primaryMinedMineral; }
    public BaseMineral SecondaryMinedMineral { get => _secondaryMinedMineral; }
    public MineralMine PrimaryMine { get => _primaryMine; }
    public MineralMine SecondaryMine { get => _secondaryMine; }

    private void Awake()
    {
        if (PrimaryMine == null || SecondaryMine == null)
        {
            return;
        }

        GameManager.Instance.HomePlanet.MineralPlanets.Add(this);

        _primaryMinedMineral = (BaseMineral)Activator.CreateInstance(PrimaryMine.Mineral.GetType());
        _primaryMinedMineral.Amount = _primaryMineralProduce;

        _secondaryMinedMineral = (BaseMineral)Activator.CreateInstance(SecondaryMine.Mineral.GetType());
        _secondaryMinedMineral.Amount = _secondaryMineralProduce;
    }

    void Start()
    {

        if(PrimaryMine == null || SecondaryMine == null)
        {
            return;
        }

        StartCoroutine(MineMineral());
    }

    private IEnumerator MineMineral()
    {
        while (true)
        {
            if (_miningElapsedTime >= _miningCooldown)
            {
                MineralInventory.AddMineralToInventory(PrimaryMinedMineral);
                MineralInventory.AddMineralToInventory(SecondaryMinedMineral);

                // Reset 
                _miningElapsedTime = 0;
            }

            _miningElapsedTime += Time.deltaTime;
            yield return null;
        }

    }
}
