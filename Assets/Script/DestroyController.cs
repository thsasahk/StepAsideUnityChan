using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    private GameObject unityChan;

    void Start()
    {
        this.unityChan=GameObject.Find("unitychan");
    }

    void Update()
    {
        if(transform.position.z<this.unityChan.transform.position.z-10)
        {
            Destroy(gameObject);
        }
    }
}