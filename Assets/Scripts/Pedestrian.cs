using UnityEngine;
using System.Collections;

public class Pedestrian : AIMovement {
   bool clicked = false;
   public float chance = 0.5f;
   void Update() {
   }

   public void OnCollisionEnter(Collision collision) {
      if (collision.collider.tag == "Player") {
         //var bum = collision.collider.getcomponent<bum>();
         //bool givemoney = random.range(0f, 1f) < chance * (1 / (bum.stenchradius + 1));
      }
   }

   public void OnMouseUp() {
      clicked = true;
      Debug.Log("asdasd");
   }



}
