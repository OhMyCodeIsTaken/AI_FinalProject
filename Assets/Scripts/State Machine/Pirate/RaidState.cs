using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidState : CoroutineState
{
    private SpaceshipType[] _minersAndSecurity = new SpaceshipType[2] { SpaceshipType.MINER, SpaceshipType.SECURITY };
    [SerializeField] private Spaceship _target;
    [SerializeField] private float _attackCooldown;
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
        // TODO: refactor to make this work with interupts

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

        _target.Damagable.TakeDamage(handler.Spaceship.Damagable.Damage);
        yield return new WaitForSeconds(_attackCooldown);
    }
}
