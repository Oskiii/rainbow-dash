using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
	public GameObject following;
	Vector3 velocity = Vector3.zero;
	public float dampTime = 0.2f;

	void Update () {
		transform.position = new Vector3(following.transform.position.x, following.transform.position.y, transform.position.z);
	}
}
