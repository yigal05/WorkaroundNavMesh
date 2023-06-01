using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Nextposition : MonoBehaviour
{
    void Start()
    {
        // Update the transform position explicitly in the OnAnimatorMove callback
        GetComponent<NavMeshAgent>().updatePosition = true;
    }

    void OnAnimatorMove()
    {
        transform.position = GetComponent<NavMeshAgent>().nextPosition;
    }
}
