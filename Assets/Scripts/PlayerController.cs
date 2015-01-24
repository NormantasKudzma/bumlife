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
			RaycastHit rayhit;
			bool hit = Physics.Raycast(ray, out rayhit);
			isMoving = true;
			isFollowing = false;
			if (hit){
				Pedestrian p = rayhit.collider.GetComponent<Pedestrian>();
				if (p != null){
					startFollowing(p);
				}
				else {
					setMovementDestination(ray.origin);
				}
			}
			else {
				setMovementDestination(ray.origin);
			}
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
		if (Vector3.Distance(transform.position, movementDestination) <= 0.1){
			stopMoving();
		}
	}
	
	void rotatePlayer(Vector3 point){
		Vector3 dir = point - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
		if (target != null){
			setMovementDestination(target.transform.position);
		}
		else {
			movementTarget = null;
			stopMoving();
		}
	}
	
	void setMovementDestination(Vector3 pos){
		movementDestination = pos;
		movementDestination.z = transform.position.z;
		rotatePlayer(movementDestination);
	}
}
