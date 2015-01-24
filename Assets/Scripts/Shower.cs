using UnityEngine;
using System.Collections;

public class Shower : MonoBehaviour {
	public float ShowerStrength;
	public int ShowerPrice;


	void OnCollisionEnter (Collision coll) {
		Player player = coll.gameObject.GetComponent<Player>();
		//coll.gameObject.GetComponent <Player>();
		player.addStenchRadius (-this.ShowerStrength);
		player.addMoney (-this.ShowerPrice);

	}
}
