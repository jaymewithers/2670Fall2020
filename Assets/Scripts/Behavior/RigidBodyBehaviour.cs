using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyBehaviour : MonoBehaviour
{
   private Rigidbody rigidBodyObj;
   public float force;
   private Vector3 forceObj;

   private void Start()
   {
       rigidBodyObj = GetComponent<Rigidbody>();
   }

   private void OnCollisionEnter(Collision other)
   {
       forceObj.y = force;
       rigidBodyObj.AddForce(forceObj);
   }
}