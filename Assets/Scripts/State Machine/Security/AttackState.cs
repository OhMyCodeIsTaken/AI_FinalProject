using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CoroutineState
{
    private SpaceshipType[] _pirates = new SpaceshipType[1] { SpaceshipType.PIRATE };

   
    [SerializeField] private float _attackCooldown;

    public override bool IsLegal()
    {
        if(handler.Spaceship.OccupyingPlanet.AreThereSpecificVisitingShips(_pirates))
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
        if (handler.Spaceship.OccupyingPlanet.VisitingSpaceships.Count < 2)
        {
            // Make sure that there is atleast one other spaceship on planet
            yield return null;
        }

        // Firepower is split amoung all pirates on the planet
        int damagePerSpaceship = handler.Spaceship.Damagable.Damage / handler.Spaceship.OccupyingPlanet.VisitingSpaceships.Count;

        foreach (Spaceship spaceship in handler.Spaceship.OccupyingPlanet.VisitingSpaceships)
        {
            // Skips Mining and Security spaceships (also skips itself)
            if (spaceship is MiningSpaceship || spaceship is SecuritySpaceship)
            {
                continue;
            }

            spaceship.Damagable.TakeDamage(damagePerSpaceship);
            
        }

        yield return new WaitForSeconds(_attackCooldown);
    }
}
