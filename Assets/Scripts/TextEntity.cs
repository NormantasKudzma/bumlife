using UnityEngine;

public class TextEntity : MonoBehaviour {
	public const float LIFETIME = 1.75f;
	float created;
	public bool moving = true;
	
	void Start(){
		created = Time.time;
	}
	
	void FixedUpdate(){	
		if (moving){
			Vector3 cur = transform.position;
			cur.y += 0.02f;
			transform.position = cur;
		}
		if (Time.time - created > LIFETIME){
			Destroy(this.gameObject);
		}
	}

}
