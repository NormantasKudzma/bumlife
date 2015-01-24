using UnityEngine;
using System.Collections;

public abstract class Bum : MonoBehaviour {
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

	public abstract void addStenchRadius(int val);

	public abstract void increaseBottleCount();
}
