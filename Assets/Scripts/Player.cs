using UnityEngine;

public class Player : Bum {
	private int maxThirst = 100;
	
	public int thirst {
		get; set;
	}
	
	public int moneyCount {
		get; set;
	}
	
	public override void addStenchRadius(int val){
		this.stenchRadius += val;
	}
//	
	public void addThirst(int val){
		thirst += val;
	}
	
	public override void increaseBottleCount(){
		bottleCount++;
	}
	
	public void addMoney(int val){
		moneyCount += val;
	}
}
