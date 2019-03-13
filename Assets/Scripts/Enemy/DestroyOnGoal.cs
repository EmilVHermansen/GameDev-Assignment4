using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGoal : MonoBehaviour
{
    public LifeCount lifecount;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            lifecount.Decrement();
            //GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

            //foreach (GameObject tower in towers)
            //{
            //    tower.GetComponent<ShootProjectile>;
            //}
        }
    }
}
