using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistressState : CoroutineState
{
    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.CompareTag("Pirate") )
        {
            Debug.Log("Collision");
            handler.Interrupt(this);
        }
    }

    public override bool IsLegal()
    {
        return true;
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override IEnumerator RunState()
    {
        Debug.Log("AAAAAAGHHHHHHHH");
        yield return new WaitForSeconds(1f);
    }
}
