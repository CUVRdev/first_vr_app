using UnityEngine;
using System.Collections;

public class MoveRandom : MonoBehaviour {

	[Tooltip("Speed at which the object will move.")]
	public float speed;

	[Tooltip("Time interval between changing directions.")]
	public float timeInterval;

	[Tooltip("Minimum Y-value for motion.")]
	public float floor;

	[Tooltip("Maximum Y-value for motion.")]
	public float ceiling;

	private bool isMoving;

	private Vector3 randomDirection;

	private float nextUpdateTime;

	// Use this for initialization
	void Start () {
		isMoving = false;
		randomDirection = Random.insideUnitSphere;
		nextUpdateTime = 0;
	}

	// Update is called once per frame
	void Update () {
		if (isMoving) {
			transform.position += randomDirection * Time.deltaTime * speed;

			if (Time.time >= nextUpdateTime) {
				randomDirection = Random.insideUnitSphere;

				// Check ceiling
				if (this.transform.position.y + randomDirection.y * timeInterval * speed > ceiling && randomDirection.y > 0) {
					randomDirection = new Vector3 (randomDirection.x, -randomDirection.y, randomDirection.z).normalized;
				}

				// Check floor
				if (this.transform.position.y + randomDirection.y * timeInterval * speed < floor && randomDirection.y < 0) {
					randomDirection = new Vector3 (randomDirection.x, -randomDirection.y, randomDirection.z).normalized;
				}

				nextUpdateTime = Time.time + timeInterval;
			}
		}
	}

	public void ToggleRandomMovement() {
		isMoving = !isMoving;
	}
}
