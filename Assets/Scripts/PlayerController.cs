using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Vector3 movementDestination;
	private Vector3 moveStartPos;
	private float moveStartTime;
	private float moveDistance;
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
			else {
				movePlayer();
			}
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
		float step = Time.deltaTime * movementSpeed;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
	}
	
	void setMovementDestination(Vector3 pos){
		movementDestination = pos;
		movementDestination.z = transform.position.z;
		moveStartTime = Time.time;
		moveStartPos = transform.position;
		moveDistance = Vector3.Distance(moveStartPos, movementDestination);
		rotatePlayer(movementDestination);
	}
}
