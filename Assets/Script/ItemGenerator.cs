using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;

    //coinPrefabを入れる
    public GameObject coinPrefab;

    //cornPrefabを入れる
    public GameObject conePrefab;
    private GameObject cone;
    private GameObject coin;
    private GameObject car;

    //スタート地点
    private int startPos = -160;

    //ゴール地点
    private int goalPos = 79;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //unityちゃんを入れる
    private GameObject unitychan;
    private float unityPos=-160;

    // Start is called before the first frame update
    void Start()
    {
        //unitychanコンポーネントを取得
        this.unitychan=GameObject.Find("unitychan");
        //一定の距離ごとにアイテムを生成
        for(int i=startPos;i<-100;i+=15)
        {
            //どのアイテムを出すのかランダムに設定
            int num=Random.Range(1,11);
            if(num<2)
            {
                //コーンをx軸方向にまっすぐに生成
                for(float j=-1;j<=1;j+=0.4f)
                {
                    this.cone=Instantiate(conePrefab)as GameObject;
                    cone.transform.position=new Vector3(4 * j, cone.transform.position.y, i);
                }
            }else
            {
                //レーン毎にアイテムを生成
                for(int j=-1;j<=1;j++)
                {
                    //アイテムの種類を決定
                    int item=Random.Range(1,11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ=Random.Range(-5,6);
                    //60%コイン、30%車、10%なし
                    if(1<=item&&item<=6)
                    {
                        //コインを生成
                        this.coin=Instantiate(coinPrefab)as GameObject;
                        this.coin.transform.position=new Vector3(posRange*j,coin.transform.position.y,i+offsetZ);
                    }else if(7<=item&&item<=9)
                    {
                        //車を生成
                        this.car=Instantiate(carPrefab)as GameObject;
                        this.car.transform.position=new Vector3(posRange*j,car.transform.position.y,i+offsetZ);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance=this.unitychan.transform.position.z-unityPos;
        if(distance>=15&&this.unitychan.transform.position.z<goalPos)
        {
            unityPos=this.unitychan.transform.position.z;
            //どのアイテムを出すのかランダムに設定
            int num=Random.Range(1,11);
            if(num<2)
            {
                //コーンをx軸方向にまっすぐに生成
                for(float j=-1;j<=1;j+=0.4f)
                {
                    this.cone=Instantiate(conePrefab)as GameObject;
                    this.cone.transform.position=
                    new Vector3(4 * j, cone.transform.position.y,this.unitychan.transform.position.z+45);
                }
            }else
            {
                //レーン毎にアイテムを生成
                for(int j=-1;j<=1;j++)
                {
                    //アイテムの種類を決定
                    int item=Random.Range(1,11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ=Random.Range(-5,6);
                    //60%コイン、30%車、10%なし
                    if(1<=item&&item<=6)
                    {
                        //コインを生成
                        this.coin=Instantiate(coinPrefab)as GameObject;
                        this.coin.transform.position=
                        new Vector3(posRange*j,coin.transform.position.y,this.unitychan.transform.position.z+45+offsetZ);
                    }else if(7<=item&&item<=9)
                    {
                        //車を生成
                        this.car=Instantiate(carPrefab)as GameObject;
                        this.car.transform.position=
                        new Vector3(posRange*j,car.transform.position.y,this.unitychan.transform.position.z+45+offsetZ);
                    }
                }
            }
        }
    }
}
