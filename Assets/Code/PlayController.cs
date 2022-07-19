using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    //移動スピード
    public float speed = 3.0f;
    //animation name
    public string upAnime = "upanime";
    public string downAnime = "downanime";
    public string rightAnime = "rightanime";
    public string leftAnime = "leftanime";
    public string deadAnime = "deadanime";

    // current animation and prevent animeation
    string nowAnime = "";
    string oldAnime = "";

    float yokoziku;
    float tateziku;
    public float angleZ = -90.0f; //rotation ;
    Rigidbody2D rbody;
    bool isMoving = false;
    public static int hp = 3;
    public static string gameState;
    bool inDamege =false;
    public bool space = false;



    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        oldAnime = downAnime;
        gameState = "playing";


    }

    // Update is called once per frame
    void Update()

    {
        if(gameState != "playing" || inDamege)
		{
            return;
		}
        if (isMoving == false)
        {
            yokoziku = Input.GetAxisRaw("Horizontal"); //key push horizonal
            tateziku = Input.GetAxisRaw("Vertical");
        }
        // get moving rotation from key pushing
        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + yokoziku, fromPt.y + tateziku);
        angleZ = GetAngle(fromPt, toPt);

        // change animations accoring to the moving rotation
        if (angleZ >= -45 && angleZ <= 45)
        {
            nowAnime = rightAnime;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            nowAnime = upAnime;
        }
        else if (angleZ >= -135 && angleZ <= -45)
        {
            nowAnime = downAnime;
        }
        else
        {
            nowAnime = leftAnime;
        }
        // changeing animation
        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            GetComponent<Animator>().Play(nowAnime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
        }

    }
    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }
        if(inDamege)
		{
            float val = Mathf.Sin(Time.time * 50);
            Debug.Log(val);
            if(val >0)
			{
                gameObject.GetComponent<SpriteRenderer>().enabled = true;

			}
			else
			{
                gameObject.GetComponent<SpriteRenderer>().enabled = false;

            }
            return;
		}
        // changing speed
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            space = true;
        }
        else
        {
            space = false;

        }
        rbody.velocity = new Vector2(yokoziku, tateziku) * speed;

    }
    public void SetAxis(float h, float v)
    {
        tateziku = h;
        yokoziku = v;
        if (yokoziku == 0 && tateziku == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

    }

    // get the ratation from p1 and p2
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
            angle = angleZ;
            
        }
        return angle;
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag =="Enemy") || space)
		{
            GetDamage(collision.gameObject);
		}
	}
	void GetDamage(GameObject enemy)
	{
        if (gameState=="playing")
		{
            hp--;
            Debug.Log("Player HP" + hp);
            if (hp > 0) 
			{
                rbody.velocity = new Vector2(0, 0);
                Vector3 v = (transform.position - enemy.transform.position).normalized;
                inDamege = true;
                Invoke("DamageEnd", 0.25f);

			}
			else
			{
                GameOver();
			}
		}
	}
    void DamageEnd()
	{
        inDamege = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;

	}
    void GameOver()
	{
        Debug.Log("ゲームオーバー！");
        gameState = "gameover";
        GetComponent<CircleCollider2D>().enabled = false;
        rbody.velocity = new Vector2(0, 0);
        rbody.gravityScale = 1;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        GetComponent<Animator>().Play(deadAnime);
        Destroy(gameObject, 1.0f);

	}
}
