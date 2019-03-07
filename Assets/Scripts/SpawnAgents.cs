using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class SpawnAgents : MonoBehaviour
{
    public GameObject enemy;
    public GameObject spawn;
    public GameObject goal;
    public float spawnTimer;
    public int waveSize;
    public int waveNumber;
    public TextMeshProUGUI waveCounter;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 0;
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void updateText()
    {
        waveCounter.text = "Wave: " + waveNumber;
    }

    public bool CheckPath()
    {
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(spawn.transform.position, goal.transform.position, NavMesh.AllAreas, path);
        if(path.status == NavMeshPathStatus.PathComplete)
        {
            return false;
        }
        return true;
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        updateText();
        WaitForSeconds WaveDelay = new WaitForSeconds(0.5f);
        for (int i = 0; i < waveSize; i++)
        {
            GameObject clone = Instantiate(enemy, spawn.transform.position, Quaternion.identity) as GameObject;
            agent = clone.GetComponent<NavMeshAgent>();
            agent.destination = goal.transform.position;
            yield return WaveDelay;
        }
        while (true)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                StartCoroutine(NextWave());
                break;
            }
            yield return null;
        }

        yield return null;

    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(5f);
        waveSize = Mathf.RoundToInt(waveSize * 1.2f);
        StartCoroutine(SpawnWave());

        yield return null;
    }
}
