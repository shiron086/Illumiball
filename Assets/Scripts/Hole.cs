using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public string targetTag;
    bool isHolding;

    public bool IsHolding(){
        return isHolding;
    }//isTriggerのコライダーに何かが侵入してきたときに動くメソッド。
    //引数として存在しているのは侵入してきたcollider
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == targetTag)
        {
            isHolding = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            isHolding = false;
        }
    }
    void OnTriggerStay(Collider other)
    //isTriggerなコライダーにものが接触している間中動くメソッド
    {
        Rigidbody r= other.gameObject.GetComponent<Rigidbody>();
        //ゲットコンポ－ネント。Componentと書き、「ｒ」を入れない
        Vector3 direction= other.gameObject.transform.position - transform.position;
        //前に何もなく、最初からtransformにする際、対象のスクリプトがアタッチされているゲームオブジェクトのtransform
        direction.Normalize();

        if(other.gameObject.tag == targetTag)
        {
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f,ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction*80.0f,ForceMode.Acceleration);
        }
    }
}
