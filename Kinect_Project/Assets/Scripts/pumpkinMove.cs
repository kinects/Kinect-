using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class pumpkinMove : MonoBehaviour
{

    private bool grabFlg = false;
    private Vector3 pumpkinPos;
    private Vector3 yokoariPos;
    private bool moveFlg = true;

    //手と手の二点間
    public float len = 0;
    //手とかぼちゃの二点間
    public float len2 = 0;
    //かぼちゃとヨコアリの二点間
    public float len3 = 0;
    //かぼちゃが消えるまでの時間
    private float desTime;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Yokoari")
        { 
            Spone.pumpkinFlg = true;
            FindObjectOfType<YokoariChange>().indexTrg = 2;
            Smoke.trgSmoke = true;
            Spone.pumpkinFlg = true;
            Destroy(gameObject);
        }

        //かぼちゃがテーブルに当たったら
        if (other.tag == "Table" && FindObjectOfType<candle>().candleFlg == true)
        {
            Spone.pumpkinComboFlg = true;
            FindObjectOfType<Balloon>().pumpkin_balloon.SetActive(false);
            FindObjectOfType<Balloon>().cn_balloon = true;
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        desTime = 15;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Spone.pumpkinComboFlg = true;
            FindObjectOfType<Balloon>().pumpkin_balloon.SetActive(false);
            FindObjectOfType<Balloon>().cn_balloon = true;
            Destroy(gameObject);
        }


        PumpkinMove();

    }

    void PumpkinMove()
    {
        if (FindObjectOfType<YokoariChange>().indexTrg == 0)
        {
            GameObject yokoari = GameObject.Find("Yokoari");
            yokoariPos = yokoari.transform.position;
        }

        pumpkinPos = transform.position;

        //手と手が一定の距離ならグラブフラグをオンにする
        len = ((BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].x) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].x - BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].x) +
               (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].y) * (BodySourceView.bodyPos[(int)Kinect.JointType.HandRight].y - BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].y));

        len2 = (((BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].x - pumpkinPos.x) * (BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].x - pumpkinPos.x)) +
                ((BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].y - pumpkinPos.y) * (BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].y - pumpkinPos.y)));

        /*len3 = ((yokoariPos.x - pumpkinPos.x) * (yokoariPos.x - pumpkinPos.x) +
                 (yokoariPos.y +3 - pumpkinPos.y) * (yokoariPos.y+3 - pumpkinPos.y));*/

        Debug.Log(grabFlg);

/*
        if (Mathf.Sqrt(len3)<=1.0f)
        {
            FindObjectOfType<YokoariChange>().indexTrg = 2;
            Smoke.trgSmoke = true;
            Spone.pumpkinFlg = true;
            Destroy(gameObject);
        }*/

        if (Mathf.Sqrt(len) <= 1.0f)
        {
            grabFlg = true;
            Debug.Log("掴む");
        }
        else if (Mathf.Sqrt(len) >= 1.0f)
        {
            Debug.Log("離す");
            grabFlg = false;
        }



        if (grabFlg == true && Mathf.Sqrt(len2) <= 2.0f)
        {
            pumpkinPos.x = BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].x;
            pumpkinPos.y = BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].y;
            pumpkinPos.z = BodySourceView.bodyPos[(int)Kinect.JointType.WristRight].z;
        }
        else
        {
            desTime -= Time.deltaTime;
            if (desTime < 0)
            {
                Destroy(gameObject);
                Spone.pumpkinFlg = true;
            }
        }


        transform.position = pumpkinPos;


    }

}
