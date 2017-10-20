﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (b_time == 5)
            {
                Instantiate(party_balloon, GameObject.Find("Yokoari").transform.position, Quaternion.identity);     //最初のフキダシの出現
            }
            b_time -= Time.deltaTime;
            if (b_time > 0)
            {
                Vector3 b_pos = GameObject.Find("Yokoari").transform.position;  //フキダシのポジション
                b_pos.x += 2;
                b_pos.y += 7;
                b_pos.z -= 3;
                GameObject.Find("party_balloon(Clone)").transform.position = b_pos;
            }
            else
            {
                pa_balloon = false;
                cd_balloon = true;
                b_time = 5;     //フキダシが消えるまでの時間のリセット
                Destroy(GameObject.Find("party_balloon(Clone)"));   //フキダシの削除
            }
        }

        if (cd_balloon == true)
        {
            if (b_time == 5)
            {
                Instantiate(candle_balloon, GameObject.Find("Yokoari").transform.position, Quaternion.identity);     //最初のフキダシの出現
            }
            b_time -= Time.deltaTime;
            if (b_time > 0)
            {
                Vector3 b_pos = GameObject.Find("Yokoari").transform.position;  //フキダシのポジション
                b_pos.x += 2;
                b_pos.y += 7;
                b_pos.z -= 3;
                GameObject.Find("candle_balloon(Clone)").transform.position = b_pos;
            }
            else                    //ここのelse文を条件に変える
            {
                cd_balloon = false;
                pu_balloon = true;
                b_time = 5;     //フキダシが消えるまでの時間のリセット
                Destroy(GameObject.Find("candle_balloon(Clone)"));   //フキダシの削除
            }
        }

        if (pu_balloon == true)
        {
            if (b_time == 5)
            {
                Instantiate(pumpkin_balloon, GameObject.Find("Yokoari").transform.position, Quaternion.identity);     //最初のフキダシの出現
            }
            b_time -= Time.deltaTime;
            if (b_time > 0)
            {
                Vector3 b_pos = GameObject.Find("Yokoari").transform.position;  //フキダシのポジション
                b_pos.x += 2;
                b_pos.y += 7;
                b_pos.z -= 3;
                GameObject.Find("pumpkin_balloon(Clone)").transform.position = b_pos;
            }
            else                    //ここのelse文を条件に変える
            {
                pu_balloon = false;
                cn_balloon = true;
                b_time = 5;     //フキダシが消えるまでの時間のリセット
                Destroy(GameObject.Find("pumpkin_balloon(Clone)"));   //フキダシの削除
            }
        }

        if (cn_balloon == true)
        {
            if (b_time == 5)
            {
                Instantiate(candy_balloon, GameObject.Find("Yokoari").transform.position, Quaternion.identity);     //最初のフキダシの出現
            }
            b_time -= Time.deltaTime;
            if (b_time > 0)
            {
                Vector3 b_pos = GameObject.Find("Yokoari").transform.position;  //フキダシのポジション
                b_pos.x += 2;
                b_pos.y += 7;
                b_pos.z -= 3;
                GameObject.Find("candy_balloon(Clone)").transform.position = b_pos;
            }
            else                    //ここのelse文を条件に変える
            {
                cn_balloon = false;
                b_time = 5;     //フキダシが消えるまでの時間のリセット
                Destroy(GameObject.Find("candy_balloon(Clone)"));   //フキダシの削除
                SceneManager.LoadScene("ResultScene");
            }
        }
    }
}
