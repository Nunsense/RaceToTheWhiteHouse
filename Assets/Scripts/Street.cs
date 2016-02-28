using UnityEngine;
using System.Collections;

public class Street : MonoBehaviour {

	public GameObject streetBlockPrefab;
	public GameObject runnerPrefab;
	public Transform camera;

	public int runnerCount = 5;

	float streetBlockDistance = 74;
	float nextPositionToMove;
	int currentStreetBlock;

	StreetBlock[] streetBlocks;
	Runner[] runners;

	void Start() {
		nextPositionToMove = streetBlockDistance;
		currentStreetBlock = 0;

		streetBlocks = new StreetBlock[4];
		for (int i = 0; i < streetBlocks.Length; i++) {
			GameObject block = GameObject.Instantiate(streetBlockPrefab);
			block.transform.parent = transform;
			block.transform.position = new Vector3(0, 0, i * streetBlockDistance);
			streetBlocks[i] = block.GetComponent<StreetBlock>();
		}

		runners = new Runner[runnerCount];
		float initRunnerX = -8f;
		float runntXdiff = 16f / runners.Length;
		for (int i = 0; i < runners.Length; i++) {
			GameObject runner = GameObject.Instantiate(runnerPrefab);
			runner.transform.parent = transform;
			runner.transform.position = new Vector3(initRunnerX + (runntXdiff * i), 1, 10);
			runners[i] = runner.GetComponent<Runner>();
		}
	}

	void Update() {
		float zSum = 0;
		float zNotStuckCount = 0;

		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");

		Vector3 cameraPos = camera.position;

		for (int i = 0; i < runners.Length; i++) {
			Runner runner = runners[i];
			float runnerZ = runner.transform.position.z;
			if (runner.gameObject.activeSelf && !runner.isStuck) {
				zNotStuckCount++;
				zSum += runnerZ;
			}

			runner.MoveSide(horizontal);
			if (vertical > 0) {
				runner.Jump();
			}

			if (runner.isStuck || runnerZ < cameraPos.z) {
				runner.gameObject.SetActive(false);
			}
		}
		cameraPos.z = Mathf.Lerp(cameraPos.z, (zSum / zNotStuckCount) - 15f, Time.deltaTime * 1.8f);
		camera.position = cameraPos;

		if (camera.position.z > nextPositionToMove) {
			Vector3 pos = streetBlocks[currentStreetBlock].transform.position;
			pos.z += streetBlockDistance * streetBlocks.Length;
			streetBlocks[currentStreetBlock].transform.position = pos;
			streetBlocks[currentStreetBlock].Reset();

			nextPositionToMove += streetBlockDistance;

			currentStreetBlock++;
			if (currentStreetBlock >= streetBlocks.Length)
				currentStreetBlock = 0;
		}
	}
}
