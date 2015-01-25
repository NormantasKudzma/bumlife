using UnityEngine;
using System.Collections;

public class SightRadius : MonoBehaviour
{

		private GameObject target = null;
		private Vector3 originalVelocity;
		private GameObject parent;
		private AIBum scriptAI;
		void Start ()
		{
				originalVelocity = transform.parent.rigidbody.velocity;
				
		}

		void FixedUpdate ()
		{
				
		}

		void OnTriggerEnter (Collider other)
		{
				bool isCaught = transform.parent.GetComponent<AIBum> ().isCaught;
				if (!isCaught && (other.tag == "Pedestrian" && !other.GetComponent<Pedestrian> ().wasBegged) || (other.tag == "Bottle")) {
						if (target == null) {
								target = other.gameObject;
						}
						transform.parent.rigidbody.velocity = new Vector3 ();
				}  
		}
	
		void OnTriggerStay (Collider other)
		{
				if (!transform.parent.GetComponent<AIBum> ().isCaught) {
						string tag = other.tag;
						if (target != null && target.tag == "Bottle")
								Debug.Log (target == other.gameObject);
						if (target != null && target.Equals (other.gameObject) && (tag == "Bottle" || tag == "Pedestrian" && !other.GetComponent<Pedestrian> ().wasBegged)) {
								transform.parent.transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * transform.parent.GetComponent<AIBum> ().movementSpeed);
						} else if (target == null && (tag == "Bottle" || (tag == "Pedestrian" && !other.GetComponent<Pedestrian> ().wasBegged))) {
								target = other.gameObject;
								transform.parent.rigidbody.velocity = new Vector3 ();
						} else if (tag == "Pedestrian" && !transform.parent.GetComponent<AIBum> ().IsBegging && !other.GetComponent<Pedestrian> ().wasBegged) {
								target = null;
						} else if (!transform.parent.GetComponent<AIBum> ().IsBegging) {
						
								transform.parent.rigidbody.velocity = originalVelocity; 
						}

				}
		}
	
		void OnTriggerExit (Collider other)
		{
				if (!transform.parent.GetComponent<AIBum> ().isCaught) {
						if (target != null && target.Equals (other.gameObject)) {
								target = null;
						
								transform.parent.rigidbody.velocity = originalVelocity;
						} else if (target == null) {
								transform.parent.rigidbody.velocity = originalVelocity;
						}
				}
		}
}
