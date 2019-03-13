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

    private Ray ray;
    private GameObject clone = null;
    private Collider mouseCollider;
    private TowerInfo ti;

    void Start()
    {
        cc = gameObject.GetComponent<CurrencyController>();
        //m_Agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Place/Buy
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo, Mathf.Infinity, 1 << 11))
            {
                mouseCollider = m_HitInfo.collider;
                if (mouseCollider == GameObject.Find("Ground").GetComponent<BoxCollider>())
                {
                    ti = tower.GetComponent<TowerInfo>();
                    if (cc.money >= ti.price)
                    {
                        Vector3Int clonePos = new Vector3Int((int)m_HitInfo.point.x, (int)m_HitInfo.point.y, (int)m_HitInfo.point.z);
                        clone = Instantiate(tower, clonePos, Quaternion.identity);
                        cc.SubtractMoney(ti.price);
                        StartCoroutine(CheckPath(clone));
                    }

                }
            }
        }


        //Sell tower

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, 1 << 10);
            foreach (var hit in hits)
            {


                if (hit.collider.GetType() == typeof(BoxCollider))
                {
                    ti = hit.collider.gameObject.GetComponent<TowerInfo>();
                    cc.SellTower(ti.price);
                    Destroy(hit.collider.gameObject);
                }

            }

        }

        //Upgrade
        if (Input.GetKeyDown(KeyCode.U))
        {
            RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, 1 << 10);

            foreach (var hit in hits)
            {

                ti = hit.collider.gameObject.GetComponent<TowerInfo>();
                if (hit.collider.GetType() == typeof(BoxCollider) && ti.price * 1.2f < cc.money)
                {
                    if (ti.LevelUp())
                    {

                        cc.SubtractMoney(Mathf.RoundToInt(ti.price * 1.2f));
                        ti.UpdatePrice(Mathf.RoundToInt(ti.price * 1.2f));
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
