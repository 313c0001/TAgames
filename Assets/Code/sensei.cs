using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensei : MonoBehaviour
{
    
    string nameset ="";
    public string namaset1 = "";
    public string namaset2 = "";
    public string namaset3 = "";
    public static float senseihantei = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TAsintyo_one.gotit ==true && TAmazime_one.gotit==true )
        {
            senseihantei = 2;
        }
        
        switch (senseihantei)
        {
            case 0:
                nameset = namaset1;
                break;
            case 1:
                nameset = namaset2;
                break;
            case 2:
                nameset = namaset3;
                break;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Window.boxColision = true;
            Window.boxName = nameset;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Window.boxColision = false;
            Window.boxName = "";
        }

    }
}
