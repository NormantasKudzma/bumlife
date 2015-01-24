﻿using UnityEngine;
using System.Collections;

public class Pedestrian : AIMovement
{
		bool clicked = false;
		public float chance = 0.5f;
		public GameObject bottle;
		public float bottleDropCooldown = 3;
		public float waitForBumCooldown = 0;
		public int state = 0;
		private Vector3 velocity;
		private Quaternion rotation;
		private bool wasBegged = false;


		void FixedUpdate ()
		{
				switch (state) {
				case 0:
						if (bottleDropCooldown > 0) {
								bottleDropCooldown -= Time.deltaTime;
						} else {
								if (Random.Range (0f, 1.0f) > 0.5f) {
										Instantiate (bottle, this.transform.position, Quaternion.Euler (90, 0, 0));
                        
								}
								bottleDropCooldown = 1f;
						}
						break;
				case 1:
						if (waitForBumCooldown > 0) {
								waitForBumCooldown -= Time.deltaTime;
						} else {
								state = 0;
								rigidbody.velocity = velocity;
								transform.rotation = rotation;
						}
						break;

				}

		}

		public void OnTriggerEnter (Collider collider)
		{
				if (!wasBegged && (collider.gameObject.tag == "Bum" || (collider.gameObject.tag == "Player" && clicked))) {
						
						velocity = new Vector3 (rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
						rotation = transform.rotation;
						rigidbody.velocity = Vector3.zero;
						transform.LookAt (collider.gameObject.transform.position, this.transform.up);
						state = 1;
						waitForBumCooldown = 0.5f;
						wasBegged = true;
				}
			
		}

		
		public void OnMouseDown ()
		{
				clicked = true;
				PlayerController plr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
				plr.startFollowing(this);
				Debug.Log ("asdasd");
		}



}
