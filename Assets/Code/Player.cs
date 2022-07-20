using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public static bool isNomaleMode = true;
    // ゲームが「通常モード」であることを示す。
    bool isMoving = false;

    public float walkSpeed = 3.0f;
    // 歩行速度
    public string up;
    public string down;
    public string right;
    public string left;

    string nowAnime = "";
    string oldAnime = "";
    float yokoziku;
    float tateziku;
    public float kakudo = -90.0f;
    Rigidbody2D rbody;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        oldAnime = down;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            yokoziku = Input.GetAxisRaw("Horizontal"); //key push horizonal
            tateziku = Input.GetAxisRaw("Vertical");
        }
        // get moving rotation from key pushing
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + yokoziku, fromPt.y + tateziku);
        kakudo = GetAngle(fromPt, toPt);

        // change animations accoring to the moving rotation
        if (kakudo >= -45 && kakudo <= 45)
        {
            nowAnime = right;
        }
        else if (kakudo >= 45 && kakudo <= 135)
        {
            nowAnime = up;
        }
        else if (kakudo >= -135 && kakudo <= -45)
        {
            nowAnime = down;
        }
        else
        {
            nowAnime = left;
        }
        // changeing animation
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            GetComponent<Animator>().Play(nowAnime);
        }

        
    }
    void FixedUpdate()
    {
        rbody.velocity =new Vector2(yokoziku, tateziku) *walkSpeed;
    }
    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (tateziku != 0 || yokoziku != 0)
        {
            // during moving, change the rotation
            // caluc p2-p1
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;
            // get the radian with atan
            float rad = Mathf.Atan2(dy, dx);
            // get the rotation from radian
            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            // during stopping , not change
            angle = kakudo;

        }
        return angle;
    }
}
