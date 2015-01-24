using UnityEngine;
using System.Collections;

public class WasteContainer : MonoBehaviour {
	
	public float MaxStenchAdd;
	public int ShowerPrice;
	public int MaxMoneyFound;
	int selection;



	void OnCollisionEnter (Collision coll) {
		Player player = coll.gameObject.GetComponent<Player>();
		if (player.bottleCount != player.MaxBottleCount) {
			selection = Random.Range (1, 3);
			if (selection == 1 )player.bottleCount += Random.Range(1, player.MaxBottleCount-player.bottleCount);
		}
		else {
			selection = Random.Range (2, 3);
		}
		if (selection == 2){
			player.addStenchRadius (Random.Range(5, this.MaxStenchAdd));
		}
		if (selection == 3){
				player.addMoney (Random.Range(10,this.MaxMoneyFound));
		}
	}
}
