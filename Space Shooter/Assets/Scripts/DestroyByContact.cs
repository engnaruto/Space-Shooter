﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;
	public int scoreValue;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject!=null){
			gameController = gameControllerObject.GetComponent<GameController>();
			if(gameController ==null){
				Debug.Log("CAnnot find GameController screipt");

			}
		}

	}

	void OnTriggerEnter(Collider other) {
	//	Debug.Log (other.name);
		if(other.tag!="Boundary"){
			Instantiate(explosion,transform.position,transform.rotation);
			if(other.tag=="Player"){
				Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
				gameController.GameOver();
			}
			Destroy(other.gameObject);
			Destroy (gameObject);
			gameController.AddScore(scoreValue);
		}
	}
}
