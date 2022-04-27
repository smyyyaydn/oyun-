using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera_takip : MonoBehaviour
{

    Transform cocuk_pozisyon;
    Vector3 mesafe;
    float hiz = 4.0f;
    void Start()
    {
        cocuk_pozisyon = GameObject.Find("cocuk").transform;
    }

   
    void LateUpdate()
    {
        mesafe = new Vector3(cocuk_pozisyon.position.x, transform.position.y, cocuk_pozisyon.position.z - 1.5f);

        transform.position = Vector3.Lerp(transform.position, mesafe, hiz*Time.deltaTime);

    }
}
