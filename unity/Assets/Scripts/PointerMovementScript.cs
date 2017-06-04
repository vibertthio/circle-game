﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class PointerMovementScript : MonoBehaviour {

//	public GameObject pointer;
//	public GameObject centerP;
//	public Rigidbody ball;
	public GameTempoScript GameTempoScript;
	public GameObject innerPointer;
	public GameObject outerPointer;
	public GameObject outerTurret;
	public GameObject innerTurret;
	public GameObject FirePoint;
	float timer = 0f;
	private int innerPointerCounter = 1;
	private int outerPointerCounter = 2;
	private int counter = 0;
	void Start () {
	
	}

	void Update () {	
		timer += Time.deltaTime;
		if (timer >= GameTempoScript.secPerRound / 16) {
			if (GameTempoScript.start) {
				counter++;
				if (counter == 2) {
					if (innerTurret.transform.GetChild (innerPointerCounter % 8).gameObject.activeSelf) {
						FirePoint.transform.GetChild (innerPointerCounter % 8).gameObject.GetComponent<TurretScript> ().Shoot (innerPointerCounter % 8);
					}
					innerPointer.transform.GetChild ((innerPointerCounter - 1) % 8).gameObject.SetActive (false);
					innerPointer.transform.GetChild (innerPointerCounter % 8).gameObject.SetActive (true);
					innerPointerCounter += 1;
					counter = 0;
				}
				if (outerTurret.transform.GetChild (outerPointerCounter % 16).gameObject.activeSelf) {
					outerTurret.transform.GetChild (outerPointerCounter % 16).gameObject.GetComponent<TurretScript> ().Shoot (outerPointerCounter % 16);
				}
				outerPointer.transform.GetChild ((outerPointerCounter - 1) % 16).gameObject.SetActive (false);
				outerPointer.transform.GetChild (outerPointerCounter % 16).gameObject.SetActive (true);
				outerPointerCounter += 1;
				timer = 0f;
			}
		}
	}


//	void OnTriggerEnter(Collider other){
//		Debug.Log (other.gameObject.name);
//		if (other.gameObject.name != "Sphere(Clone)") {
//			Rigidbody instantiatedProjectile = Instantiate (ball,
//				                                  other.gameObject.transform.position,
//												  other.gameObject.transform.rotation)
//			as Rigidbody;
//			instantiatedProjectile.velocity =  new Vector3 (other.gameObject.transform.position.x/4, other.gameObject.transform.position.y/4, 0);
//		}
//
//	}
}