using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour


{
    public static bool boxColision = false;
    public static string boxName = "";
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("utageContorol");
    }

    // Update is called once per frame
    void Update()
    {
        if (boxColision == true)
        {
            Debug.Log(boxColision);
            //utaStart = new AdvEngine.JumpScenario("startstep");
            ball.GetComponent<SampleAdvEngineController>().JumpScenario("testone");
            boxColision = false;

        }

    }
}
