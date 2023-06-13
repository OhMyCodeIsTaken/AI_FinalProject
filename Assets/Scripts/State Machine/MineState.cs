using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineState : CoroutineState
{
    Mineral mineralRef;
    MiningQuest currentMiningQuestRef;


    [SerializeField] private float _mineElapsedTime;
    [SerializeField] private float _mineCooldown;
    [SerializeField] private int _mineAmount;

    public override bool IsLegal()
    {
        if (handler.Spaceship.OccupyingPlanet is MineralPlanet && handler.Spaceship.IsQuestOngoing)
        {
            return true;
        }
        return false;
    }

    public override void OnStateEnter()
    {
        currentMiningQuestRef = (MiningQuest)handler.Spaceship.CurrentMiningQuest;
        foreach (Mineral mineral in handler.Spaceship.MineralInventory.Minerals)
        {
            if(mineral.MineralType == currentMiningQuestRef.MineralToMine)
            {
                mineralRef = mineral;
                return;
            }
        }
    }

    public override void OnStateExit()
    {
        handler.Spaceship.IsQuestOngoing = false;
    }

    public override IEnumerator RunState()
    {
        while (mineralRef.Amount < currentMiningQuestRef.AmountToMine)
        {
            if (_mineElapsedTime >= _mineCooldown)
            {
                _mineElapsedTime = 0;
                foreach (Mineral planetMineral in handler.Spaceship.OccupyingPlanet.MineralInventory.Minerals)
                {
                    if (planetMineral.Amount > 0)
                    {
                        int amountToMine;
                        if (planetMineral.Amount >= _mineAmount)
                        {
                            amountToMine = _mineAmount;
                        }
                        else
                        {
                            amountToMine = planetMineral.Amount;
                        }
                        handler.Spaceship.MineralInventory.TransferMineralToInventory(planetMineral, amountToMine);
                    }
                }
            }

            _mineElapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
