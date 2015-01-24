using UnityEngine;
using System.Collections;

public class WasteContainer : MonoBehaviour {
	
	public float MaxStenchAdd;
	public int ShowerPrice;
	public int MaxMoneyFound;
	int selection;



	void OnCollisionEnter (Collision coll) {
		Player player = coll.gameObject.GetComponent<Player>();
		if (player.bottleCount != maxBottleCount) {
			selection = Random.Range (1.0f, 3.0f);
			if (selection == 1 )player.bottleCount += Random.Range(1.0f, player.maxBottleCount-player.bottleCount);
		}
		else {
			selection = Random.Range (2.0f, 3.0f);
		}
		if (selection == 2){
			player.addStenchRadius (Random.Range(5.0f, this.MaxStenchAdd));
		}
		if (selection == 3){
				player.addMoney (Random.Range(10.0f,this.MaxMoneyFound));
		}
	}
}
