using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBehaviour : MonoBehaviour
{
   private WaitForFixedUpdate wffu = new WaitForFixedUpdate();
   private NavMeshAgent agent;
   public Transform player;
   private bool canHunt, canPatrol;

   private void Start()
   {
      agent = GetComponent<NavMeshAgent>();
      StartCoroutine(Patrol());
   }

   private IEnumerator OnTriggerEnter(Collider other)
   {
      canHunt = true;
      while (canHunt)
      {
         yield return wffu;
         agent.destination = player.position;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      canHunt = false;
      StartCoroutine(Patrol());
   }

   private IEnumerator Patrol()
   {
      canPatrol = true;
      yield break;
   }
}