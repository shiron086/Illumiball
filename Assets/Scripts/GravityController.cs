using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    const float Gravity = 9.81f;//重力加速度定数

    public float gravityScale = 1.0f;//重力のスケールパラメーター

    // Update is called once per frame
    void Update()
    {
        Vector3 vector =new Vector3();//重力ベクトルの初期化。XYZの座標を持つ

        vector.x= Input.GetAxis("Horizontal");//x軸の移動。x軸に操作を与える
        vector.z= Input.GetAxis("Vertical");//y軸の移動。y軸に操作を与える

        if(Input.GetKey("z")){//以下、高さ方向入力の取得。zキーを押している間は浮遊するようにする。浮遊感与える
            vector.y=1.0f;
        }
        else{
            vector.y=-1.0f;
        }
        Physics.gravity=Gravity*vector.normalized*gravityScale;
        //重力の変更。nomalizedは長さを1にする(方向キー同時押しで重力が梅雨くなることを防止するためのもの)
    }
}
