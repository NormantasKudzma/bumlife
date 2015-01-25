using UnityEngine;
using System.Collections;

public class Bottle : MonoBehaviour
{
		private AudioClip [] sounds = new AudioClip[3];

		public float Duration = 6;
		public float AmountOfStench = 0.1f;
		// Use this for initialization
		void Start (){
			for (int i = 0; i < 3; i++){
				sounds[i] = Resources.Load<AudioClip>("Audio/BottlePickup" + (i + 1));
			}
		}
	
		// Update is called once per frame
		void Update ()
		{
			if(this.Duration > 0) {
				this.Duration -= Time.deltaTime;
			} else {
				Destroy(this.gameObject);
			}
		}

		void OnTriggerEnter (Collider col)
		{
				string tag = col.gameObject.tag;
				if ((tag == "Bum" && !col.GetComponent<AIBum> ().isCaught) || tag == "Player") {
						Bum bum = col.gameObject.GetComponent<Bum> ();
						bum.increaseBottleCount ();
						bum.addStenchRadius (this.AmountOfStench);
						audio.clip = sounds[Random.Range(0, sounds.Length)];
						audio.Play();
						Destroy (this.gameObject, audio.clip.length);
				}
		}
}
