using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVictimTargetState : CoroutineState
{
    [SerializeField] private float _pityCounter = 0;
    [SerializeField] private float _pityCounterMax = 7;
    [SerializeField] private float _scanIntervals = 3;

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
        Debug.Log("Exit Victim State");
    }

    public override IEnumerator RunState()
    {
        List<MineralPlanet> mineralPlanetsRef = GameManager.Instance.MineralPlanets;
        System.Random rand = new System.Random();
        MineralPlanet randomMineralPlanet;
        int randomIndex;

        while (handler.Spaceship.TargetPlanet == null)
        {
            // Pity Counter ensures the pirate gets a valid target every X times
            if (_pityCounter == _pityCounterMax)
            {               
                List<MineralPlanet> validMineralPlanets = new List<MineralPlanet>();

                // Add all planets that have Miners on them and NO OTHER PIRATES
                foreach (MineralPlanet mineralPlanet in mineralPlanetsRef)
                {
                    if(IsPlanetValidForRaiding(mineralPlanet))
                    {
                        validMineralPlanets.Add(mineralPlanet);
                    }
                }
                
                // Get a random planet from the valid planets, and target it.
                if(validMineralPlanets.Count > 0)
                {
                    _pityCounter = 0;
                    randomIndex = rand.Next(0, validMineralPlanets.Count);
                    randomMineralPlanet = validMineralPlanets[randomIndex];

                    handler.Spaceship.TargetPlanet = randomMineralPlanet;
                }               
            }

            /* Get random Mineral Planet, scan it for Miners NO OTHER pirates. 
             * If scan succeeds, get the planet as the target.
             * If scan fails, keep waiting until next scan.
             */
            else
            {
                // Get Random Mineral Planet                
                randomIndex = rand.Next(0, mineralPlanetsRef.Count);
                randomMineralPlanet = mineralPlanetsRef[randomIndex];


                // Check for Miners && no pirates on planet
                if(IsPlanetValidForRaiding(randomMineralPlanet))
                {
                    handler.Spaceship.TargetPlanet = randomMineralPlanet;
                }
                else
                {
                    _pityCounter++;
                }
            }

            // Wait X seconds to scan again
            yield return new WaitForSeconds(_scanIntervals);
        }
    }

    private bool IsPlanetValidForRaiding(MineralPlanet planet)
    {
        bool isPlanetValidForRaiding = false;

        if (planet.VisitingSpaceships.Count == 0)
        {
            return false;
        }

        // Check for Miners && no pirates on planet
        foreach (Spaceship spaceship in planet.VisitingSpaceships)
        {
            if (spaceship is PirateSpaceship)
            {
                // avoids planets that already has pirates
                return false;
            }
            else if (spaceship is MiningSpaceship)
            {
                isPlanetValidForRaiding = true;
            }
        }

        return isPlanetValidForRaiding;
    }
}
