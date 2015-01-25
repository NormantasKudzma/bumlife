using UnityEngine;
using System.Collections;

public class AIBum : AIMovement
{
		private float waitForPedstrianCooldown;
		private Vector3 velocity;
		private Quaternion rotation;
		public bool isCaught = false;
		private int state = 0;

		void Start ()
		{
				base.Start ();
				velocity = new Vector3 (rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
				rotation = transform.rotation;
		
		}
		
		public bool IsBegging {
				get{ return waitForPedstrianCooldown > 0;}
		}


		void FixedUpdate ()
		{
				switch (state) {
				case 1:
						if (waitForPedstrianCooldown > 0) {
								if (isCaught) {
										waitForPedstrianCooldown = 0;
										state = 0;
										rigidbody.velocity = velocity;
										transform.rotation = rotation;
								}
								waitForPedstrianCooldown -= Time.deltaTime;
					
						} else {
								state = 0;
								rigidbody.velocity = velocity;
								transform.rotation = rotation;
						}
						break;
				}

				
		}
	
		
		void OnTriggerEnter (Collider other)
		{
				if (!isCaught && (state == 0)) {
						if (other.tag == "Pedestrian" && !other.GetComponent<Pedestrian> ().wasBegged) {
								
								velocity = new Vector3 (rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
								rotation = transform.rotation;
								rigidbody.velocity = Vector3.zero;
								state = 1;
								transform.LookAt (other.gameObject.transform.position, new Vector3 (0, 0, -1));
								waitForPedstrianCooldown = 1f;
						} 
				}
				if (!isCaught && other.tag == "Player") {
						isCaught = true;
						Debug.Log (other.gameObject);
						Destroy (GetComponentInChildren<SightRadius> ());
						int movementDirection = (Random.Range (0, 2) == 0) ? 1 : -1;
						rigidbody.velocity = new Vector3 (movementDirection, 0, 0) * movementSpeed * 2;
				}
		}
}
