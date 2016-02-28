using UnityEngine;
using System.Collections;

public class MarathonMovement : MonoBehaviour {
	public float max;
	public float min;

	Vector3 pos;

	float sleepTime = 2f;
	float sleepTimeElapsed = 0;

	float runningTime = 5f;
	float runningTimeElapsed = 0;

	bool running;

	void Start() {
		running = false;
		pos = transform.localPosition;
		pos.x = max;
		transform.localPosition = pos;

		runningTimeElapsed = 0;
		sleepTimeElapsed = 0;
		sleepTime = Random.Range(sleepTime - 1f, sleepTime);
	}

	void Update() {
		if (running) {
			runningTimeElapsed += Time.deltaTime;

			pos = transform.localPosition;
			pos.x = Mathf.Lerp(pos.x, min, runningTimeElapsed / runningTime);

			if (runningTimeElapsed > runningTime) {
				runningTimeElapsed = 0;
				pos.x = max;
				running = false;
			}

			transform.localPosition = pos;
		} else {
			sleepTimeElapsed += Time.deltaTime;

			if (sleepTimeElapsed > sleepTime) {
				sleepTimeElapsed = 0;
				running = true;
				sleepTime = Random.Range(sleepTime - 1f, sleepTime);
			}
		}
	}
}
