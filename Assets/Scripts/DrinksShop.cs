using UnityEngine;
using System.Collections;

public class DrinksShop : MonoBehaviour {
	public int DrinkPrice = 5;
	public int ThirstRegen = 10;

	void OnCollisionEnter (Collision coll) {
		Player player = coll.gameObject.GetComponent<Player>();
		//coll.gameObject.GetComponent <Player>();
		if (player.moneyCount >=this.DrinkPrice){
			player.addMoney (-this.DrinkPrice);
			player.addThirst (-this.ThirstRegen);
		}

	}
}
