using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro;
 
	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        gyroEnabled = EnableGyro();
	}

    private bool EnableGyro()
    {
        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }
	
	// Update is called once per frame
	void Update () {

		if(gyroEnabled)
        {
            //gameObject.transform.rotation = gyro.attitude;
        }

        // Left right is controlled by shifting the phone up and down instead of left and right
        // When you clip into a wall movement stops

	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            other.GetComponent<Movement>().onMaze = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.GetComponent<Movement>().onMaze = false;
        }
    }
}
