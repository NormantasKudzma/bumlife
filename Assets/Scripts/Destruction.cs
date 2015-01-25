using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour
{
		void OnTriggerEnter (Collider collider)
		{
			string tag = collider.tag;
			if (tag != "Stench" || tag != "Player"){
				Destroy (collider.gameObject);
			}
		}

}
















































































