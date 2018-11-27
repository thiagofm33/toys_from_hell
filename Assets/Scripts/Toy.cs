using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour {

  private static Transform player;

  private float speed;

  private static float[] possibleSpeeds = new float[]{ 1.2f, 2.4f, 3.6f, 4.8f, 6.0f };

  void Awake() {
    player = GameObject.FindWithTag("Player").transform;
    speed = possibleSpeeds[Random.Range(0, possibleSpeeds.Length)];
  }

	// Update is called once per frame
	void Update() {
    if(player.gameObject.activeSelf)
      transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	}
}
