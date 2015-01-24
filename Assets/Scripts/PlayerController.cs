using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Animator animator;

	private Vector3 movementDestination;
	public bool isMoving = false;
	public float movementSpeed = 6.5f;
	
	public Pedestrian movementTarget;
	public bool isFollowing = false;
	public float followStopRange = 2.2f;
	public float neutralStopRange = 0.35f;
	
	void Start(){
		animator = GetComponent<Animator>();
	}
	
	void Update(){
		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayhit;
			bool hit = Physics.Raycast(ray, out rayhit);
			isMoving = true;
			isFollowing = false;
			animator.SetBool("isMoving", true);
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
		float distance = Vector3.Distance(transform.position, movementDestination);
		if (isFollowing && distance <= followStopRange){
			stopMoving();
			animator.Play("Begging");
			return;
		}
		if (distance <= neutralStopRange){
			stopMoving();
		}
	}
	
	void rotatePlayer(Vector3 point){
		transform.LookAt(point, new Vector3(0, 0, -1));
	}
	
	void OnTriggerEnter(Collider col){
		stopMoving();
	}
	/*
	void OnCollisionEnter(Collision col){
		stopMoving();
	}*/
	
	public void stopMoving(){
		animator.SetBool("isMoving", false);
		movementTarget = null;
		isMoving = false;
		isFollowing = false;
	}
	
	public void startFollowing(Pedestrian target){
		movementTarget = target;
		isFollowing = true;
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
