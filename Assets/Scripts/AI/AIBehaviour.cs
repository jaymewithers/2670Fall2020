using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
   private WaitForFixedUpdate wffu = new WaitForFixedUpdate();
   private NavMeshAgent agent;
   public Transform player;
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
      canPatrol = true;
      StopCoroutine(Patrol());
      canHunt = true;
      StartCoroutine(Hunt());
   }
   
   private void OnTriggerExit(Collider other)
   {
      canHunt = false;
      StopCoroutine(Hunt());
      canPatrol = true;
      StartCoroutine(Patrol());
   }
   
   private IEnumerator Hunt()
   {
      canHunt = true;
      while (canHunt)
      {
         yield return wffu;
         agent.destination = player.position;
      }
   }

   private IEnumerator Patrol()
   {
      canPatrol = true;
      while (canPatrol)
      {
         if (agent.pathPending || !(agent.remainingDistance < 0.5f)) yield break;
         agent.destination = patrolPoints[i].position;
         i = (i + 1) % patrolPoints.Count;
      }
   }
}