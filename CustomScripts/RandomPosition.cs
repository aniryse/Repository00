using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	const float XMIN = -20.0f;
	const float XMAX = 20.0f;
	const float ZMIN = -20.0f;
	const float ZMAX = 20.0f;
	public float SECONDS_TO_FIND_POSITION = 8.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine (RePositionWithDelay());
	}
	
	IEnumerator RePositionWithDelay(){
			while (true) {
				SetRandomPosition();
				yield return new WaitForSeconds (SECONDS_TO_FIND_POSITION);
		}
	}

	void SetRandomPosition(){
			float x = Random.Range (XMIN, XMAX);
			float z = Random.Range (ZMIN, ZMAX);
			Debug.Log ("X: " + x.ToString("F2") + ", Z:" + z.ToString("F2"));
			           transform.position = new Vector3 (x, 0.0f, z);

	}
	// Update is called once per frame
	void Update () {
	
	}
}
