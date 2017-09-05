using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(player.transform.position.x + 5f, player.transform.position.y + 7f, player.transform.position.z);
        transform.position = newPos;
	}
}
