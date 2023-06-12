using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineState : CoroutineState
{
    BaseMineral mineralRef;
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
        foreach (BaseMineral mineral in handler.Spaceship.MineralInventory.Minerals)
        {
            if(mineral.GetType() == currentMiningQuestRef.MineralToMine.Mineral.GetType())
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
                foreach (BaseMineral mineral in handler.Spaceship.OccupyingPlanet.MineralInventory.Minerals)
                {
                    if (mineral.Amount > 0)
                    {
                        int amountToDeposit;
                        if (mineral.Amount >= _mineAmount)
                        {
                            amountToDeposit = _mineAmount;
                        }
                        else
                        {
                            amountToDeposit = mineral.Amount;
                        }
                        handler.Spaceship.MineralInventory.TransferMineralToInventory(mineral, amountToDeposit);
                    }
                }
            }

            _mineElapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
