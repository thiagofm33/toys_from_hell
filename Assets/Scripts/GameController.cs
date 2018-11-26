using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

  public GameObject[] toys;

  private AudioSource toyExplosion;

  private static GameController instance;

  public static bool gameOver;
  public static bool canReset;

  public Text timeText;

  private float time;

  public GameObject gameOverScreen;
  public GameObject tryAgainText;

  void Awake(){
    time = 0;
    gameOver = false;
    canReset = false;
    instance = this;
    toyExplosion = GameObject.Find("ToyExplosion").GetComponent<AudioSource>();
  }

	// Use this for initialization
	IEnumerator Start() {
    float seconds = 2.7f;

    while(!gameOver){
      SpawnToy();
      yield return new WaitForSeconds(seconds);
      if(seconds > 0.5f)
        seconds -= 0.1f;
    }
	}

  void Update(){
    if(gameOver){
      if(Input.anyKeyDown && canReset)
        SceneManager.LoadScene("Main");
      return;
    }

    time += Time.deltaTime;

    int mins = (int)time / 60;
    int secs = (int)time % 60;

    timeText.text = string.Format("{0:00}:{1:00}", mins, secs);
  }

  private void SpawnToy() {
    GameObject toy = toys[Random.Range(0,toys.Length)];

    Quaternion rotation = Quaternion.AngleAxis(Random.Range(0f, 90f), Vector3.up);

    Vector3 pos = rotation * (Vector3.forward * 9);
    pos.y = 1;

    Instantiate(toy, pos, rotation * Quaternion.AngleAxis(180, Vector3.up));
  }

  public static void PlayToyExplosion(){
    instance.toyExplosion.Play();
  }

  public static void YouDied(){
    gameOver = true;
    instance.gameOverScreen.SetActive(true);
    instance.StartCoroutine(instance.Reset());
  }

  IEnumerator Reset(){
    yield return new WaitForSeconds(3);
    GameController.canReset = true;
    tryAgainText.SetActive(true);
  }

}