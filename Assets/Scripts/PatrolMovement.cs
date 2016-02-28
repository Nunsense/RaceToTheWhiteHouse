using UnityEngine;
using System.Collections;

public class PatrolMovement : MonoBehaviour {
	public float max;
	public float min;
	public float walkingTime = 2f;

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

		pos.x = Mathf.Lerp(pos.x, nextTarget, walkingTimeElapsed / walkingTime);

		if (walkingTimeElapsed > walkingTime) {
			walkingTimeElapsed = 0;
			pos.x = nextTarget;
			nextTarget = (nextTarget == min) ? max : min; 
		}

		transform.localPosition = pos;
	}
}
