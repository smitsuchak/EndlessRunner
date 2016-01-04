using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour {

	public float objectSpeed = -0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, objectSpeed, 0);
	}
}
