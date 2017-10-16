using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDestroy : MonoBehaviour {

    public int desCnt = 0; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (desCnt == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
