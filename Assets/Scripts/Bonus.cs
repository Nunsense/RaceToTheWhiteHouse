using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {
	public float speedBonus = 10;

	Transform trans;
	Vector3 rotation;

	void Awake() {
		trans = transform;
		rotation = trans.localEulerAngles;
	}

	void Update() {
		rotation.y += 30 * Time.deltaTime;
		trans.localEulerAngles = rotation;
	}
}
