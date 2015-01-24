using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour {

	public int AmountOfStench = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Bum" || collision.gameObject.tag == "Player") {
			Bum bum = collision.gameObject.GetComponent<Bum>();
			bum.increaseBottleCount();
			bum.addStenchRadius(this.AmountOfStench);
			Destroy (this.gameObject);
		}
	}
}
