using UnityEngine;

public class Player : MonoBehaviour {
	private int maxBottleCount = 10;
	
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
	
	public float stentchRadius {
		get; set;
	}
	
	public int moneyCount {
		get; set;
	}
	
	public void increaseBottleCount(){
		bottleCount++;
	}
	
	public void addMoney(int val){
		moneyCount += val;
	}
}
