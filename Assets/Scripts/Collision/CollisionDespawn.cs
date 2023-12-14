using UnityEngine;

/*
  Despawn Collision Elements
  - Part of Despawner Element, gets data of object that it collided with and deletes it
*/

public class CollisionDespawn : MonoBehaviour
{

  // Destroy GameObject once it hits the Despawner GameObject
  void OnCollisionEnter (Collision collision)
  {
    if (collision.collider.tag == "Collision")
    {

      GameObject collisionObject;
      collisionObject = collision.gameObject;
      
      Destroy(collisionObject);
      
    }
  }

}