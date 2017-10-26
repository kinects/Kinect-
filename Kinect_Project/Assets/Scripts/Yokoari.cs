using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yokoari : MonoBehaviour
{

    //最も近いオブジェクト
    private GameObject nearObj;

    //動くスピード
    public Vector2 speed = new Vector2(0.02f, 0f);

    //経過時間
    private float time = 0;

    //横軸追尾の変数
    float theta;
    float vx;

    //アニメーションのやつ
    Animator animator;

    //ヨコアリくんの状態
    public bool idleState = true;
    public bool squatState = false;
    public bool supriseState = false;

    private Vector2 Position;
    private SpriteRenderer spRenderer;
    public static bool Hockenswitch = false;

    // Use this for initialization
    void Start()
    {

        //変数にアニメーターを入れる
        animator = GetComponent(typeof(Animator)) as Animator;

        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "Ghost");

    }

    // Update is called once per frame
    void Update()
    {

        //アニメーションを再生する
        Animation();




        time += Time.deltaTime;

        if (time >= 1.0f)
        {
            //Ghostのタグを持ってるやつを取得
            nearObj = serchTag(gameObject, "Ghost");
            time = 0;
        }

        //目的のタグを持つやつがいるか判定
        if (nearObj != null)
        {
            GhostTracking();
        }
        else
        {

        }

        //コウモリの処理
        aveBat();

    }

    //指定されたタグの中で最も近いやつを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        //距離用の一時変数
        float tmpDis = 0;

        //最も近いオブジェクトの距離
        float nearDis = 0;

        //オブジェクトの名称
        string nearObjName = "obake";
        GameObject targetObj = null;

        //タグ指定されたオブジェクトを配列で取得
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自信と指定されたオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離が0ならオブジェクト名を取得
            //一時的に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                nearObjName = obs.name;
                targetObj = obs;
            }
        }
        //一番近かったオブジェクトを返す
        return GameObject.Find(nearObjName);
        return targetObj;

    }

    void GhostTracking()
    {
        Vector2 nowPos = transform.position;
        Vector2 enemyPos = nearObj.transform.position;

        //追尾するやつ
        theta = Mathf.Atan2(enemyPos.y - nowPos.y, enemyPos.x - nowPos.x);
        vx = Mathf.Cos(theta) * speed.x;

        nowPos.x += vx;

        transform.position = nowPos;
    }

    void aveBat()
    {
        switch(FindObjectOfType<YokoariChange>().indexTrg)
        {

            case 0:
                Vector3 ypos = GameObject.Find("Yokoari").transform.position;

                if (Spone.BatLcnt > 0)
                {
                    if (Vector2.Distance(GameObject.Find("BatL3D(Clone)").transform.position, transform.position) < 6.5f)
                    {
                        ypos.z = 10;
                        Hockenswitch = true;
                    }
                    else
                    {
                        if (Smoke.trgsSmoke == false)
                        {
                            ypos.z = 10;
                            Hockenswitch = false;
                        }
                    }
                }
                if (Spone.BatRcnt > 0)
                {
                    if (Vector2.Distance(GameObject.Find("BatR3D(Clone)").transform.position, transform.position) < 6.5f)
                    {
                        ypos.z = 10;
                        Hockenswitch = true;
                    }
                    else
                    {
                        if (Smoke.trgsSmoke == false)
                        {
                            ypos.z = 10;
                            Hockenswitch = false;
                        }
                    }
                }

                GameObject.Find("Yokoari").transform.position = ypos;
                Position = transform.position;
                break;
                //--------------------------------------------------------------------------------------//
            case 1:

                Vector3 ypos02 = GameObject.Find("Vamp3D").transform.position;

                if (Spone.BatLcnt > 0)
                {
                    if (Vector2.Distance(GameObject.Find("BatL3D(Clone)").transform.position, transform.position) < 6.5f)
                    {
                        ypos02.z = 10;
                        Hockenswitch = true;
                    }
                    else
                    {
                        if (Smoke.trgsSmoke == false)
                        {
                            ypos02.z = 10;
                            Hockenswitch = false;
                        }
                    }
                }
                if (Spone.BatRcnt > 0)
                {
                    if (Vector2.Distance(GameObject.Find("BatR3D(Clone)").transform.position, transform.position) < 6.5f)
                    {
                        ypos02.z = 10;
                        Hockenswitch = true;
                    }
                    else
                    {
                        if (Smoke.trgsSmoke == false)
                        {
                            ypos02.z = 10;
                            Hockenswitch = false;
                        }
                    }
                }

                GameObject.Find("Vamp3D").transform.position = ypos02;
                Position = transform.position;
                break;
            //--------------------------------------------------------------------------------------//
            case 2:

                Vector3 ypos03 = GameObject.Find("Pumpkin3D").transform.position;

                if (Spone.BatLcnt > 0)
                {
                    if (Vector2.Distance(GameObject.Find("BatL3D(Clone)").transform.position, transform.position) < 6.5f)
                    {
                        ypos03.z = 10;
                        Hockenswitch = true;
                    }
                    else
                    {
                        if (Smoke.trgsSmoke == false)
                        {
                            ypos03.z = 10;
                            Hockenswitch = false;
                        }
                    }
                }
                if (Spone.BatRcnt > 0)
                {
                    if (Vector2.Distance(GameObject.Find("BatR3D(Clone)").transform.position, transform.position) < 6.5f)
                    {
                        ypos03.z = 10;
                        Hockenswitch = true;
                    }
                    else
                    {
                        if (Smoke.trgsSmoke == false)
                        {
                            ypos03.z = 10;
                            Hockenswitch = false;
                        }
                    }
                }

                GameObject.Find("Pumpkin3D").transform.position = ypos03;
                Position = transform.position;
                break;
            //--------------------------------------------------------------------------------------//
            case 3:

                Vector3 ypos04 = GameObject.Find("Flower3D").transform.position;

                if (Spone.BatLcnt > 0)
                {
                    if (Vector2.Distance(GameObject.Find("BatL3D(Clone)").transform.position, transform.position) < 6.5f)
                    {
                        ypos04.z = 10;
                        Hockenswitch = true;
                    }
                    else
                    {
                        if (Smoke.trgsSmoke == false)
                        {
                            ypos04.z = 10;
                            Hockenswitch = false;
                        }
                    }
                }
                if (Spone.BatRcnt > 0)
                {
                    if (Vector2.Distance(GameObject.Find("BatR3D(Clone)").transform.position, transform.position) < 6.5f)
                    {
                        ypos04.z = 10;
                        Hockenswitch = true;
                    }
                    else
                    {
                        if (Smoke.trgsSmoke == false)
                        {
                            ypos04.z = 10;
                            Hockenswitch = false;
                        }
                    }
                }

                GameObject.Find("Flower3D").transform.position = ypos04;
                Position = transform.position;
                break;
        }
        //--------------------------------------------------------------------------------------//

    }


    
    void Animation()
    {

        //通常時
        if (idleState == true)
        {
            animator.Play("Idle");
        }

        else
        //オバケが出現したときのやつ
        if (squatState == true)
        {
            animator.Play("Squat");
        }
        
        else
        //火が出たときのやつ
        if(supriseState == true)
        {
            animator.Play("Suprise");
        }

    }



}
