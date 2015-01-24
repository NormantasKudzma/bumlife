using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

   public float startX = 6;
   public float maxY = 4.5f;
   public int pedestrianMax = 10;
   public GameObject pedestrian;
	// Use this for initialization
	void Start () {
      Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

   void Spawn() {
      for (int i = 0; i < pedestrianMax; i++) {
         int movementDirection = (Random.Range(0, 2) == 0) ? 1 : -1;
         var pedestrainObject = Instantiate(
            pedestrian,
            new Vector3(startX * movementDirection, Random.Range(-maxY, maxY), 0),
            Quaternion.identity) as GameObject;
         pedestrainObject.GetComponent<Pedestrian>().movementDirection = -movementDirection;
      }
   }
}
