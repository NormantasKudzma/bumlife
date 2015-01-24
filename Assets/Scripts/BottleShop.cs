using UnityEngine;
using System.Collections;

public class BottleShop : MonoBehaviour {
	
	public int BottlePrice;

	//void OnCollisionEnter (Collision coll) {
	void OnTriggerEnter (Collider coll){
		Player player = coll.gameObject.GetComponent<Player>();
		if (player != null){
			player.addMoney (player.bottleCount * this.BottlePrice);
			player.bottleCount = 0;
		}
	}
}
