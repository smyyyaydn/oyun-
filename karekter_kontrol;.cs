using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter_kontrol : MonoBehaviour
{

    Rigidbody rigi;

    float ziplama_gucu = 5.0f;
    float kosma_hizi = 2.0f;

    bool sag;
    bool sol;
    bool zipladi = false;

    public GameObject toz;

    Animator anim;

    Transform yol_1;
    Transform yol_2;

    yonetici yonet;

    public GameObject oyun_bitti_paneli;

   public bool miknatis_alindi = false;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        yol_1 = GameObject.Find("yol_1").transform;
        yol_2 = GameObject.Find("yol_2").transform;

        yonet = GameObject.Find("yonetici").GetComponent<yonetici>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "yol_1")
        {
            yol_2.position = new Vector3(yol_2.position.x, yol_2.position.y, yol_1.position.z + 10.0f);
        }
        if (other.gameObject.name == "yol_2")
        {
            yol_1.position = new Vector3(yol_1.position.x, yol_1.position.y, yol_2.position.z + 10.0f);
        }


        if (other.gameObject.tag == "altin")
        {
            other.gameObject.SetActive(false);
            yonet.puan_arttir(10);
        }

        if (other.gameObject.tag == "miknatis")
        {
            other.gameObject.SetActive(false);

            miknatis_alindi = true;

            Invoke("miknatis_iptal", 10.0f);
        }

    }

    void miknatis_iptal()
    {
        miknatis_alindi = false;
    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "engel")
        {
            oyun_bitti_paneli.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }




    private void OnCollisionStay(Collision collision)
    {
        zipladi = false;

        if (toz.activeSelf == false)
        {
            toz.SetActive(true);
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        zipladi = true;

        if (toz.activeSelf == true)
        {
            toz.SetActive(false);
        }
    }


    // -0.5f   -3.0f


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);


            if (parmak.deltaPosition.x > 50.0f)
            {
                sag = true;
                sol = false;
            }


            if (parmak.deltaPosition.x < -50.0f)
            {
                sag = false;
                sol = true;
            }

        }




        if (sag == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-0.5f, transform.position.y, transform.position.z), kosma_hizi * Time.deltaTime);
        }


        if (sol == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-3.0f, transform.position.y, transform.position.z), kosma_hizi * Time.deltaTime);

        }



        transform.Translate(0f, 0f, kosma_hizi * Time.deltaTime);
    }


    public void zipla()
    {
        if (zipladi == false)
        {
            anim.SetTrigger("zipla");
            rigi.velocity = Vector3.zero;
            rigi.velocity = Vector3.up * ziplama_gucu;
        }
    }
}
