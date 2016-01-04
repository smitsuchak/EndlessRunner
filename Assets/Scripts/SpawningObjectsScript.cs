using UnityEngine;
using System.Collections;

public class SpawningObjectsScript : MonoBehaviour {

	public GameObject obstacle;
	public GameObject powerup;

	float timeElapsed = 0;
	float spawnCycle = 0.5f;
	bool spawnPowerup = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > spawnCycle)
		{
			GameObject temp;
			if(spawnPowerup)
			{
				temp = (GameObject)Instantiate(powerup);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
			}
			else
			{
				temp = (GameObject)Instantiate(obstacle);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z);
			}

			timeElapsed -= spawnCycle;
			spawnPowerup = !spawnPowerup;
		}
	}
}
