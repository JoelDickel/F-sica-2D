using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirandoBoneco : MonoBehaviour
{

    public bool face = false;
    public Transform heroiT;
    public float vel = 2.5f;
    public float force = 6.5f;
    public Rigidbody2D heroiRB;


    //destacar novo jeito de pular

    public bool liberaPulo = true;
    public Transform check;
    public LayerMask oqEChao;
    public float raio = 0.2f;


    void Start()
    {
        heroiT = GetComponent<Transform>();
        heroiRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !face)
        {
            Flip();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && face)
        {
            Flip();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-vel * Time.deltaTime, 0));

        }

        liberaPulo = Physics2D.OverlapCircle(check.position, raio, oqEChao);
       
    }

    void Flip()
    {
        face = !face;


        Vector3 scala = heroiT.localScale;
        scala.x *= -1;
        heroiT.localScale = scala;


    }
    
}
