using UnityEngine;

public class Player : Bum {
	private int maxThirst = 100;

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
}
