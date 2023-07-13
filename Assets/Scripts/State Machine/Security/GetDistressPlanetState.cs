using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistressPlanetState : CoroutineState
{
    public override bool IsLegal()
    {
        if (handler.Spaceship.TargetPlanet == null)
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
        if (handler.Spaceship.OccupyingPlanet != GameManager.Instance.HomePlanet)
        {
            handler.Spaceship.TargetPlanet = GameManager.Instance.HomePlanet;
        }
        else
        {
            // Get Distress Planet
            if (GameManager.Instance.HomePlanet.QuestManager.DistressedPlanets.Count <= 0)
            {
                // No distressed Planets, return and run state machine again (go back to scanning)
                yield return null;
            }
            else
            {
                handler.Spaceship.TargetPlanet = GameManager.Instance.HomePlanet.QuestManager.DistressedPlanets[0];
                GameManager.Instance.HomePlanet.QuestManager.DistressedPlanets.RemoveAt(0);
            }
        }
    }
}
