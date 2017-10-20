using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    public GameObject start_balloon;
    public GameObject party_balloon;
    public GameObject candle_balloon;
    public GameObject pumpkin_balloon;
    public GameObject candy_balloon;

    public float b_time = 5;         //フキダシが消えるまでの時間

    public bool s_balloon = false;   //最初のフキダシ
    public static bool pa_balloon = false;  //パーティ準備のフキダシ
    public bool cd_balloon = false;  //キャンドルののフキダシ
    public bool pu_balloon = false;  //カボチャのフキダシ
    public bool cn_balloon = false;  //飴のフキダシ

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (s_balloon == false)
        {
            if(b_time == 5)
            {
                Instantiate(start_balloon, GameObject.Find("Yokoari").transform.position, Quaternion.identity);     //最初のフキダシの出現
            }
            b_time -= Time.deltaTime;
            if (b_time > 0)
            {
                Vector3 b_pos = GameObject.Find("Yokoari").transform.position;  //フキダシのポジション
                b_pos.x += 2;
                b_pos.y += 7;
                b_pos.z -= 3;
                GameObject.Find("start_balloon(Clone)").transform.position = b_pos;
            }else
            {
                s_balloon = true;
                b_time = 5;     //フキダシが消えるまでの時間のリセット
            }
        }else
        {
            Destroy(GameObject.Find("start_balloon(Clone)"));   //フキダシの削除
        }

        if(pa_balloon == true)
        {

        }
	}
}
