using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToPlace : MonoBehaviour
{
    public GameObject tower;
    //NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();
    CurrencyController cc;
    public int price;

    void Start()
    {
        cc = gameObject.GetComponent<CurrencyController>();
        //m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        GameObject clone = null;
        if (Input.GetMouseButtonDown(0))
        {
            if (cc.money >= price)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo, Mathf.Infinity, 1 << 11))
                {
                    if (m_HitInfo.collider == GameObject.Find("Ground").GetComponent<BoxCollider>() || m_HitInfo.collider == GameObject.Find("Tower").GetComponent<BoxCollider>())
                    {
                        Vector3Int clonePos = new Vector3Int((int)m_HitInfo.point.x, (int)m_HitInfo.point.y, (int)m_HitInfo.point.z);
                        clone = Instantiate(tower, clonePos, Quaternion.identity);
                        cc.SubtractMoney(price);
                        StartCoroutine(CheckPath(clone));
                    }

                }
            }
        }
    }

    IEnumerator CheckPath(GameObject clone)
    {
        yield return new WaitForSeconds(0.01f);
            if (GameObject.Find("GameController").GetComponent<SpawnAgents>().CheckPath())
            {
                Destroy(clone, 0.5f);
            }
        yield return null;
    }
}
