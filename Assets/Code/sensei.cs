using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensei : MonoBehaviour
{
    
    string nameset ="";
    public string namaset1 = "";
    public string namaset2 = "";
    public string namaset3 = "";
    public string namaset4 = "";
    public string namaset5 = "";
    public static float senseihantei = 0;
    public static bool endset = false;
    public float coop = 0;
    public float hyouka1 = 0;
    public float hyouka2 = 0;
    public float hyouka3 = 0;
    public float hyouka4 = 0;
    public float ziritu = 0;


    public float endPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (sensei2.bamen == 0)
        {
            if (TAsintyo_one.gotit == true && TAmazime_one.gotit == true)
            {
                senseihantei = 2;
            }
        }
        else if (sensei2.bamen == 1)
        {
            senseihantei = 3;
        }
       
        else if (sensei2.bamen ==6)
        {
            senseihantei = 4;
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
            case 3:
                nameset = namaset4;
                break;
            case 4:
                nameset = namaset5;
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
