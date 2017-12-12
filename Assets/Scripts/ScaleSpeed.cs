using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSpeed : MonoBehaviour {
    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = Object.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {

            int.TryParse(this.tag, out gm.currentRamp);
            //Debug.Log("SS" + this.tag + " gm.speed " + gm);
        }
    }
}

