using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {
	public float max;
	public float min;
	public float movingTimeAvg = 3f;

	Vector3 pos;
	float nextTarget;
	float movingTime;
	float movingTimeElapsed = 0f;

	void Start() {
		nextTarget = min;
		movingTimeElapsed = 0;
		pos = transform.localPosition;
		movingTime = Random.Range(movingTimeAvg - 2f, movingTimeAvg + 2f);
	}

	void Update() {
		pos = transform.localPosition;
		movingTimeElapsed += Time.deltaTime;

		if (movingTimeElapsed > movingTime) {
			movingTimeElapsed = 0;
			nextTarget = (nextTarget == min) ? max : min; 
			Vector3 rotation = transform.eulerAngles;
			rotation.y += 180;
			transform.eulerAngles = rotation;
			movingTime = Random.Range(movingTimeAvg - 1f, movingTimeAvg + 1f);
		}

		pos.x = Mathf.Lerp(pos.x, nextTarget, movingTimeElapsed / movingTime);
		transform.localPosition = pos;
	}
}
