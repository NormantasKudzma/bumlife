using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

		public float startX = 6;
		public float maxY = 4.5f;
		public int pedestrianMax = 10;
		public GameObject pedestrian;
		public GameObject police;
		private float pedestrianCoolDown = 0;
		public float maxCoolDown;
		private float policeCoolDown = 0f;
	
		// Update is called once per frame
		void Update ()
		{
	   
		}

		void SpawnPedestrian ()
		{
				int movementDirection = (Random.Range (0, 2) == 0) ? 1 : -1;
				var pedestrainObject = Instantiate (
				pedestrian,
				new Vector3 (startX * movementDirection, Random.Range (-maxY, maxY), 0),
				Quaternion.identity) as GameObject;
				pedestrainObject.GetComponent<Pedestrian> ().movementDirection = -movementDirection;

			
		}

		void SpawnPolice ()
		{
				int movementDirection = (Random.Range (0, 2) == 0) ? 1 : -1;
				var pedestrainObject = Instantiate (
			police,
			new Vector3 (startX * movementDirection, Random.Range (-maxY, maxY), 0),
			Quaternion.identity) as GameObject;
				pedestrainObject.GetComponent<AIPolice> ().movementDirection = -movementDirection;
		
		
		}
		void FixedUpdate ()
		{
				if (pedestrianCoolDown > 0) {
						pedestrianCoolDown -= Time.deltaTime;
				} else {
						SpawnPedestrian ();
						pedestrianCoolDown = maxCoolDown;
				}
				if (policeCoolDown > 0) {
						policeCoolDown -= Time.deltaTime;
				} else {
						SpawnPolice ();
						policeCoolDown = 3;
				}

		}
}
