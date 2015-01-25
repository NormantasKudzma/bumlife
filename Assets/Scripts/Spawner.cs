using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

		public float startX = 6;
		public float maxY = 4.5f;
		public int pedestrianMax = 10;
		public GameObject pedestrian;
		public GameObject police;
		public GameObject bum;
		private float pedestrianCoolDown = 0;
		private float maxCoolDownPedestrian = 5;
		private float maxCoolDownPolice = 10;
		private float maxCoolDownBum = 7;
		private float policeCoolDown = 1.5f;
		private float bumCoolDown = 1f;
	
		// Update is called once per frame
		void Update ()
		{
	   
		}

		void SpawnPedestrian ()
		{
				int number = Random.Range (1, 3);
				for (int i = 0; i< number; i++) {
						int movementDirection = (Random.Range (0, 2) == 0) ? 1 : -1;
						var pedestrainObject = Instantiate (
							pedestrian,
							new Vector3 (startX * movementDirection, Random.Range (-maxY, maxY), 0),
							Quaternion.identity) as GameObject;
						pedestrainObject.GetComponent<Pedestrian> ().movementDirection = -movementDirection;
				}
			
		}

		void SpawnPolice ()
		{
				int number = Random.Range (1, 3);
				for (int i = 0; i< number; i++) {
						int movementDirection = (Random.Range (0, 2) == 0) ? 1 : -1;
						var pedestrainObject = Instantiate (
							police,
							new Vector3 (startX * movementDirection, Random.Range (-maxY, maxY), 0),
							Quaternion.identity) as GameObject;
						pedestrainObject.GetComponent<AIPolice> ().movementDirection = -movementDirection;
				}
		
		}

		void SpawnBum ()
		{
				int number = Random.Range (1, 3);
				for (int i = 0; i< number; i++) {
						int movementDirection = (Random.Range (0, 2) == 0) ? 1 : -1;
						var pedestrainObject = Instantiate (
							bum,
							new Vector3 (startX * movementDirection, Random.Range (-maxY, maxY), 0),
							Quaternion.identity) as GameObject;
						pedestrainObject.GetComponent<AIBum> ().movementDirection = -movementDirection;
				}
		
		}
		void FixedUpdate ()
		{
				if (pedestrianCoolDown > 0) {
						pedestrianCoolDown -= Time.deltaTime;
				} else {
						SpawnPedestrian ();
						pedestrianCoolDown = maxCoolDownPedestrian;
				}
				if (policeCoolDown > 0) {
						policeCoolDown -= Time.deltaTime;
				} else {
						
						SpawnPolice ();
						policeCoolDown = maxCoolDownPolice;
				}
				if (bumCoolDown > 0) {
						bumCoolDown -= Time.deltaTime;
				} else {
						SpawnBum ();
						bumCoolDown = maxCoolDownBum;
				}
		}
}
