using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

    public GameObject circle;
    public GameObject gage;

    private Vector3 circlePos;
    private float circleScale;
    public float circleAngle = 0;

    public bool titleTrg = false;

	// Use this for initialization
	void Start () {

        circlePos = circle.transform.position;
        circleScale = circle.transform.localScale.x / 2;

    }
	
	// Update is called once per frame
	void Update () {

        if (titleTrg == true)
        {
            circleAngle -= 2;
        }
        else
        {
            circleAngle = 0;
        }

        if (circleAngle <= -360)
        {
            SceneManager.LoadScene("MainScene");
        }

        gage.transform.localEulerAngles = new Vector3(0, 0, circleAngle + 90);
        gage.transform.position = circlePos + new Vector3(Mathf.Cos(circleAngle * 3.14f / 180f) * circleScale,
                                                          Mathf.Sin(circleAngle * 3.14f / 180f) * circleScale, 0);


    }
}
