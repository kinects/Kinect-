using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    //透過度
    float alpha;

    //透過度をいじる速さ
    float alphaSpd = 0.01f;

    //お化けムーブの速度
    float speed;

    //左右を決めるやつ
    float dir;

    //コサインカーブのやつ
    float cosSpd = 2f;
    float range = 0.2f;

    //色のやつ
    float red, green, blue;
    float red02, green02, blue02;
    float red03, green03, blue03;

    //移動ベクトル
    Vector3 velocity;

    //フェードの切り替え
    private bool trg = false;

    //消え始めるまでの時間
    public float time = 5;



    void Start()
    {
        //オバケの各マテリアルの色を取得
        RendColor();

        //お化けムーブの速さ
        speed = Random.Range(0.0005f, 0.001f);

        //画面中央より左に出現したら右へ向かう右に出現したら左へ
        if(transform.position.x > Camera.main.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0.0f, 135f, 0.0f);
            dir = 0;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0.0f, 45f, 0.0f);
            dir = 1;
        }

        //消え始めるまでの時間
        time = 5;
    }

    void Update()
    {
        //色の設定のやつ
        GetComponent<Renderer>().materials[0].color = new Color(red, green, blue, alpha);
        GetComponent<Renderer>().materials[1].color = new Color(red02, green02, blue02, alpha);
        GetComponent<Renderer>().materials[2].color = new Color(red03, green03, blue03, alpha);
        GetComponent<Renderer>().materials[3].color = new Color(red03, green03, blue03, alpha);
        GetComponent<Renderer>().materials[4].color = new Color(red02, green02, blue02, alpha);

        //ふわふわする移動のやつ
        velocity.y = Mathf.Cos(Time.time * cosSpd) * range;
        
        //座標更新
        transform.position += velocity;

        //透過度の設定のやつ
        Alpha();

        //動きだすやつ
        Direction();

    }

    void Direction()
    {
        
        if (dir == 0)
        {
            //左へ移動
            velocity.x += -speed;
        }
        else
        {
            //右へ移動
            velocity.x += speed;
        }

        //座標更新
        transform.position += velocity;
        
    }

    void Alpha()
    {

        time -= Time.deltaTime;

        //消え始めるまでの時間が0になった時
        if (time <= 0)
        {
            trg = true;
        }

        if (trg == false)
        {
            alpha += alphaSpd;
        }
        else
        {
            alpha -= alphaSpd;
        }

        //見えなくなったら消す
        if(trg == true && alpha <= 0)
        {
            Hocken.Ghostswitch = false;

            //ヨコアリくんのおびえるアニメーションを戻す
            FindObjectOfType<Yokoari>().squatState = false;
            FindObjectOfType<Yokoari>().idleState = true;

            //オバケの存在フラグをオフ
            Destroy(this.gameObject.transform.root.gameObject);
        }

    }

    void RendColor()
    {
        red = GetComponent<Renderer>().materials[0].color.r;
        green = GetComponent<Renderer>().materials[0].color.g;
        blue = GetComponent<Renderer>().materials[0].color.b;

        red02 = GetComponent<Renderer>().materials[1].color.r;
        green02 = GetComponent<Renderer>().materials[1].color.g;
        blue02 = GetComponent<Renderer>().materials[1].color.b;

        red03 = GetComponent<Renderer>().materials[2].color.r;
        green03 = GetComponent<Renderer>().materials[2].color.g;
        blue03 = GetComponent<Renderer>().materials[2].color.b;

    }

    public Vector3 GetDirection()
    {
        return velocity.normalized;
    }
}
