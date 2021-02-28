using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class AppleMinionCOntroller : MonoBehaviour
{
    private GameObject MeleePlayer, RangedPlayer;
    private GameObject target;
    public float minionSpeed;

    public AtkStruct[] attacks;
    // Start is called before the first frame update
    void Start()
    {
        MeleePlayer = GameObject.FindWithTag("MeleePlayer");
        RangedPlayer = GameObject.FindWithTag("RangedPlayer");
    }

    void FindPrey()
    {
        if(MeleePlayer != null)
        {
            target = MeleePlayer;
        }
        else if( RangedPlayer != null)
        {
            target = RangedPlayer;
        }
    }

    void Update()
    {
        FindPrey();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.transform.position, (minionSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 PreyDir = (target.transform.position - gameObject.transform.position);
        GameObject atk = PlayerController.Attack(attacks[0].atkObj, gameObject.transform.position, PreyDir, attacks[0].atkDistance, gameObject.transform.rotation);
        atk = null;
        Destroy(gameObject);
    }
}