using UnityEngine;
using System.Collections;

public class AutoFly : MonoBehaviour {

	[Tooltip("GvrViewer in the scene.")]
	public GvrViewer viewer;

	[Tooltip("Speed at which the player will move.")]
	public float speed;

	// Whether or not player is flying
	private bool isFlying;

	// The Camera in the Head
	private Camera headCamera;


	// Use this for initialization
	void Start () {
		// Stationary start
		isFlying = false;

		// Initialize headCamera to the Camera in the child of Head
		headCamera = this.GetComponentInChildren<Camera> ();
	}

	// Update is called once per frame
	void Update () {

		// Check if user has triggered fly/stop
		// (Triggered is called when the user presses the button on their VR headset)
		if (viewer.Triggered) {
			isFlying = !isFlying;
		}

		// Move Head if flying
		if (isFlying) {
			// Translate the Head by getting the forward vector from the headCamera
			// Time.deltaTime will smooth out the movement
			this.transform.position += headCamera.transform.forward * Time.deltaTime * speed;
		}
	}
}
