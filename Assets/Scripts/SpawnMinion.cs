using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MinionSpawn1, MinionSpawn2;
    public GameObject AppleMinion;
    public int maxMinion;

    private GameObject[] minions;


    void Start()
    {
        minions = GameObject.FindGameObjectsWithTag("minion");
        Invoke("SpawnMinions", 10.0f);
    }

    bool anyMinions()
    {
        if(minions.Length != 0)
            return true;
        else
            return false; 

    }

    void SpawnMinions()
    {
        if(GameStats.isBattle)
        {
            for(int i = 1; i <= maxMinion/2; i++)
                Instantiate(AppleMinion, MinionSpawn1.transform.position, Quaternion.identity);
            for(int i = 1; i <= maxMinion/2; i++)
                Instantiate(AppleMinion, MinionSpawn2.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        minions = GameObject.FindGameObjectsWithTag("minion");
        if(anyMinions())
        {
            for(int i = 1; i <= maxMinion; i++)
                Instantiate(AppleMinion, MinionSpawn1.transform.position, Quaternion.identity);
            for(int i = 1; i <= maxMinion; i++)
                Instantiate(AppleMinion, MinionSpawn2.transform.position, Quaternion.identity);
        }
    }
}
