using UnityEngine;
using System.Collections;

public class DrinksShop : MonoBehaviour {
	public int DrinkPrice = 5;
	public int ThirstRegen = 10;

	private AudioClip[] barSounds = new AudioClip[3];
	void Start(){
		for (int i = 0; i < 3; i++){
			barSounds[i] = Resources.Load<AudioClip>("Audio/BumInBar" + (i + 1));
		}
	}

	//void OnCollisionEnter (Collision coll) {
	void OnTriggerEnter (Collider coll) {
		Player player = coll.gameObject.GetComponent<Player>();
		//coll.gameObject.GetComponent <Player>();
		if (player != null && player.moneyCount >=this.DrinkPrice){
			audio.clip = this.barSounds[Random.Range(0, this.barSounds.Length)];
			audio.Play();
			player.addMoney (-this.DrinkPrice);
			player.addThirst (-this.ThirstRegen);
		}

	}
}
