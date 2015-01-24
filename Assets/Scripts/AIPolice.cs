using UnityEngine;
using System.Collections;

public class AIPolice : AIMovement
{
		private GameObject bum = null;
		private bool hasCaught = false;
		private Vector3 originalVelocity;
		void Update ()
		{
				
		}
		void OnTriggerEnter (Collider other)
		{
				if (other.tag == "Stench" && !hasCaught) {
						if (bum == null || bum.tag == "Player") {
								bum = other.transform.parent.gameObject;
						}
						originalVelocity = rigidbody.velocity;
						rigidbody.velocity = new Vector3 ();
				} else if (other.tag == "Bum") {
			
						Debug.Log ("Something smells fishy");
						hasCaught = true;
						rigidbody.velocity = new Vector3 (1, 0, 0) * movementSpeed;
						other.gameObject.rigidbody.velocity = new Vector3 (1, 0, 0) * movementSpeed;
				} else if (other.tag == "Player") {
						Destroy (other.gameObject);
				}
		}

		void OnTriggerStay (Collider other)
		{
				
				if (other.tag == "Stench" && !hasCaught) {
						if (bum == null || bum.tag == "Player") {
			
								bum = other.transform.parent.gameObject;
								rigidbody.velocity = new Vector3 ();
						}
						transform.position = Vector3.MoveTowards (transform.position, bum.transform.position, Time.deltaTime);
					
				}
		}

		void OnTriggerExit (Collider other)
		{
		  
				if (other.tag == "Stench") {
						bum = null;
						Debug.Log (originalVelocity);
						rigidbody.velocity = originalVelocity;
				}
		}

		void FixedUpdate ()
		{
				if (bum != null) {
						
				}
		}
}
