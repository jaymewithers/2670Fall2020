using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
   private readonly WaitForFixedUpdate wffu = new WaitForFixedUpdate();
   private NavMeshAgent agent;
   public Transform destination;
   public List<Transform> patrolPoints;
   private bool canHunt, canPatrol;
   private int i;

   private void Start()
   {
      i = 0;
      agent = GetComponent<NavMeshAgent>();
      StartCoroutine(Patrol());
   }

   private void OnTriggerEnter(Collider other)
   {
      canHunt = true;
      canPatrol = false;
      StartCoroutine(Hunt());
   }

   private void OnTriggerExit(Collider other)
   {
      canHunt = false;
      canPatrol = true;
      StartCoroutine(Patrol());
   }

   private IEnumerator Hunt()
   {
      canHunt = true;
      while (canHunt)
      {
         yield return wffu;
         agent.destination = destination.position;
      }
   }

   private IEnumerator Patrol()
   {
      canPatrol = true;
      while (canPatrol)
      {
         yield return wffu;
         if (agent.pathPending || !(agent.remainingDistance < 0.5f)) continue;
         agent.destination = patrolPoints[i].position;
         i = (i + 1) % patrolPoints.Count;
      }
   }
}