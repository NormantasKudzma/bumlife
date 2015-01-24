using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Vector3 movementDestination;
	public bool isMoving = false;
	private float movementSpeed = 6.5f;
	
	public Pedestrian movementTarget;
	public bool isFollowing = false;
	
	void Update(){
		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			setMovementDestination(ray.origin);
			isMoving = true;
			isFollowing = false;
		}
		if (isMoving){
			if (isFollowing){
				followTarget(movementTarget);
			}
			movePlayer();
		}
	}
	
	void movePlayer(){
		float step = Time.deltaTime * movementSpeed;
		transform.position = Vector3.MoveTowards(transform.position, movementDestination, step);
	}
	
	void rotatePlayer(Vector3 point){
		transform.LookAt(point, transform.up);
	}
	
	void OnCollisionEnter(Collision col){
		stopMoving();
	}
	
	public void stopMoving(){
		isMoving = false;
		isFollowing = false;
	}
	
	public void startFollowing(Pedestrian target){
		movementTarget = target;
		isFollowing = true;
		isMoving = true;
	}
	
	void followTarget(Pedestrian target){
		setMovementDestination(target.transform.position);
	}
	
	void setMovementDestination(Vector3 pos){
		movementDestination = pos;
		movementDestination.z = transform.position.z;
		rotatePlayer(movementDestination);
	}
}
