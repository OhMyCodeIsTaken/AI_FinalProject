using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillageState : CoroutineState
{
    // TODO: Ask On how to interupt (relevant to this state)

    [SerializeField] private PirateSpaceship _pirateSpaceship;

    [SerializeField] private float _pillageTimer;

    private SpaceshipType[] _minersAndSecurity = new SpaceshipType[2] { SpaceshipType.MINER, SpaceshipType.SECURITY };

    public override bool IsLegal()
    {
        Planet occupyingPlanet = handler.Spaceship.OccupyingPlanet;
        if (!occupyingPlanet.AreThereSpecificVisitingShips(_minersAndSecurity) && !occupyingPlanet.MineralInventory.IsInventoryEmpty)
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

        // After X seconds, pillage all resources on the planet
        yield return new WaitForSeconds(_pillageTimer);

        // TODO: check how to interupt

        foreach (Mineral planetMineral in handler.Spaceship.OccupyingPlanet.MineralInventory.Minerals)
        {
            if (planetMineral.Amount > 0)
            {
                _pirateSpaceship.MineralInventory.TransferMineralToInventory(planetMineral, planetMineral.Amount);
            }
        }
    }
    
}

