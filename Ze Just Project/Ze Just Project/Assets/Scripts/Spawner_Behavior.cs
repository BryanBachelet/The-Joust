using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Behavior : MonoBehaviour
{
    public float tempsEntreSpawn;
    public float tempsEcouleSpawn;
    public GameObject mobPrefab;
    public GameObject lastMobSpawned;
    public int lastSpawnSide; // 0 = Left, 1 = Right

    public int currentWave;
    public int mobPerWave;
    public int mobRemaining;

    public float distanceToSpawn;
    public float hauteurToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        tempsEcouleSpawn = 0;
        mobPerWave = 5;
        mobRemaining = mobPerWave;
    }

    // Update is called once per frame
    void Update()
    {
        if(mobRemaining > 0)
        {
            if(tempsEcouleSpawn < tempsEntreSpawn)
            {
                tempsEcouleSpawn += Time.deltaTime;
            }
            else
            {
                InstantiateMob();
                mobRemaining--;
            }
        }
    }

    public void InstantiateMob()
    {
        lastSpawnSide = Random.Range(0, 2);
        if(lastSpawnSide == 0)
        {
            lastMobSpawned = Instantiate(mobPrefab, transform.position - new Vector3(distanceToSpawn, 0, 0), Quaternion.identity);
            lastMobSpawned.GetComponent<Mob_Behavior>().direction = 0;
        }
        else
        {
            lastMobSpawned = Instantiate(mobPrefab, transform.position - new Vector3(-distanceToSpawn, 0, 0), Quaternion.identity);
            lastMobSpawned.GetComponent<Mob_Behavior>().direction = 1;
        }
        tempsEcouleSpawn = 0;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position - new Vector3(distanceToSpawn, -hauteurToSpawn, 0), transform.position - new Vector3(distanceToSpawn, hauteurToSpawn, 0));
        Gizmos.DrawLine(transform.position - new Vector3(-distanceToSpawn, -hauteurToSpawn, 0), transform.position - new Vector3(-distanceToSpawn, hauteurToSpawn, 0));
    }
}
