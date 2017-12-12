using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
    private GameManager gm;
    public Text text;

	// Use this for initialization
	void Start () {
        gm = Object.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "Score: " + gm.score.ToString();
	}
}
