using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class Balloon : MonoBehaviour
{

    public GameObject start_balloon;
    public GameObject party_balloon;
    public GameObject candle_balloon;
    public GameObject pumpkin_balloon;
    public GameObject candy_balloon;

    public float b_time = 5;         //フキダシが消えるまでの時間
    public float c_time = 5;         //フキダシが消えるまでの時間
    public float d_time = 5;         //フキダシが消えるまでの時間
    public float e_time = 5;         //フキダシが消えるまでの時間
    public float f_time = 5;         //フキダシが消えるまでの時間

    public bool s_balloon = false;   //最初のフキダシ

    public bool pa_balloon = false;  //パーティ準備のフキダシ
    public bool cd_balloon = false;  //キャンドルののフキダシ
    public bool pu_balloon = false;  //カボチャのフキダシ
    public bool cn_balloon = false;  //飴のフキダシ

    //時間経過
    public float gameTime = 0;

    // Use this for initialization
    void Start()
    {
        gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Title.Balloonflg == true)
        {
            gameTime += Time.deltaTime;

            //パーティーの吹き出しが出るまでの時間
            if (gameTime >= 0 && s_balloon == true)
            {
                pa_balloon = true;
                s_balloon = false;
            }

            if (s_balloon == false)
            {
                if (b_time == 5)
                {
                    start_balloon.SetActive(true);
                }

                b_time -= Time.deltaTime;

                if (b_time <= 0)
                {
                    s_balloon = true;
                    b_time = 6;     //フキダシが消えるまでの時間のリセット
                }
            }
            if (b_time == 6)
            {
                start_balloon.SetActive(false);   //フキダシの削除
            }

            if (pa_balloon == true)
            {
                if (c_time == 5)
                {
                    party_balloon.SetActive(true);
                }

                c_time -= Time.deltaTime;

                if (c_time <= 0)
                {
                    party_balloon.SetActive(false);
                    pa_balloon = false;
                    cd_balloon = true;
                    c_time = 6;     //フキダシが消えるまでの時間のリセット
                }
            }

            if (cd_balloon == true)
            {
                if (d_time == 5)
                {
                    candle_balloon.SetActive(true);
                }

                d_time -= Time.deltaTime;

                if (d_time <= 4)
                {
                    cd_balloon = false;
                    d_time = 6;     //フキダシが消えるまでの時間のリセット
                                    //candle_balloon.SetActive(false);
                }
            }

            if (pu_balloon == true)
            {
                if (e_time == 5)
                {
                    pumpkin_balloon.SetActive(true);
                }
                e_time -= Time.deltaTime;
                if (e_time <= 4)
                {
                    //ここの文を「両方のロウソクに火が付いたとき」に変える、文の中の内容はそのままでよい
                    pu_balloon = false;
                    e_time = 6;     //フキダシが消えるまでの時間のリセット
                                    //pumpkin_balloon.SetActive(false);
                }
            }

            if (cn_balloon == true)
            {
                if (f_time == 5)
                {
                    candy_balloon.SetActive(true);
                }
                f_time -= Time.deltaTime;
                if (f_time <= 4)
                {

                    //ここの文を「飴を降らせたとき」に変える、文の中の内容はそのままでよい、飴が画面いっぱいになる時間を待つなら時間待つ処理を加える
                    cn_balloon = false;
                    f_time = 6;     //フキダシが消えるまでの時間のリセット
                                    //candy_balloon.SetActive(false);
                                    //SceneManager.LoadScene("ResultScene");
                }

            }
        }
    }
}