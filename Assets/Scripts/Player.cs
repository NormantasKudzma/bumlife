using UnityEngine;

public class Player : MonoBehaviour {
	private int maxBottleCount = 10;
	private int maxThirst = 100;
	
	public int bottleCount {
		get {
			return bottleCount;
		}
		set {
			if (value > maxBottleCount){
				value = maxBottleCount;
			}
		}
	}
	
	public float stenchRadius {
		get; set;
	}
	
	public int thirst {
		get; set;
	}
	
	public int moneyCount {
		get; set;
	}
	
	public void addStenchRadius(int val){
		stenchRadius += value;
	}
	
	public void addThirst(int val){
		thirst += val;
	}
	
	public void increaseBottleCount(){
		bottleCount++;
	}
	
	public void addMoney(int val){
		moneyCount += val;
	}
}
