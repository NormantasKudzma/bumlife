using UnityEngine;
using System.Collections;

public class BottleShop : MonoBehaviour {
	
	public int BottlePrice;

	void OnCollisionEnter (Collision coll) {
	//void OnTriggerEnter (Collider coll){
		Player player = coll.gameObject.GetComponent<Player>();
		if (player != null){
			int amountGained = player.bottleCount * this.BottlePrice;
			if (amountGained > 0){
				player.addMoney (amountGained);
				player.bottleCount = 0;
				TextGen.MakeText("+" + amountGained + "$", Color.green, player.transform.position);
				TextGen.MakeText("Recycling!", Color.green, transform.position);
			}
		}
	}
}
