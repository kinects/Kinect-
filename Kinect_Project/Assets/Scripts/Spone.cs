using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class Spone : MonoBehaviour
{

    //オブジェクト
    public GameObject ghost;
    public GameObject batsR;
    public GameObject batsL;
    public GameObject candy;
    public GameObject pumpkin;
    public GameObject fire;
    public GameObject shine;

    //フラグ
    public bool trgGhost = false;
    public bool trgBatsR = false;
    public bool trgBatsL = false;
    public bool trgCandy = false;
    public bool trgPumpkin = false;
    public bool trgFire = false;
    public bool trgShine = false;

    //コウモリの出ている数
    public static int BatRcnt = 0;
    public static int BatLcnt = 0;

    //炎が既にでているかどうかのスイッチ
    public static bool fireswitch = false;

    //キラキラがすでに出ているかどうかのスイッチ
    public static bool shineswitch = false;

    //かぼちゃ出現フラグ
    public static bool pumpkinFlg = true;

    private int count = 0;
    private bool ONE = true;
    private float x = 0;
    private float y = 0;
    private float z = 0;

    //n秒ごとに実行する
    public float sTime = 2;
    public float time;
    public float firetime = 0;
    public float shinetime = 0;

    // Use this for initialization
    void Start()
    {
        time = 2;
    }

    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;
        if (time <= 0.0)
        {

            //おばけ
            if (trgGhost == true)
            {

                //おばけを三体生成
                for (int i = 0; i <= 2; i++)
                {
                    //ランダム処理
                    x = Random.Range(-120f, 120f);
                    y = Random.Range(-100f, 100f);
                    z = 149f;

                    //ヨコアリくんのおびえるアニメーションを開始する
                    FindObjectOfType<Yokoari>().idleState = false;
                    FindObjectOfType<Yokoari>().squatState = true;

                    Instantiate(ghost, new Vector3(x, y, z), Quaternion.identity);
                }

                trgGhost = false;
            }

            //コウモリ始め
            if (trgBatsR == true)
            {

                //生成
                for (int i = 0; i <= 0; i++)
                {
                    if (BatRcnt < 1)
                    {
                        x = 15;
                        y = Random.Range(0, 4);
                        z = 10f;

                        Instantiate(batsR, new Vector3(x, y, z), Quaternion.identity);
                        BatRcnt++;
                    }
                }

                trgBatsR = false;
            }


            
            if (trgBatsL == true)
            {

                for (int i = 0; i <= 0; i++)
                {
                    if (BatLcnt < 1)
                    {
                        x = -15;
                        y = Random.Range(0, 4);
                        z = 10f;

                        Instantiate(batsL, new Vector3(x, y, z), Quaternion.identity);
                        BatLcnt++;
                    }
                    trgBatsL = false;
                }
            }
            //コウモリ終了




            //かぼちゃ
            if (trgPumpkin == true)
            {

                x = BodySourceView.bodyPos[(int)Kinect.JointType.SpineBase].x;
                y = 3f;
                z = 10f;


                //かぼちゃをつかむ
                if (pumpkinFlg)
                {
                    Instantiate(pumpkin, new Vector3(x, y, z), Quaternion.Euler(-90, 0, -180));
                    pumpkinFlg = false;
                }

                trgPumpkin = false;

            }
            //飴
            if (trgCandy == true)
            {

                if (ONE)
                {
                    for (int i = 0; i <= 30; i++)
                    {
                        x = Random.Range(-20, 20);
                        y = Random.Range(15, 50);
                        z = 10f;
                        Instantiate(candy, new Vector3(x, y, z), Quaternion.identity);
                    }
                    ONE = false;
                }

                Debug.Log(count);
                trgCandy = false;
                ONE = true;

            }

            //タイム管理
            time = sTime;
        }


        //火
        if (trgFire == true)
        {
            if (fireswitch == false)
            {
                Instantiate(fire, BodySourceView.bodyPos[(int)Kinect.JointType.ThumbRight], Quaternion.identity);

                //ヨコアリくんのびっくりするアニメーションを開始する
                FindObjectOfType<Yokoari>().idleState = false;
                FindObjectOfType<Yokoari>().supriseState = true;

                fireswitch = true;
            }
            else
            {
                GameObject.Find("Fire(Clone)").transform.position = BodySourceView.bodyPos[(int)Kinect.JointType.ThumbRight];
                firetime += Time.deltaTime;
            }
        }
        if (firetime > 5)
        {
            fireswitch = false;
            firetime = 0;
            trgFire = false;

            //ヨコアリくんのびっくりするアニメーションを戻す
            FindObjectOfType<Yokoari>().supriseState = false;
            FindObjectOfType<Yokoari>().idleState = true;

            Destroy(GameObject.Find("Fire(Clone)"));
        }

        //キラキラ
        if (trgShine == true)
        {
            if (shineswitch == false)
            {

                Instantiate(shine, BodySourceView.bodyPos[(int)Kinect.JointType.ThumbLeft], Quaternion.identity);
                shineswitch = true;
            }
            else
            {
                GameObject.Find("Shine(Clone)").transform.position = BodySourceView.bodyPos[(int)Kinect.JointType.ThumbLeft];
                shinetime += Time.deltaTime;
            }
        }
        if (shinetime > 5)
        {
            shineswitch = false;
            shinetime = 0;
            trgShine = false;
            Destroy(GameObject.Find("Shine(Clone)"));
        }

    }


}
