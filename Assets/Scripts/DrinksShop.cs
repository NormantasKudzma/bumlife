using UnityEngine;
using System.Collections;

public class DrinksShop : MonoBehaviour {
	public int DrinkPrice;
	public int ThirstRegen;

	void OnCollisionEnter (Collision coll) {
		Player player = coll.gameObject.GetComponent<Player>();
		//coll.gameObject.GetComponent <Player>();
		player.addMoney (-this.DrinkPrice);
		player.addThirst (-this.ThirstRegen);
	}
}
