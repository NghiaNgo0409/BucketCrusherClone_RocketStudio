using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        if(health > 0)
        {
            health--;
        }
        else
        {
            health = 0;
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
