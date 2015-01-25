using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour
{

		public int movementDirection;
		public float movementSpeed;
		// Use this for initialization
		protected void Start ()
		{
				//rotation = Random.Range(-50f, 50f);
				rigidbody.velocity = new Vector3 (1, 0, 0) * movementDirection * movementSpeed;
		}

}
