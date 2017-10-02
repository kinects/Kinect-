using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{

    public GameObject smoke;

    public static bool trgSmoke = false;
    public static bool trgsSmoke = false;
    private int smokecnt = 0;

    public float time = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trgSmoke == true)
        {
            time++;
            if (time == 10)
            {
                Instantiate(smoke, new Vector3(0, 0, -1), Quaternion.identity);
                smokecnt++;
            }
            if (time == 20)
            {
                Instantiate(smoke, new Vector3(-1f, -1.5f, -1), Quaternion.identity);
                smokecnt++;
                
            }
            if (time == 30)
            {
                Instantiate(smoke, new Vector3(1f, -1.5f, -1), Quaternion.identity);
                smokecnt++;
            }
            if (time == 40)
            {
                Instantiate(smoke, new Vector3(1.3f, 0.7f, -1), Quaternion.identity);
                smokecnt++;
            }
            if (time == 50)
            {
                Instantiate(smoke, new Vector3(-1.3f, 0.7f, -1), Quaternion.identity);
                smokecnt++;
            }
            if (time == 60)
            {
                Instantiate(smoke, new Vector3(0, 3, -1), Quaternion.identity);
                smokecnt++;
            }
            if (time > 120)
            {
                var clones = GameObject.FindGameObjectsWithTag("Smoke");
                foreach (var clone in clones)
                {
                    Destroy(clone);
                }
                trgSmoke = false;
                trgsSmoke = true;
                time = 0;
            }

        }
    }
}
