using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour {

  private static Transform player;

  private float speed;

  void Awake() {
    player = GameObject.FindWithTag("Player").transform;
    speed = (Random.value + 0.3f) * 1.8f;
  }

	// Update is called once per frame
	void Update() {
    if(player.gameObject.activeSelf)
      transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	}
}
