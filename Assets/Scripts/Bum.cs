using UnityEngine;
using System.Collections;

public class Bum : MonoBehaviour {
	public int MaxBottleCount = 10;

	protected int _bottleCount = 0;
	public int bottleCount {
		get {
			return _bottleCount;
		}
		set {
			if (value > MaxBottleCount){
				_bottleCount = MaxBottleCount;
			} else {
				_bottleCount = value;
			}
		}
	}

	public float stenchRadius {
		get; set;
	} 

	public virtual void addStenchRadius(float val){
		this.stenchRadius = (this.stenchRadius + val > 0) ? this.stenchRadius + val : 0;
	}

	public virtual void increaseBottleCount(){
		bottleCount++;
	}
}
