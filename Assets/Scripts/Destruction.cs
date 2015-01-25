using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour
{
		void OnTriggerEnter (Collider collider)
		{
				if (collider.tag != "Stench") {
						Destroy (collider.gameObject);
				}
			
		}

}
















































































