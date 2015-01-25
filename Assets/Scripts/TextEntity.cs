using UnityEngine;

public class TextEntity : MonoBehaviour {
	public const float LIFETIME = 2.55f;
	float created;
	public bool moving = true;
	
	void Start(){
		created = Time.time;
	}
	
	void FixedUpdate(){	
		if (moving){
			Vector3 cur = transform.position;
			cur.y += 0.015f;
			transform.position = cur;
		}
		if (Time.time - created > LIFETIME){
			Destroy(this.gameObject);
		}
	}

}
