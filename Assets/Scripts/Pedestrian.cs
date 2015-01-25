using UnityEngine;
using System.Collections;

public class Pedestrian : AIMovement
{
		bool clicked = false;
		public float chance = 0.5f;
		public GameObject bottle;
		public float bottleDropCooldown = 0;
		public float waitForBumCooldown = 0;
		public int state = 0;
		private Vector3 velocity;
		private Quaternion rotation;
		
		public bool wasBegged = false;

		
		void Start ()
		{
				base.Start ();
				velocity = new Vector3 (rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
				rotation = transform.rotation;
				
		}
	
		public int cashInWallet = 5;
		public int maxCashInWallet = 10;
		private int successChance = 40;
		private float maxStenchValue = 5f;

		protected void Start(){
			base.Start();
			cashInWallet = Random.Range(0, maxCashInWallet);
			if (cashInWallet > 15 || cashInWallet < 0){
				Debug.Log("Kazkas blogai");
			}
		}

		void FixedUpdate ()
		{
				switch (state) {
				case 0:
						if (bottleDropCooldown > 0) {
								bottleDropCooldown -= Time.deltaTime;
						} else {
								if (Random.Range (0f, 1.0f) > 0.9f) {
										Instantiate (bottle, this.transform.position, Quaternion.Euler (90, 0, 0));
                        
								}
								bottleDropCooldown = Random.Range (1f, 2f);
						} 
						break;
				case 1:
						if (waitForBumCooldown > 0) {
								waitForBumCooldown -= Time.deltaTime;
								
						} else {
								animator.SetBool("isMoving", true);
								state = 0;
								rigidbody.velocity = velocity;
								transform.rotation = rotation;
						}
						break;

				}

		}

		public void OnTriggerEnter (Collider collider)
		{

				if (state == 0 && !wasBegged && 
						((collider.gameObject.tag == "Bum" 
						&& !collider.gameObject.GetComponent<AIBum> ().isCaught) 
						|| (collider.gameObject.tag == "Player" && clicked))) {
						
						velocity = new Vector3 (rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z);
						rotation = transform.rotation;
						rigidbody.velocity = Vector3.zero;
						transform.LookAt (collider.gameObject.transform.position, new Vector3(0, 0, -1));
						state = 1;
						waitForBumCooldown = 0.5f;
						wasBegged = true;
						animator.SetBool("isMoving", false);
						Player plr = collider.GetComponent<Player>();
						if (plr != null){
							rollForMoney(plr);
						}
				}
			
		}
		
		public void OnMouseDown(){
			clicked = true;
		}
		
		void rollForMoney(Player plr){
			int successRoll = Random.Range(0, 100);
			if (successRoll < successChance - (plr.stenchRadius * successChance / maxStenchValue)){
				int minVal = (int)(plr.stenchRadius * maxStenchValue / cashInWallet);
				int amt = Random.Range(minVal, cashInWallet);
				plr.addMoney(amt);
				cashInWallet -= amt;
				Debug.Log("SuccessRoll : " + successRoll + "\tMaxcash " + cashInWallet + 
					"\tminvalue " + minVal + "\tamountgained : " + amt);
			}
			else {
				Debug.Log("Success roll " + successRoll + "\tsuccess chance : " + (successChance - (plr.stenchRadius * successChance / maxStenchValue)));
			}
	}
}
