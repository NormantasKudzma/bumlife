using UnityEngine;

public class Player : Bum {
	private int maxThirst = 100;
	public float stenchUpdateTimeDelta = 2.0f;
	public float stenchUpdateValueDelta = 0.25f;
	private float nextStenchUpdate;
	public float thirstUpdateTimeDelta = 3.5f;	
	public int thirstUpdateValueDelta = 2;
	private float nextThirstUpdate;
	
	public GUIText moneyText;
	public GUITexture thirstBar;
	float barHeight;
	
	void Start(){
		barHeight = thirstBar.transform.localScale.y;
	}

	public int thirst {
		get; set;
	}
	
	public int moneyCount {
		get; set;
	}

	public void addThirst(int val){
		thirst += val;
		if (thirst < 0){
			thirst = 0;
		}
		
		Debug.Log("Thirst is " + thirst);
		float percent = 1.0f - (1.0f * thirst / maxThirst);
		Vector3 old = thirstBar.transform.localScale;
		thirstBar.transform.localScale = new Vector3(old.x, barHeight * percent, old.z);
	}
	
	public void addMoney(int val){
		moneyCount += val;
		updateMoneyText();
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
			nextThirstUpdate = Time.time + thirstUpdateTimeDelta;
			addThirst(thirstUpdateValueDelta);
			if (thirst > maxThirst){
				// Game over, you're sober
				Debug.Log("Game over - you're now sober.");
			}
		}
	}
	
	void updateMoneyText(){
		moneyText.text = moneyCount.ToString("D6") + "$";
	}
}
