using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLantern : MonoBehaviour {

	public bool hold;
	public GameObject lantern;
	public BoxCollider mouse;
	public Vector3 mousePos;
	private GameObject tempLantern;
	public bool objDestroyed = true;
	void Start () {
		tempLantern = Instantiate (lantern, mousePos, Quaternion.identity);

	}
	
	void Update () {
		mousePos = Input.mousePosition;
		mousePos.z = 10;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		mouse.transform.position = mousePos;
		if (!objDestroyed) {
			tempLantern.transform.position = mousePos;
		}
		if (Input.GetMouseButton (0)) {
			hold = true;
		} else {
			hold = false;
		}
	}
	void OnTriggerEnter(Collider other){
		if (!hold && other.gameObject.tag == "Mouse" && !objDestroyed) {
			objDestroyed = true;
			Destroy (tempLantern);
		}
	}
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Mouse" && hold && objDestroyed) {
			objDestroyed = false;
			tempLantern = Instantiate (lantern, mousePos, Quaternion.identity);
		}
	}
}
