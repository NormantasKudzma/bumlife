using UnityEngine;
using System.Collections;

public class BottleShop : MonoBehaviour {
	
	public int BottlePrice;
	private AudioClip [] sounds = new AudioClip[3];

	void Start(){
		for (int i = 0; i < 3; i++){
			sounds[i] = Resources.Load<AudioClip>("Audio/Cash" + (i + 1));
		}
	}
	//void OnCollisionEnter (Collision coll) {
	void OnTriggerEnter (Collider coll){
		Player player = coll.gameObject.GetComponent<Player>();
		if (player != null && player.bottleCount > 0){
			audio.clip = this.sounds[Random.Range(0,this.sounds.Length)];
			audio.Play();
			player.addMoney (player.bottleCount * this.BottlePrice);
			player.bottleCount = 0;
		} 
	}
}
