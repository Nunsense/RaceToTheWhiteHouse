using UnityEngine;
using System.Collections;

public class ManifestationMovement : MonoBehaviour {
	public float max;
	public float min;
	public float walkingTime = 5f;

	Vector3 pos;
	float nextTarget;
	float walkingTimeElapsed = 0f;

	void Start() {
		nextTarget = min;
		walkingTimeElapsed = 0;
		pos = transform.localPosition;
	}

	void Update() {
		pos = transform.localPosition;
		walkingTimeElapsed += Time.deltaTime;

		if (walkingTimeElapsed > walkingTime) {
			walkingTimeElapsed = 0;
			nextTarget = (nextTarget == min) ? max : min; 
		}

		pos.x = Mathf.Lerp(pos.x, nextTarget, walkingTimeElapsed / walkingTime);
		transform.localPosition = pos;
	}
}
