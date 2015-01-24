using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour
{

		public int AmountOfStench = 10;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		private void OnCollisionEnter (Collision collision)
		{
				Bum bum = collision.gameObject.GetComponent<Bum> ();
				bum.increaseBottleCount ();
				bum.addStenchRadius (this.AmountOfStench);
				Destroy (GetComponent<Bottle> ());
		}
}
