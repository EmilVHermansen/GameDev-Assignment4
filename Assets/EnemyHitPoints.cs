using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoints : MonoBehaviour
{
    public int hp;
    CurrencyController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.Find("GameController").GetComponent<CurrencyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            hp -= collision.gameObject.GetComponentInParent<TowerInfo>().damage;
            Destroy(collision.gameObject);
            if(hp <= 0)
            {
                Destroy(gameObject);
                cc.AddMoney();
            }
        }
    }
}
