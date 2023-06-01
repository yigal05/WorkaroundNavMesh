using System;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;  // Transform del punto de inicio del enlace
   // public GameObject target;  // Transform del punto final del enlace

    private void Start()
    {
       // agent.destination = target.transform.position;
    }

    private void Update()
    {
        //agent.destination = target.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.destination = hit.point;
            }
        }
    }
}
