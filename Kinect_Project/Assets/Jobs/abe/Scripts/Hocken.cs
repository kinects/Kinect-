using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hocken : MonoBehaviour {

    private Vector2 Position;
    private SpriteRenderer spRenderer;
    public static bool Hockenswitch = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 ypos = GameObject.Find("Yokoari").transform.position;

        if (Spone.BatLcnt > 0)
        {
            if (Vector2.Distance(GameObject.Find("BatL(Clone)").transform.position, transform.position) < 6.5f)
            {
                ypos.z = 1;
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
        if (Spone.BatRcnt > 0)
        {
            if (Vector2.Distance(GameObject.Find("BatR(Clone)").transform.position, transform.position) < 6.5f)
            {
                ypos.z = 1;
                spRenderer = GameObject.Find("Yokoari").GetComponent<SpriteRenderer>();
                var color = spRenderer.color;
                color.a = 0;
                spRenderer.color = color;
                spRenderer = GameObject.Find("Hocken").GetComponent<SpriteRenderer>();
                color = spRenderer.color;
                color.a = 255;
                spRenderer.color = color;
                Hockenswitch = true;
            }
            else
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

        GameObject.Find("Yokoari").transform.position = ypos;
        Position = transform.position;


    }
}
