using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnAgents : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn;
    public GameObject goal;
    public float spawnTimer;
    public int waveSize; 


    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        agent.destination = goal.transform.position;
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWave()
    {
        WaitForSeconds WaveDelay = new WaitForSeconds(0.5f);
        for (int i = 0; i < waveSize; i++)
        {
         GameObject clone = Instantiate(enemy, spawn.transform.position, Quaternion.identity) as GameObject;
            NavMeshAgent agent = clone.GetComponent<NavMeshAgent>();
            agent.destination = goal.transform.position;
            yield return WaveDelay;
        }

        waveSize = Mathf.RoundToInt(waveSize * 1.2f);
        yield return null;

    }
}
