using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MagnetSensor {

  public GameObject shot;

  public Transform shotSpawn;
	
//  private float shotInterval = 0.27f;

	void Update() {
    if(Input.anyKeyDown) Shoot();
//    shotInterval += Time.deltaTime;
	}

  void OnCardboardTrigger(){
    Shoot();
  }

  private void Shoot(){
//    if(shotInterval >= 1f){
      Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
//      shotInterval = 0;
//    }
  }

  void OnCollisionEnter(Collision other){
    gameObject.SetActive(false);
    GameController.YouDied();
  }

}
