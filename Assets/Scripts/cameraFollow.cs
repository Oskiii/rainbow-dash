using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
	public GameObject following;

	void Update () {
		transform.position = following.transform.position + new Vector3(0f,0f, -10f);
	}
}
