using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestingScript : MonoBehaviour
{
    public NavMeshAgent Agent; // reference to character
    public Transform target; // object to follow
    public float EndLinkDistance = 3; // distance allow to jump
    public OffMeshLink OffMeshLink; //componet to bind two blocks 
    float _stoppedlapse;

    // Update is called once per frame
    void Update()
    {
        if (Agent.isOnNavMesh && Agent.destination != target.position) //if chter is on the navmesh and isnot where target yet,so
        {
            Agent.SetDestination(target.position); // set like destination the target’s position
        }

        var direction = target.position - Agent.transform.position; // to get direction to go 
        direction.Normalize(); // to normalize the direction to get o or 1
        OffMeshLink.startTransform.position = Agent.transform.position; // equalize start position of offmeshlink with our chter
        OffMeshLink.endTransform.position = Agent.nextPosition + direction * EndLinkDistance; //find until where to able to jumo
        OffMeshLink.UpdatePositions(); // update the position of the agent

        var DistanceToPathEnd = Vector3.Distance(Agent.pathEndPosition, Agent.transform.position); //create the gap (offmeshlink)
        if (DistanceToPathEnd <= Agent.radius) // agent has stopped / can’t go further
        {
            Debug.Log("turn on link");
            _stoppedlapse += Time.deltaTime; //time that it has been stopped 
            if (_stoppedlapse >= 1) // if the time stopped is major than 1 then
            {
                Debug.Log("agent stuck");
                Agent.enabled = false; //turn off the agent
                _stoppedlapse = 0; //set the time in 0
            }
            else //if not
            {
                Agent.enabled = true; //turn on the agent
                OffMeshLink.enabled = true; //turn on the offmesh link
                Agent.ActivateCurrentOffMeshLink(true); //change the status to Activate
            }
        }
    }
}
