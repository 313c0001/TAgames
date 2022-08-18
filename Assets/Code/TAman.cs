using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAman : MonoBehaviour
{

    string nameset = "";
    public string namaset1 = "";
    public string namaset2 = "";
    public string namaset3 = "";
    public static bool gotit = false;
    public static float hantei = 0;
    public GameObject TAman_first;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gotit==true)
        {
            hantei = 3;
            transform.position = new Vector3(TAman_first.transform.position.x, TAman_first.transform.position.y, -3);
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
