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

<<<<<<< HEAD
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Bum" || collision.gameObject.tag == "Player") {
			Bum bum = collision.gameObject.GetComponent<Bum>();
=======
	void OnTriggerEnter(Collider col){
		string tag = col.gameObject.tag;
		if (tag == "Bum" || tag == "Player") {
			Bum bum = col.gameObject.GetComponent<Bum>();
>>>>>>> origin/nkbranch
			bum.increaseBottleCount();
			bum.addStenchRadius(this.AmountOfStench);
			Destroy (this.gameObject);
		}
	}
}
