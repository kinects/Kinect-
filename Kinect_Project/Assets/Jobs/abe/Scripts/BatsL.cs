﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kinect = Windows.Kinect;

public class BatsL : MonoBehaviour
{

    private float rad;
    public Vector2 speed = new Vector2(0.2f, 0.2f);
    private Vector3 Position;
    public bool side = true;

    private SpriteRenderer spRenderer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rad = Mathf.Atan2(
         BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].y - transform.position.y,
         BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft].x - transform.position.x);

        Position = transform.position;

        if (Vector2.Distance(BodySourceView.bodyPos[(int)Kinect.JointType.HandLeft], transform.position) < 1.5f)
        {
            Position.x += speed.x * Mathf.Cos(rad);
            Position.y += speed.y * Mathf.Sin(rad);
        }
        else
        {
            if (side == false)
            {
                Position.x -= 0.1f;
            }
            else
            {
                Position.x += 0.1f;
            }

            if (Position.x < -5)
            {
                side = true;
            }
            if (Position.x > 5)
            {
                side = false;
            }
        }

        // 現在の位置に加算減算を行ったPositionを代入する
        transform.position = Position;

        if (Smoke.trgsSmoke == true)
        {
            Spone.BatLcnt = 0;
            Smoke.trgsSmoke = false;
            FindObjectOfType<YokoariChange>().indexTrg = 1;
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Yokoari")
        {
            Smoke.trgSmoke = true;
            Position.z -= 10;
            transform.position = Position;
        }
    }
}
