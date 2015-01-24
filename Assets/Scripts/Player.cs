using UnityEngine;

public class Player : Bum {
	private int maxThirst = 100;
	public float stenchUpdateTimeDelta = 2.0f;
	public float stenchUpdateValueDelta = 0.25f;
	private float nextStenchUpdate;
	public float thirstUpdateTimeDelta = 3.5f;	
	public int thirstUpdateValueDelta = 2;
	private float nextThirstUpdate;	

	public int thirst {
		get; set;
	}
	
	public int moneyCount {
		get; set;
	}

	public void addThirst(int val){
		thirst += val;
	}
	
	public void addMoney(int val){
		moneyCount += val;
	}
	
	void Update(){
		updateStenchRadius();
		updateThirst();
	}
	
	void updateStenchRadius(){
		if (Time.time > nextStenchUpdate){
			nextStenchUpdate += stenchUpdateTimeDelta;
			addStenchRadius(stenchUpdateValueDelta);
		}
	}
	
	void updateThirst(){
		if (Time.time > nextThirstUpdate){
			nextThirstUpdate += thirstUpdateTimeDelta;
			addThirst(thirstUpdateValueDelta);
			if (thirst > maxThirst){
				// Game over, you're sober
				Debug.Log("Game over - you're now sober.");
			}
		}
	}
}
