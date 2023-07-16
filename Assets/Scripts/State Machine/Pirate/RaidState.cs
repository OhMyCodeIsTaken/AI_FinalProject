using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidState : CoroutineState
{
    [SerializeField] private MineralInventory _mineralInventory;
    [SerializeField] private Spaceship _target;
    [SerializeField] private float _attackCooldown;

    System.Random rand = new System.Random();
    private SpaceshipType[] _minersAndSecurity = new SpaceshipType[2] { SpaceshipType.MINER, SpaceshipType.SECURITY };
    public override bool IsLegal()
    {
        Planet occupyingPlanet = handler.Spaceship.OccupyingPlanet;
        if (occupyingPlanet.AreThereSpecificVisitingShips(_minersAndSecurity))
        {
            return true;
        }
        return false;
    }

    public override void OnStateEnter()
    {
        _target = null;
    }

    public override void OnStateExit()
    {
        
    }

    public override IEnumerator RunState()
    {
        if(handler.Spaceship.OccupyingPlanet.VisitingSpaceships.Count < 2)
        {
            // Make sure that there is atleast one other spaceship on planet
            yield return null;
        }

        foreach (Spaceship spaceship in handler.Spaceship.OccupyingPlanet.VisitingSpaceships)
        {
            // Skip pirates - no friendly fire!
            if(spaceship is PirateSpaceship)
            {
                continue;
            }

            // Always prioritizes Security over Miner
            if(_target == null || _target.SpaceshipType < spaceship.SpaceshipType)
            {
                _target = spaceship;
            }
        }

        if(_target.SpaceshipType is SpaceshipType.SECURITY)
        {
            _target.Damagable.TakeDamage(handler.Spaceship.Damagable.Damage);
        }
        else
        {
            MiningSpaceship miner = _target.GetComponent<MiningSpaceship>();
            TryToStealRandomMineralFromMiner(miner);
        }
        yield return new WaitForSeconds(_attackCooldown);
    }

    private void TryToStealRandomMineralFromMiner(MiningSpaceship miner)
    {
        Debug.Log("Trying to rob Miner Ship");
        int randomMineralTypeIndex = rand.Next(1, 5 + 1);

        Mineral playerMineral = miner.MineralInventory.Minerals[randomMineralTypeIndex];

        if(playerMineral.Amount > 1)
        {
        Debug.Log("Robbed Miner Ship");
            _mineralInventory.TransferMineralToInventory(playerMineral, 1);
        }
    }
}
