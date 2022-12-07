using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vilao : MonoBehaviour
{

    public float vel = 1.0f;
    public bool libera = false;
    public float distancia;
    public Transform man;
    public bool face = true;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(this.transform.position, man.transform.position);


        //flip
        if((man.transform.position.x < this.transform.position.x) && !face) 
        {

            Flip();

        }
        else if((man.transform.position.x > this.transform.position.x) && face)
        {
            Flip();
        }

        if((libera == true) && distancia > 2.8f)
        {
            if (man.transform.position.x < this.transform.position.x)
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
            }
            else if (man.transform.position.x > this.transform.position.x)
            {
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
            }
        }

        
    }
    void Flip()
    {
        face = !face;


        Vector3 scala = this.transform.localScale;
        scala.x *= -1;
        this.transform.localScale = scala;

    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            libera = true;
        }
    }

}
