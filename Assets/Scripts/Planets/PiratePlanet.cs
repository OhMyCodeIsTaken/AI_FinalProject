using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiratePlanet : Planet
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameManager.Instance.PirateManager.PiratePlanets.Add(this);
    }
}
