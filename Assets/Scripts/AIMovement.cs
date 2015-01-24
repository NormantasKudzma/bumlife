using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

   float rotation;
   public int movementDirection;
   public float movementSpeed;
	// Use this for initialization
	void Start () {
      Debug.Log(movementDirection);
      //rotation = Random.Range(-50f, 50f);
      rigidbody.velocity = new Vector3(1, 0, 0) * movementDirection * movementSpeed;
	}

   void FixedUpdate() {
      
   }
}
