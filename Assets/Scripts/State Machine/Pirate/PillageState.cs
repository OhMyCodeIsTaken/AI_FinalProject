using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillageState : CoroutineState
{
    [SerializeField] private int _pillageAmount;

    // TODO: Ask On how to interupt (relevant to this state)

    [SerializeField] private PirateSpaceship _pirateSpaceship;

    [SerializeField] private float _pillageTimer;

    

    public override bool IsLegal()
    {
        Planet occupyingPlanet = _pirateSpaceship.OccupyingPlanet;
        if (!occupyingPlanet.MineralInventory.IsInventoryEmpty)
        {
            return true;
        }

        return false;
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override IEnumerator RunState()
    {

        // After X seconds, pillage resources on the planet
        yield return new WaitForSeconds(_pillageTimer);

        foreach (Mineral planetMineral in _pirateSpaceship.OccupyingPlanet.MineralInventory.Minerals)
        {
            if (planetMineral.Amount > 0)
            {
                int amountToMine;
                if (planetMineral.Amount >= _pillageAmount)
                {
                    amountToMine = _pillageAmount;
                }
                else
                {
                    amountToMine = planetMineral.Amount;
                }
                _pirateSpaceship.MineralInventory.TransferMineralToInventory(planetMineral, amountToMine);
            }
        }

        GameManager.Instance.ScoreManager.UpdateScore(-_pillageAmount);
    }
    
}

