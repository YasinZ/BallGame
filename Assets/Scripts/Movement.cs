// iOS gyroscope example
//
// Create a cube with camera vector names on the faces.
// Allow the iPhone to show named faces as it is oriented.

using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool gyroEnabled;
    private int [] speeds;
    private Gyroscope gyro;
    private GameManager gm;
    public bool onMaze = false;

    private void Start()
    {
        gm = Object.FindObjectOfType<GameManager>();
        speeds = new int[5];
        speeds[0] = 11;
        speeds[1] = 11;
        speeds[2] = 10;
        speeds[3] = 19;
        speeds[4] = 8;
        Screen.orientation = ScreenOrientation.LandscapeRight;
        gyroEnabled = EnableGyro();
       // Debug.Log(gyroEnabled);
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

    private void Update()
    {
        //Debug.Log(gm.currentRamp);
        Debug.Log(speeds[gm.currentRamp]);
        //Debug.Log(onMaze);
        if (gyroEnabled && !onMaze)
        {
            //Debug.Log(gyro.attitude.y);
            //Debug.Log(-1 * Vector3.right);
            //Debug.Log(gyro.rotationRate.y);
            //Debug.Log(gm.currentRamp);
            if (gyro.attitude.y < -0.01f)
                GetComponent<Rigidbody>().AddForce(Vector3.right * speeds[gm.currentRamp]);
            //transform.Translate(Vector3.right * .001f);
            else if ((gyro.attitude.y > 0.1f))
                GetComponent<Rigidbody>().AddForce(Vector3.left * speeds[gm.currentRamp]);
            //transform.Translate(Vector3.right * .001f);
            gameObject.transform.rotation = gyro.attitude;
            //GetComponent<Rigidbody>().AddForce(Vector3.forward * 5);
            //GetComponent<Rigidbody>().MovePosition(Vector3.forward);
            //transform.Translate(Vector3.forward);
        }

        if(gyroEnabled && onMaze)
        {
            gameObject.transform.rotation = gyro.attitude;
            if (gyro.attitude.y < -0.01f)
                GetComponent<Rigidbody>().AddForce(Vector3.right * 5);
            //transform.Translate(Vector3.right * .001f);
            else if ((gyro.attitude.y > 0.1f))
                GetComponent<Rigidbody>().AddForce(Vector3.left * 5);

            if (gyro.attitude.x < -0.01f)
                GetComponent<Rigidbody>().AddForce(Vector3.back * 5);
            //transform.Translate(Vector3.right * .001f);
            else if ((gyro.attitude.x > 0.1f))
                GetComponent<Rigidbody>().AddForce(Vector3.forward * 2);

            //GetComponent<Rigidbody>().AddForce(direction * 2);
        }
        //GetComponent<Rigidbody>().AddForce(Vector3.forward * 10);
    }
}