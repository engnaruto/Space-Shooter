using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text gameOverText;
	public Text restartText;
	private bool gameOver;
	private bool restart;
	private int score;

	
	void Start () {
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		gameOver = false;
		restart = false; 
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
	}
	
	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	void Update(){
		if(restart && Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	IEnumerator SpawnWaves(){
		yield return new  WaitForSeconds(startWait);
		while (!gameOver) {
			for (int i = 0; i <hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new  WaitForSeconds (spawnWait);
			}
			yield return new  WaitForSeconds (waveWait);
		}
		restartText.text = "Press R for Restart";
		restart = true;

	}

	public void GameOver(){
		gameOverText.text = "GameOver";
		gameOver = true;
	}
}
