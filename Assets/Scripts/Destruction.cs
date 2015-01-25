using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour
{
		void OnTriggerEnter (Collider collider)
		{
				if (collider.tag != "Stench") {
			if (tag != "Stench" && tag != "Player"){
						Destroy (collider.gameObject);
			}
				}
			
		}

}
















































































