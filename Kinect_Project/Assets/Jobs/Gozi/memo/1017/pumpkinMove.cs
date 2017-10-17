﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class pumpkinMove : MonoBehaviour {

    private bool grabFlg = false;
    private Vector3 pumpkinPos;
    public float len = 0;
    public float len2 = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        PumpkinMove();
	}

    void PumpkinMove()
    {

        pumpkinPos = transform.position;

        //手と手が一定の距離ならグラブフラグをオンにする
        len = ((BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].x) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].x) +
               (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].y) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].y));

        len2 = (((BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].x - pumpkinPos.x) * (BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].x - pumpkinPos.x)) +
                ((BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].y - pumpkinPos.y) * (BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].y - pumpkinPos.y)));

        Debug.Log("Move");
        if (Mathf.Sqrt(len) <= 0.5f)
        {
            grabFlg = true;
            Debug.Log("掴む");
        }
        else if (Mathf.Sqrt(len) >= 1.0f)
        {
            Debug.Log("離す");
            grabFlg = false;
        }



        if (grabFlg == true && Mathf.Sqrt(len2) <= 1.5f)
        {
            Debug.Log("hey");
            pumpkinPos.x = BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].x;
            pumpkinPos.y = BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].y;
            pumpkinPos.z = 10f;
        }


        transform.position = pumpkinPos;


    }
}
