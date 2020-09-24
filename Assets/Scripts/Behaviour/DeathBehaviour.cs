using UnityEngine;

public class DeathBehaviour : MonoBehaviour
{
   public GameObject gameObj;
   public FloatData health;
   public CharacterMover spawnPoint;

   private void Update()
   {
      if (!(health.value <= 0)) return;
      gameObj.SetActive(false);

      if (gameObj.name != "Player") return;
      gameObj.transform.position = spawnPoint.currentSpawnPoint.value;
      health.value = 1f;
      gameObj.SetActive(true);
   }
}