using UnityEngine;

public class Player : Bum {
	private int maxThirst = 100;
	private float stenchUpdateTimeDelta = 2.0f;
	private float stenchUpdateValueDelta = 0.25f;
	private float nextStenchUpdate;
	private float thirstUpdateTimeDelta = 3.5f;	
	private int thirstUpdateValueDelta = 2;
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
