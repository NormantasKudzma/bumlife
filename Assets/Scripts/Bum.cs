using UnityEngine;
using System.Collections;

public class Bum : MonoBehaviour {
	protected int maxBottleCount = 10;

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

	public virtual void addStenchRadius(float val){
		this.stenchRadius += val;
	}

	public virtual void increaseBottleCount(){
		bottleCount++;
	}
}
