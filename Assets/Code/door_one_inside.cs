using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_one_inside : MonoBehaviour
{
    // Start is called before the first frame update
    public  GameObject outside;
    public bool isCol = false;
    //public static float vec1 = new Vector3(outside.transform.position.x, outside.transform.position.y, -10);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isCol ==true && Input.GetKeyDown("z") == true)
        {
            isCol = false;
            Player.doorto = outside;
            Player.door = true;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCol = true;
                       
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCol = false;
            Player.door = false;
        }

    }
} 