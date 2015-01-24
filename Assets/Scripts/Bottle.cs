using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour
{

		public float AmountOfStench = 0.5f;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerEnter (Collider col)
		{
				string tag = col.gameObject.tag;
				if (tag == "Bum" || tag == "Player") {
						Bum bum = col.gameObject.GetComponent<Bum> ();
						bum.increaseBottleCount ();
						bum.addStenchRadius (this.AmountOfStench);
						Destroy (this.gameObject);
				}
		}
}
