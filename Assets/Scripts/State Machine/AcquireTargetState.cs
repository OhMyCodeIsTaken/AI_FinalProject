using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireTargetState : CoroutineState
{
    public override bool IsLegal()
    {
        if(handler.Spaceship.TargetPlanet == null)
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

            // TODO: consider making this more generic
            // handler.Spaceship.TargetPlanet = OnAcquireTarget.Invoke();

            // Get Mining Quest
            System.Random rand = new System.Random();

            List<MiningQuest> questsRef = GameManager.Instance.HomePlanet.QuestManager.MiningQuests;
            int randomIndex = rand.Next(0, questsRef.Count);

            handler.Spaceship.CurrentMiningQuest = questsRef[randomIndex];
            handler.Spaceship.IsQuestOngoing = true;

            MiningQuest miningQuestRef = (MiningQuest)handler.Spaceship.CurrentMiningQuest;

            // Choose a random Planet from valid Mineral Planets
            List<MineralPlanet> validMineralPlanets = new List<MineralPlanet>();

            foreach (MineralPlanet potentialPlanet in GameManager.Instance.HomePlanet.MineralPlanets)
            {
                if(potentialPlanet.PrimaryMinedMineral.MineralType == miningQuestRef.MineralToMine ||
                   potentialPlanet.SecondaryMinedMineral.MineralType == miningQuestRef.MineralToMine )
                {
                    validMineralPlanets.Add(potentialPlanet);
                }
            }

            randomIndex = rand.Next(0, validMineralPlanets.Count);
            handler.Spaceship.TargetPlanet = validMineralPlanets[randomIndex];
        }
        yield return null;
    }
}
