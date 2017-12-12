using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(0, ball.transform.position.y + 2, ball.transform.position.z - .5f);
        transform.position = pos;
	}
}
