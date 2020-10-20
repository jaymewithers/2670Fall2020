using System.Collections;
using UnityEngine;

public class DeathBehaviour : MonoBehaviour
{
   public GameObject gameObj;
   public FloatData health, lives;
   public Vector3Data spawnPoint;

   private void Update()
   {
      if (!(health.value <= 0)) return;
      gameObj.SetActive(false);
      StartCoroutine(Respawn());
   }

   private IEnumerator Respawn()
   {
      if (gameObj.name == "Player" && lives.value > 0)
      {
         yield return new WaitForSeconds(3f);
         gameObj.transform.position = spawnPoint.value;
         health.value = 1f;
         gameObj.SetActive(true);
         StopCoroutine(Respawn());
      }

      if (gameObj.name != "Player" || !(lives.value <= 0)) yield break;
      gameObj.SetActive(false);
      print("Game Over");
      StopCoroutine(Respawn());
   }
}