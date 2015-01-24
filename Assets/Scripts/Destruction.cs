using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour
{
		void OnTriggerExit (Collider collider)
		{
				Destroy (collider.gameObject);
		}

}
