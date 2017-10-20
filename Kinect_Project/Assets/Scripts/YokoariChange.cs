using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariChange : MonoBehaviour {

    public GameObject normal;
    public GameObject vamp;
    public GameObject pumpkin;
    public GameObject flower;

    //ヨコアリくんの状態
    public int indexTrg = 0;    //0:通常 1:ヴァンパイア 2:かぼちゃ 3:花

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        switch (indexTrg)
        {
            case 0: 
                normal.SetActive(true);
                vamp.SetActive(false);
                pumpkin.SetActive(false);
                flower.SetActive(false);
                break;

            case 1:
                normal.SetActive(false);
                vamp.SetActive(true);
                pumpkin.SetActive(false);
                flower.SetActive(false);
                break;

            case 2:
                normal.SetActive(false);
                vamp.SetActive(false);
                pumpkin.SetActive(true);
                flower.SetActive(false);
                break;

            case 3:
                normal.SetActive(false);
                vamp.SetActive(false);
                pumpkin.SetActive(false);
                flower.SetActive(true);
                break;

        }
		
	}
}
