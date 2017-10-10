using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hocken : MonoBehaviour {

    private SpriteRenderer spRenderer;
    public static bool Hockenswitch = false;
    public static bool DraSwitch = false;
    public static bool Ghostswitch = false;

    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 ypos = GameObject.Find("Yokoari").transform.position;
        Vector3 hpos = GameObject.Find("Hocken").transform.position;

        if (Ghostswitch == true)
        {
            nearObj = serchTag(gameObject, "Ghost");
            if (Vector2.Distance(nearObj.transform.position, transform.position) < 50f)
            {
                ypos.z = 10;
                spRenderer = GameObject.Find("Yokoari").GetComponent<SpriteRenderer>();
                var color = spRenderer.color;
                color.a = 0;
                spRenderer.color = color;
                spRenderer = GameObject.Find("Hocken").GetComponent<SpriteRenderer>();
                color = spRenderer.color;
                color.a = 255;
                spRenderer.color = color;
                Hockenswitch = true;
            }else
            {
                if (Smoke.trgsSmoke == false)
                {
                    ypos.z = 0;
                    spRenderer = GameObject.Find("Yokoari").GetComponent<SpriteRenderer>();
                    var color = spRenderer.color;
                    color.a = 255;
                    spRenderer.color = color;
                    spRenderer = GameObject.Find("Hocken").GetComponent<SpriteRenderer>();
                    color = spRenderer.color;
                    color.a = 0;
                    spRenderer.color = color;
                    Hockenswitch = false;
                }
            }
        }

        hpos = ypos;
        

        GameObject.Find("Yokoari").transform.position = ypos;
        GameObject.Find("Hocken").transform.position = hpos;


    }

    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}
