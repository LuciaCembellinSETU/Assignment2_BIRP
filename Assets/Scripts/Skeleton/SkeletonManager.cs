using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    public SkeletonRooms room;

    private GameObject[] agents;

    // Start is called before the first frame update
    void Start()
    {
        if(room == SkeletonRooms.Room1)
        {
            agents = GameObject.FindGameObjectsWithTag("SkeletonR1");
            Debug.Log("Found Agents: " + agents.Length);
        }
        else if (room == SkeletonRooms.Room2)
        {
            agents = GameObject.FindGameObjectsWithTag("SkeletonR2");
        }
        else if (room == SkeletonRooms.Room3)
        {
            agents = GameObject.FindGameObjectsWithTag("SkeletonR3");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (agents == null || agents.Length == 0)
        {
            Debug.LogError("Agents were not found");
            return;
        }

        foreach (GameObject a in agents)
        {
            SkeletonChase skeletonChase = a.GetComponent<SkeletonChase>();
            if (skeletonChase != null)
            {
                skeletonChase.StartChasing();
            }
            else
            {
                Debug.LogError("El objeto " + a.name + " no tiene el script ChasePlayer.");
            }
        }
    }
}
