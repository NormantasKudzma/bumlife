using UnityEngine;
using System.Collections;

public class bottle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter(Collision collision){
		Bum bum = collision.gameObject.GetComponent<Bum>();
		bum.increaseBottleCount ();
	}
}
