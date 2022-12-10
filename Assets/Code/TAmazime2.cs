using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAmazime2 : MonoBehaviour
{

    string nameset = "";
    public string namaset1 = "";
    public string namaset2 = "";
    public string namaset3 = "";
    public string namaset4 = "";
    public string namaset5 = "";
    public string namaset6 = "";
    public static bool gotit = false;

    public static float select = 0;
    // どの選択肢をstudent1イベントで選んだかを格納する
    public static float hantei = 10;
    public static bool eventone_gotit = false;
    public static float eventone_select = 0;
    public static bool WinOff = false;
    //会話を止めたい場合はここをtrueに


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(sensei2.bamen);
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((sensei2.bamen == 1) && (WinOff == false))

        {
            if (sensei2.Groupe == 2)
            {
                hantei = 2;
            }
            if (sensei2.Groupe == 3)
            {
                hantei = 3;
            }
            if (sensei2.Groupe == 4)
            {
                hantei = 4;
            }
        }
         if (sensei2.bamen == 6)

        {
            if (sensei2.Groupe == 2)
            {
                hantei = 5;
            }
            if (sensei2.Groupe == 3)
            {
                hantei = 6;
            }
            if (sensei2.Groupe == 4)
            {
                hantei = 7;
            }
        }
        if (WinOff == true)
        {
            hantei = 10;
        }

        switch (hantei)
        {
            case 2:
                nameset = namaset1;
                break;
            case 3:
                nameset = namaset2;
                break;
            case 4:
                nameset = namaset3;
                break;
            case 5:
                nameset = namaset4;
                break;
            case 6:
                nameset = namaset5;
                break;
            case 7:
                nameset = namaset6;
                break;
            case 10:
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
