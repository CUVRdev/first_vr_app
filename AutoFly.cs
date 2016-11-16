using UnityEngine;
using System.Collections;

public class AutoFly : MonoBehaviour {

	[Tooltip("GvrViewer in the scene.")]
	public GvrViewer viewer;

	[Tooltip("Speed at which the player will move.")]
	public float speed;

	// Whether or not player is flying
	private bool isFlying;

	// Use this for initialization
	void Start () {
		// Stationary start
		isFlying = false;
	}

	// Update is called once per frame
	void Update () {

		// Check if user has triggered fly/stop
		// (Triggered is called when the user presses the button on their VR headset)
		if (viewer.Triggered) {
			isFlying = !isFlying;
		}

		// Move Camera if flying
		if (isFlying) {
			// Translate the Camera by getting the forward vector from the Camera
			// Time.deltaTime will smooth out the movement
			this.transform.position += this.transform.forward * Time.deltaTime * speed;
		}
	}
}
