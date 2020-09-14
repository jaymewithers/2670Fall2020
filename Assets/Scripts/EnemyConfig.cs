﻿using UnityEngine;

public class EnemyConfig : MonoBehaviour
{
   private EnemyHealth eHealth;

   private void Start()
   {
      eHealth = ScriptableObject.CreateInstance<EnemyHealth>();
   }

   private void OnTriggerEnter(Collider other)
   {
      eHealth.value -= 0.1f;
   }
}