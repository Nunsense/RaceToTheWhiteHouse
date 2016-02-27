using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StreetBlock : MonoBehaviour {

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	public void Reset() {
		Bonus[] bonuses = GetComponentsInChildren<Bonus>();
		foreach (Bonus bonus in bonuses) {
			bonus.gameObject.SetActive(true);
		}
	}
}
