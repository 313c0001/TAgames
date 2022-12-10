using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensei2 : MonoBehaviour
{

    string nameset = "";
    public string namaset1 = "";
    public string namaset2 = "";
    public string namaset3 = "";
    public string namaset4 = "";
    public static bool gotit = false;
    public static float hantei = 0;
    public static bool oneday2ndON = false;
    public static bool oneday2nd = false;
    public static float bamen = 0;
    public static float Groupe = 0;
    public static bool houkoku = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(oneday2ndON);
    }

    // Update is called once per frame
    void Update()
    {

        if (oneday2ndON == true)
        {
            oneday2ndON = false;
            oneday2nd = true;
            hantei = 1;            
            bamen = 1;
           
        }
        if (bamen == 3)
        {
            hantei = 2;
        }
        if (bamen == 4)
        {
            hantei = 3;
        }
        if(bamen ==10)
        {
            hantei = 10;
        }
        switch (hantei)
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
            case 10:
                nameset = namaset2;
                break;
            case 20:
                nameset = null;
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
