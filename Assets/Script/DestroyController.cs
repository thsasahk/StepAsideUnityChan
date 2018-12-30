using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        //オブジェクトの破棄
        if(other.gameObject.tag=="CarTag"||other.gameObject.tag=="CoinTag"||other.gameObject.tag=="TrafficConeTag")
        {
            Destroy(other.gameObject);
        }
    }
}