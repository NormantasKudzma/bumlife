using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Vector3 movementDirection;
	private float maxSpeed = 6.5f;
	
	void Update(){
		for (int i = 0; i < Input.touchCount; i++){
			Touch t = Input.GetTouch(i);
		}
	}
}
