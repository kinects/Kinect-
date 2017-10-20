using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class candle : MonoBehaviour
{
    public GameObject flame;
    public GameObject flame2;

    private float len;
    private float len2;

    public bool candleTrg;
    // Use this for initialization
    void Start()
    {
        len = 0;
        len2 = 0;
        flame.SetActive(false);
        flame2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject candle1 = GameObject.Find("Candle1");
        GameObject candle2 = GameObject.Find("Candle2");

        Vector3 candle1Pos = candle1.transform.position;
        Vector3 candle2Pos = candle2.transform.position;

        Debug.Log("len="+len);
        Debug.Log("len2=" + len2);
        //一本目のキャンドルと手の座標の位置を比べる
        len = ((BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - candle1Pos.x) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - candle1Pos.x) +
               (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - candle1Pos.y) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - candle1Pos.y));
        if (Spone.fireswitch == true)
        {
            len = ((BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - candle1Pos.x) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - candle1Pos.x) +
               (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - candle1Pos.y) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - candle1Pos.y));
            if (Mathf.Sqrt(len) <= 10f)
            {
                flame.SetActive(true);
            }
        }


        //二本目のキャンドルと手の座標を比べる
        len2 = ((BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - candle2Pos.x) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - candle2Pos.x) +
               (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - candle2Pos.y) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - candle2Pos.y));
        if (Spone.fireswitch == true)
        {
            if (Mathf.Sqrt(len2) <= 0.5f)
            {
                flame2.SetActive(true);
            }
        }
    }
}
