using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpController : MonoBehaviour
{
    public float incrementHealth;

    private GameObject MeleePlayer, RangedPlayer, Map;
    private PlayerController meleeController, rangedController;
    private SpawnItems itemSpawner;


    
    void Start()
    {
        Map = GameObject.FindWithTag("Map");
        MeleePlayer = GameObject.FindWithTag("MeleePlayer");
        RangedPlayer = GameObject.FindWithTag("RangedPlayer");
        meleeController = MeleePlayer.gameObject.GetComponent<PlayerController>();
        rangedController = RangedPlayer.gameObject.GetComponent<PlayerController>();
        itemSpawner = Map.GetComponent<SpawnItems>();
    }

    void Update()
    {
        //Debug.Log("Melee Health" + meleeController.playerHP);
        //Debug.Log("Ranged Health" + rangedController.playerHP);
        if(meleeController.playerHP == meleeController.MaxHP)
            Physics2D.IgnoreLayerCollision(20, 15, true);
    
        else if(meleeController.playerHP != meleeController.MaxHP)
        {
            Physics2D.IgnoreLayerCollision(20, 15, false);
        }

        if(rangedController.playerHP == rangedController.MaxHP)
        {
            Physics2D.IgnoreLayerCollision(19, 15, true);
        }
        else if(rangedController.playerHP != rangedController.MaxHP)
        {
            Physics2D.IgnoreLayerCollision(19, 15, false);
        }

    }
 


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameStats.isBattle && collision.gameObject.GetComponent<PlayerController>().playerHP != meleeController.MaxHP)
        {
            collision.gameObject.GetComponent<PlayerController>().playerHP += incrementHealth;
            itemSpawner.items -= 1;
            Destroy(gameObject);
        }
    }
}
