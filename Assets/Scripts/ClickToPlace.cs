using UnityEngine;
using UnityEngine.AI;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToPlace : MonoBehaviour
{
    public GameObject tower;
    //NavMeshAgent m_Agent;
    RaycastHit m_HitInfo = new RaycastHit();

    void Start()
    {
        //m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
            {
                if (m_HitInfo.collider == GameObject.Find("Ground").GetComponent<BoxCollider>())
                {
                    Vector3Int clonePos = new Vector3Int((int)m_HitInfo.point.x, (int)m_HitInfo.point.y, (int)m_HitInfo.point.z);
                    Instantiate(tower, clonePos, Quaternion.identity);
                }

            }

        }
    }


}
