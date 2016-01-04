using UnityEngine;
using System.Collections;

public class movingGround : MonoBehaviour {

	//Material texture offset rate
	float speed = 0.8f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float offset = Time.time * speed;
		this.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0,-offset);


	}
}
