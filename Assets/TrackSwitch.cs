using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackSwitch : MonoBehaviour {

	private int trackNumber;
	public int numOfTracks = 3;
	public GameObject track1;
	public GameObject track2;
	public GameObject track3;

	public float fadeAmount;

	void Start(){
		trackNumber = 1;
		ChangeTrack ();

	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			PlusTrack ();
			ChangeTrack();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			MinusTrack ();
			ChangeTrack();
		}
	}

	void PlusTrack(){
		if (trackNumber < 3) {
			trackNumber++;
		} else {
			print ("can't plus track");
		}
	}

	void MinusTrack(){
		if (trackNumber > 1) {
			trackNumber--;
		} else {
			print ("can't minus track");
		}
	}

	void ChangeTrack(){
		SpriteRenderer[] spriteRenderers;
		BoxCollider2D[] boxColliders;
		if (trackNumber == 1) {

			//sprite renderers
			spriteRenderers = track1.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < spriteRenderers.Length; i++) {
				spriteRenderers [i].color = new Color (spriteRenderers [i].color.r, spriteRenderers [i].color.g, spriteRenderers [i].color.b, 1f);
			}

			spriteRenderers = track2.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < spriteRenderers.Length; i++) {
				spriteRenderers [i].color = new Color (spriteRenderers [i].color.r, spriteRenderers [i].color.g, spriteRenderers [i].color.b, fadeAmount);
			}

			spriteRenderers = track3.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < spriteRenderers.Length; i++) {
				spriteRenderers [i].color = new Color (spriteRenderers [i].color.r, spriteRenderers [i].color.g, spriteRenderers [i].color.b, fadeAmount);
			}

			//box colliders
			boxColliders = track1.GetComponentsInChildren<BoxCollider2D> ();
			for (int i = 0; i < boxColliders.Length; i++) {
				boxColliders[i].enabled = true;
			}
			
			boxColliders = track2.GetComponentsInChildren<BoxCollider2D> ();
			for (int i = 0; i < boxColliders.Length; i++) {
				boxColliders[i].enabled = false;
			}
			
			boxColliders = track3.GetComponentsInChildren<BoxCollider2D> ();
			for (int i = 0; i < boxColliders.Length; i++) {
				boxColliders[i].enabled = false;
			}
		} else if (trackNumber == 2) {
			//sprite renderers
			spriteRenderers = track1.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < spriteRenderers.Length; i++) {
				spriteRenderers [i].color = new Color (spriteRenderers [i].color.r, spriteRenderers [i].color.g, spriteRenderers [i].color.b, fadeAmount);
			}
			
			spriteRenderers = track2.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < spriteRenderers.Length; i++) {
				spriteRenderers [i].color = new Color (spriteRenderers [i].color.r, spriteRenderers [i].color.g, spriteRenderers [i].color.b, 1f);
			}
			
			spriteRenderers = track3.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < spriteRenderers.Length; i++) {
				spriteRenderers [i].color = new Color (spriteRenderers [i].color.r, spriteRenderers [i].color.g, spriteRenderers [i].color.b, fadeAmount);
			}

			//box colliders
			boxColliders = track1.GetComponentsInChildren<BoxCollider2D> ();
			for (int i = 0; i < boxColliders.Length; i++) {
				boxColliders[i].enabled = false;
			}
			
			boxColliders = track2.GetComponentsInChildren<BoxCollider2D> ();
			for (int i = 0; i < boxColliders.Length; i++) {
				boxColliders[i].enabled = true;
			}
			
			boxColliders = track3.GetComponentsInChildren<BoxCollider2D> ();
			for (int i = 0; i < boxColliders.Length; i++) {
				boxColliders[i].enabled = false;
			}
		} else if (trackNumber == 3) {
			//sprite renderers
			spriteRenderers = track1.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < spriteRenderers.Length; i++) {
				spriteRenderers [i].color = new Color (spriteRenderers [i].color.r, spriteRenderers [i].color.g, spriteRenderers [i].color.b, fadeAmount);
			}
			
			spriteRenderers = track2.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < spriteRenderers.Length; i++) {
				spriteRenderers [i].color = new Color (spriteRenderers [i].color.r, spriteRenderers [i].color.g, spriteRenderers [i].color.b, fadeAmount);
			}
			
			spriteRenderers = track3.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < spriteRenderers.Length; i++) {
				spriteRenderers [i].color = new Color (spriteRenderers [i].color.r, spriteRenderers [i].color.g, spriteRenderers [i].color.b, 1f);
			}

			//box colliders
			boxColliders = track1.GetComponentsInChildren<BoxCollider2D> ();
			for (int i = 0; i < boxColliders.Length; i++) {
				boxColliders[i].enabled = false;
			}
			
			boxColliders = track2.GetComponentsInChildren<BoxCollider2D> ();
			for (int i = 0; i < boxColliders.Length; i++) {
				boxColliders[i].enabled = false;
			}
			
			boxColliders = track3.GetComponentsInChildren<BoxCollider2D> ();
			for (int i = 0; i < boxColliders.Length; i++) {
				boxColliders[i].enabled = true;
			}
		}
	}
}
