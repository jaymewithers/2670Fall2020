using UnityEngine;

public class Death : MonoBehaviour
{
   public GameObject gameObj;
   public FloatData health;
   public CharacterMoverFromClass spawnPoint;

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