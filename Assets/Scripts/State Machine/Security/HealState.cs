using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealState : CoroutineState
{
    [SerializeField] private int _healAmount;
    [SerializeField] private int _healCooldown;

    public override bool IsLegal()
    {
        if(!handler.Spaceship.OccupyingPlanet)
        {
            return false;
        }

        //search for injured spaceship in visiting planet
        foreach(Spaceship spaceship in handler.Spaceship.OccupyingPlanet.VisitingSpaceships)
        {
            if(ReferenceEquals(spaceship, handler.Spaceship) || spaceship is PirateSpaceship)
            {
                // skip checking itself and pirates
                continue;
            }

            if(spaceship.Damagable.CurrentHealth < spaceship.Damagable.MaxHealth)
            {
                return true;
            }
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
        //search for injured spaceship in visiting planet
        foreach (Spaceship spaceship in handler.Spaceship.OccupyingPlanet.VisitingSpaceships)
        {
            if (ReferenceEquals(spaceship, handler.Spaceship) || spaceship is PirateSpaceship)
            {
                // skip checking itself and pirates
                continue;
            }

            if (spaceship.Damagable.CurrentHealth < spaceship.Damagable.MaxHealth)
            {
                spaceship.Damagable.Heal(_healAmount);
                yield return new WaitForSeconds(_healCooldown);
            }
        }
    }
}
