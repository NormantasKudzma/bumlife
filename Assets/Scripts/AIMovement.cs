using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

		public int movementDirection;
		public float movementSpeed;
		protected Animator animator;
		
		// Use this for initialization
		protected void Start ()
		{
			animator = GetComponent<Animator>();
			if (animator != null){
				animator.SetBool("isMoving", true);
			}
				//rotation = Random.Range(-50f, 50f);
				rigidbody.velocity = new Vector3 (1, 0, 0) * movementDirection * movementSpeed;
				transform.LookAt(rigidbody.velocity, new Vector3(0, 0, -1));
		}

}
