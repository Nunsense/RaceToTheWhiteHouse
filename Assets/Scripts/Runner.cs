﻿using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	Rigidbody body;
	float originalSpeed = 300f;
	float speed = 300f;
	float sideSpeed = 0f;
	bool jumping;

	float bonusTime = 0.01f;
	float bonusTimeToFinish = 0;

	float speedBonus;

	float lastZ;
	public bool isStuck = false;

	void Awake() {
		body = GetComponent<Rigidbody>();
		isStuck = false;
	}

	void Start() {
		Vector3 pos = transform.position;
		pos.y = Random.Range(pos.y, pos.y + 1f);
		transform.position = pos;

		jumping = false;
	}
	
	// Update is called once per frame
	void Update() {
//		body.S(body.transform.forward * speed);
//			body.velocity = 
//		Vector3 pos = transform.position;
//		pos.z += speed;
//
//		transform.position = pos;

//		if (bonusTimeToFinish > 0) {
//			bonusTimeToFinish -= Time.deltaTime;
//
//			if (bonusTimeToFinish < 0) {
//				speed = originalSpeed;
//			}
//		}
//
		if (transform.position.z - lastZ < 5) {
			isStuck = true;
		} 
	}

	public void Jump() {
		if (!jumping) {
			jumping = true;
			body.AddForce(new Vector3(0, 150, 0));
		}		
	}

	public void MoveSide(float sideSpeedDirection) {
		this.sideSpeed = sideSpeedDirection * speed;
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Ground" && col.contacts[0].point.y - 0.1f < transform.position.y) {
			jumping = false;
			body.AddForce(new Vector3(sideSpeed, 300, speed));

//			speed = originalSpeed;
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Bonus") {
			body.AddForce(new Vector3(0, 0, col.GetComponent<Bonus>().speedBonus));
			col.gameObject.SetActive(false);
		}
	}
}
