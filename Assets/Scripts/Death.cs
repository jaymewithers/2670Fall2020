using UnityEngine;

public class Death : MonoBehaviour
{
   public GameObject gameObj;
   public FloatData health;

   private void Update()
   {
      if (health.value <= 0)
      {
         gameObj.SetActive(false);
      }
   }
}