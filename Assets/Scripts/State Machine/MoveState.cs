using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : CoroutineState
{
    public override bool IsLegal()
    {
        if(handler.Spaceship.TargetPlanet != null)
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
        handler.Spaceship.TargetPlanet = null;
    }

    public override IEnumerator RunState()
    {
        float counter = 0;
        Vector3 startPos = transform.position;


        Vector3 destination = handler.Spaceship.TargetPlanet.transform.position;

        while (counter < 1)
        {
            Vector3 posLerp = Vector3.Lerp(startPos, destination, counter);
            handler.Spaceship.transform.position = posLerp;
            counter += Time.deltaTime * handler.Spaceship.MovementMod;
            yield return new WaitForEndOfFrame();
        }

        handler.Spaceship.transform.position = destination;
    }
}
