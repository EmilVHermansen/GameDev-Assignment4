using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    public int price;
    public int lvl;
    public int damage;
    private SendGameMessage sgm;
    private Material m_Material;


    // Start is called before the first frame update
    void Start()
    {
        sgm = GameObject.Find("Game message").GetComponent<SendGameMessage>();
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool LevelUp()
    {
        

        switch (lvl)
        {
            case 1:
                IncreaseDamage(Mathf.RoundToInt(damage * 1.2f));
                
                transform.localScale += new Vector3(0.2f, 0f, 0.2f);
                m_Material.color = Color.blue;
                lvl++;
                return true;

            case 2:
                IncreaseDamage(Mathf.RoundToInt(damage * 1.2f));
               
                transform.localScale += new Vector3(0.2f, 0f, 0.2f);
                m_Material.color = Color.black;
                lvl++;
                return true;
            default:
                return false;
                
        }

    }

    public void IncreaseDamage(int amount)
    {
        damage += amount;
    }

    public void UpdatePrice(int amount)
    {
        price += amount;
    }
}
