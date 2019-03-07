using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    public int damage;
    //public List<Collider> hitColliders = new List<Collider>();
    Collider[] hitColliders;
    public int radius;
    public float rateOfFire;
    public int bulletspeed;

    // Start is called before the first frame update
    void Start()
    {
        hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask: 1 << 9);
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        hitColliders = Physics.OverlapSphere(transform.position, radius, 1<<9);
    }

    IEnumerator Shoot()
    {

        WaitForSeconds rof = new WaitForSeconds(rateOfFire);
        while (true)
        {
            if (hitColliders.Length > 0)
            {
                GameObject firstEnemy = hitColliders[0].gameObject;

                print(hitColliders.Length);
                print(firstEnemy.transform.position);


                GameObject clone = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation,transform);
                clone.transform.LookAt(firstEnemy.transform.position);
                clone.GetComponent<Rigidbody>().AddForce((firstEnemy.transform.position - clone.transform.position) * bulletspeed);
            }
            yield return rof;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy" && !hitColliders.Contains(other))
    //    {
    //        hitColliders.Add(other);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy" && hitColliders.Contains(other))
    //    {
    //        hitColliders.Remove(other);
    //    }
    //}

}
