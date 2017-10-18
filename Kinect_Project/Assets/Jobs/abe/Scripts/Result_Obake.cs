using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_Obake : MonoBehaviour {

    public int cnt = 0;     //お化けの上下を管理する関数

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        cnt++;

        if(cnt <= 30)    //上に移動
        {
            pos.y += 0.01f;
        }
        if(cnt > 30)
        {
            pos.y -= 0.01f;
        }
        if(cnt == 60)
        {
            cnt = 0;
        }

        transform.position = pos;
	}
}
