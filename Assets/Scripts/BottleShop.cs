using UnityEngine;
using System.Collections;

public class BottleShop : MonoBehaviour {
	
	public int BottlePrice;

	void OnCollisionEnter (Collision coll) {
		Player player = coll.gameObject.GetComponent<Player>();
		//coll.gameObject.GetComponent <Player>();
		player.addMoney (player.bottleCount * this.BottlePrice);
		player.bottleCount = 0;
	}
}
