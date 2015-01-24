using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

		public float startX = 6;
		public float maxY = 4.5f;
		public int pedestrianMax = 10;
		public GameObject pedestrian;
		private float coolDown = 0;
		public float maxCoolDown;
		
	
		// Update is called once per frame
		void Update ()
		{
	   
		}

		void Spawn ()
		{
				int movementDirection = (Random.Range (0, 2) == 0) ? 1 : -1;
				var pedestrainObject = Instantiate (
				pedestrian,
				new Vector3 (startX * movementDirection, Random.Range (-maxY, maxY), 0),
				Quaternion.identity) as GameObject;
				pedestrainObject.GetComponent<Pedestrian> ().movementDirection = -movementDirection;

			
		}

		void FixedUpdate ()
		{
				if (coolDown > 0) {
						coolDown -= Time.deltaTime;
				} else {
						Spawn ();
						coolDown = maxCoolDown;
				}

		}
}
