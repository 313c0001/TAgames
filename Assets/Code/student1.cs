using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class student1 : MonoBehaviour
{

    string nameset = "";
    public string namaset1 = "";
    public string namaset2 = "";
    public string namaset3 = "";
    public static bool gotit = false;

    public static float select = 0;
    // どの選択肢をstudent1イベントで選んだかを格納する
    public static float hantei = 0;
    public GameObject playerPosition;
    public static bool eventone_gotit =false;
    public static float eventone_select = 0;
    public static float eventtwo_select = 0;
    public static float eventtwo_san = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (sensei2.bamen ==1)
        {
            hantei = 1;
        }
        else if (sensei2.bamen ==4)
        {
            hantei = 2;
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
