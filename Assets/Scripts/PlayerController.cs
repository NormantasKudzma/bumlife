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
			bool hit = false;
			RaycastHit [] rayhit = Physics.RaycastAll(ray);
			Pedestrian p = null;
			isMoving = true;
			animator.SetBool("isMoving", true);
			foreach (RaycastHit i in rayhit){
				p = i.collider.GetComponent<Pedestrian>();
				if (p != null){
					hit = true;
					break;
				}
			}
			if (hit){
				if (p != null){
					startFollowing(p);
				}
				/*else {
					isFollowing = false;
					setMovementDestination(ray.origin);
				}*/
			}
			else {
				isFollowing = false;
				setMovementDestination(ray.origin);
			}
		}
	}
	
	void FixedUpdate(){
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
			movementTarget.getBegged(transform.position, GetComponent<Player>());
			animator.Play("Begging");
			stopMoving();
			return;
		}
		if (distance <= neutralStopRange){
			stopMoving();
		}
	}
	
	void rotatePlayer(Vector3 point){
		transform.LookAt(point, new Vector3(0, 0, -1));
	}
	
	void OnCollisionStay(Collision col){
		rigidbody.velocity = Vector3.zero;
		stopMoving();
	}
	
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
