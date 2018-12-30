using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //unityちゃんオブジェクト
    private GameObject unitychan;
    //unityちゃんとカメラの距離
    private float difference;
    // Start is called before the first frame update
    void Start()
    {
        //unityちゃんオブジェクトを取得
        this.unitychan=GameObject.Find("unitychan");
        //カメラとunityちゃんの位置(z座標)の差
        this.difference=this.unitychan.transform.position.z-this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position=new Vector3(0,6,this.unitychan.transform.position.z-this.difference);
    }
}

