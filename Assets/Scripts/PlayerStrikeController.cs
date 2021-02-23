using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStrikeController : MonoBehaviour
{
    public float timer;
    public Vector2 angle;
    private Rigidbody2D rb;
    private Transform pos;
    private PolygonCollider2D AttkCollider;
    private GameObject MeleePlayer;
    private GameObject RangedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        pos = gameObject.GetComponent<Transform>();
        AttkCollider = gameObject.GetComponent<PolygonCollider2D>();
        MeleePlayer = GameObject.FindWithTag("MeleePlayer");
        RangedPlayer = GameObject.FindWithTag("RangedPlayer");
        angle = new Vector2(pos.right.x, pos.right.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer < 0)
        {
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;
    }

    void Update()
    {
        if(gameObject.tag == "Shield" && AttkCollider.bounds.Contains(MeleePlayer.transform.position))
        {
            gameObject.transform.position = MeleePlayer.transform.position;
        }
        else if(gameObject.tag == "Shield" && AttkCollider.bounds.Contains(RangedPlayer.transform.position))
        {
            gameObject.transform.position = MeleePlayer.transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name);
        if(collision.gameObject.layer == 9 && gameObject.name == "BossAttack(Clone)")
        {
            Debug.Log("This is the Boss basic attack damaging a player.");
            collision.gameObject.GetComponent<PlayerController>().ChangeHealth(1,"-");
        }
    }
}
