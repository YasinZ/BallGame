using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenNext : MonoBehaviour {
    
    public GameObject [] next;
    public GameObject[] maze;
    public GameObject blank;
    public GameManager gm;
    private bool created = false;

	// Use this for initialization
	void Start () {
        gm = Object.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && !created)
        {
            if (gm.score == 0)
            {
                int randIndex = Random.Range(0, maze.Length);
                GameObject nextMaze = Instantiate(maze[randIndex]);
                nextMaze.transform.localPosition = new Vector3(0, -0.776f * gm.numGenerated, 2.802f * gm.numGenerated);
                gm.Increase();
                created = true;
                Destroy(this.transform.parent.gameObject, 30);
                GameObject blankO = Instantiate(blank);
                blankO.transform.localPosition = new Vector3(0, -0.873f * gm.numGenerated -1, 2.5645f * gm.numGenerated);
                gm.Increase();
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    //Debug.Log("Before incremented: " + gm.numGenerated + " created: " + created + " object name: " + this.name);
                    int randIndex = Random.Range(0, next.Length);
                    GameObject nextRamp = Instantiate(next[randIndex]);
                    nextRamp.transform.localPosition = new Vector3(0, -1.5f * gm.numGenerated, 2.596f * gm.numGenerated);
                    gm.Increase();
                    created = true;
                    Destroy(this.transform.parent.gameObject, 15);
                    //Debug.Log(gm.numGenerated);

                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ball") && created)
        {
            gm.score++;
        }
    }
}
