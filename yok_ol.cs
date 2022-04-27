using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yok_ol : MonoBehaviour
{

    Transform cocuk;


    void Start()
    {
        cocuk = GameObject.Find("cocuk").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < cocuk.position.z-5.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
