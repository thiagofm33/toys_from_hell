using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

  private static float speed = 9;

  Transform _transform;

  public GameObject toyExplosionParticles;

  void Start() {
    _transform = transform;
    GameObject.Destroy(gameObject, 1.5f);
  }

	void Update() {
    _transform.position = Vector3.MoveTowards(_transform.position, _transform.position + _transform.forward, speed * Time.deltaTime);
	}

  void OnCollisionEnter(Collision other){
    if(other.gameObject.tag == "Toy"){
      GameObject particles = Instantiate(toyExplosionParticles, other.transform.position, Quaternion.identity);
      GameObject.Destroy(particles, 1.5f);
      GameObject.Destroy(other.gameObject);
      GameController.PlayToyExplosion();
    }
  }

}
