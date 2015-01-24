using UnityEngine;
using System.Collections;

public class Shower : MonoBehaviour {
	public float ShowerStrength = 1f;
	public int ShowerPrice = 10;


	void OnCollisionEnter (Collision coll) {
		Player player = coll.gameObject.GetComponent<Player>();
		if (player.moneyCount >= this.ShowerPrice){
			player.addStenchRadius (-this.ShowerStrength);
			player.addMoney (-this.ShowerPrice);
		}

	}
}
