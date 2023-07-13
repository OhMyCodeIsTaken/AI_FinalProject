using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuritySpaceship : Spaceship
{
    protected override void InitSpaceship()
    {
        base.InitSpaceship();
        _spaceshipType = SpaceshipType.SECURITY;
        OccupyingPlanet = GameManager.Instance.HomePlanet;
        transform.position = GameManager.Instance.HomePlanet.transform.position;
    }
}
