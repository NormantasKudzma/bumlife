using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Vector3 movementDestination;
	private Vector3 moveStartPos;
	private float moveStartTime;
	private float moveDistance;
	private bool isMoving = false;
	private float movementSpeed = 6.5f;
	
	void Update(){
		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			movementDestination = ray.origin;
			movementDestination.z = transform.position.z;
			moveStartTime = Time.time;
			moveStartPos = transform.position;
			moveDistance = Vector3.Distance(moveStartPos, movementDestination);
			isMoving = true;
		}
		if (isMoving){
			movePlayer();
		}
	}
	
	void movePlayer(){
		float distCovered = (Time.time - moveStartTime) * movementSpeed;
		float fracJourney = distCovered / moveDistance;
		transform.position = Vector3.Lerp(moveStartPos, movementDestination, fracJourney);
		
		if (fracJourney >= 1){
			stopMoving();
		}
	}
	
	void OnCollisionEnter(Collision col){
		stopMoving();
	}
	
	public void stopMoving(){
		isMoving = false;
	}
}
