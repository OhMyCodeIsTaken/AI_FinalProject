using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CoroutineState
{
    private SpaceshipType[] _pirates = new SpaceshipType[1] { SpaceshipType.PIRATE };

    private Spaceship _target;
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

        if(_target == null)
        {
            foreach (Spaceship spaceship in handler.Spaceship.OccupyingPlanet.VisitingSpaceships)
            {
                if (spaceship.SpaceshipType is SpaceshipType.PIRATE)
                {
                    _target = spaceship; // target is first Pirate Found, causing multiple Security to focus fire on the same Pirate
                    break;
                }
            }
        }        

        _target.Damagable.TakeDamage(handler.Spaceship.Damagable.Damage);
            
        yield return new WaitForSeconds(_attackCooldown);
    }
}
