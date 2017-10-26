using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class candle : MonoBehaviour
{
    public GameObject flame;
    public GameObject flame2;

    public float len;
    public float len2;

    //炎がついたかのフラグ
    private bool flame1Flg = false;
    private bool flame2Flg = false;

    public bool candleFlg = false;

    // Use this for initialization
    void Start()
    {
        len = 0;
        len2 = 0;
        flame1Flg = false;
        flame2Flg = false;
        candleFlg = false;
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

        //火がついていたら機能する

        if (Spone.fireswitch == true)
        {
            GameObject fire = GameObject.Find("Fire(Clone)");
            Vector3 firePos = fire.transform.position;
            //一本目のキャンドルと手の座標の位置を比べる
            len = ((firePos.x - candle1Pos.x) * (firePos.x - candle1Pos.x) +
                   (firePos.y - candle1Pos.y) * (firePos.y - candle1Pos.y));
            Debug.Log(firePos);

            //二本目のキャンドルと手の座標を比べる
            len2 = ((firePos.x - candle2Pos.x) * (firePos.x - candle2Pos.x) +
                   (firePos.y - candle2Pos.y) * (firePos.y - candle2Pos.y));

        }
        Debug.Log(candle1Pos);
        
        
        if (Spone.fireswitch == true)
        {
            if (Mathf.Sqrt(len) <= 1.0f && FindObjectOfType<Balloon>().cd_balloon == true || Input.GetKeyDown(KeyCode.Alpha7))
            {
                flame.SetActive(true);
                flame1Flg = true;
            }
        }


        
        if (Spone.fireswitch == true)
        {
            if (Mathf.Sqrt(len2) <= 1.0f && FindObjectOfType<Balloon>().cd_balloon == true)
            {
                flame2.SetActive(true);
                flame2Flg = true;
            }
        }

        if (flame1Flg == true && flame2Flg == true &&candleFlg == false)
        {
            FindObjectOfType<Balloon>().candle_balloon.SetActive(false);
            FindObjectOfType<Balloon>().pu_balloon = true;
            candleFlg = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            FindObjectOfType<Balloon>().candle_balloon.SetActive(false);
            FindObjectOfType<Balloon>().pu_balloon = true;
            candleFlg = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            flame.SetActive(true);
            flame1Flg = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            flame2.SetActive(true);
            flame2Flg = true;
        }

    }
}
