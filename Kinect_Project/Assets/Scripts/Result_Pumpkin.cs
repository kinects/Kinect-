using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_Pumpkin : MonoBehaviour {

    public GameObject face;             //カボチャの顔
    public float color_time = 0;              //色を変化させる時間

    // Use this for initialization
    void Start () {
        face = GameObject.Find("pumpkin_face");
        face.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        color_time += Time.deltaTime;

        if (color_time > 1)
        {
            face.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
            color_time = 0;
        }
    }
}
