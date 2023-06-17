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
        handler.Spaceship.LeaveOccupyingPlanet();
    }

    public override void OnStateExit()
    {
        handler.Spaceship.OccupyPlanet(handler.Spaceship.TargetPlanet);
    }

    public override IEnumerator RunState()
    {
        Vector3 startPos = transform.position;

        Vector3 destination = handler.Spaceship.TargetPlanet.transform.position;

        float distanceToPlanet = (destination - startPos).magnitude;


        while(distanceToPlanet >= 0.5f)
        {
            handler.Spaceship.transform.position = Vector3.MoveTowards(handler.Spaceship.transform.position, 
                                                   destination, handler.Spaceship.MovementMod * Time.deltaTime);

            distanceToPlanet = (destination - handler.Spaceship.transform.position).magnitude;
            yield return new WaitForEndOfFrame();
        }

        handler.Spaceship.transform.position = destination;
        

        //float counter = 0;
        //while (counter < 1)
        //{
        //    Vector3 posLerp = Vector3.Lerp(startPos, destination, counter);
        //    handler.Spaceship.transform.position = posLerp;
        //    counter += Time.deltaTime * handler.Spaceship.MovementMod;
        //    yield return new WaitForEndOfFrame();
        //}

        //handler.Spaceship.transform.position = destination;
    }
}
