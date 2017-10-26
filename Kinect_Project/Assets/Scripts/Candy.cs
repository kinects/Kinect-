using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cutcut")
        {
            Destroy(gameObject);
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
