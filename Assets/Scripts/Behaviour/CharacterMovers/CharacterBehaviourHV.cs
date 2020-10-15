using UnityEngine;

public class CharacterBehaviourHV : CharacterBehaviour
{
   protected override void OnHorizontal()
   {
      hInput = Input.GetAxis("Horizontal") * moveSpeed.value;
   }
}