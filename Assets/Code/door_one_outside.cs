using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_one_outside : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inside;
    public bool isCol = false;
    //public static float vec1 = new Vector3(outside.transform.position.x, outside.transform.position.y, -10);

    void Start()
    {
        Debug.Log(isCol);
    }

    // Update is called once per frame
    void Update()
    {

        if ((isCol == true) && (Input.GetKeyDown("z") == true))
        {

            
            Player.doorto = inside;
            Player.door = true;
            
            isCol = false;
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
            Debug.Log(isCol);
        }

    }
}
