using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBreaker : MonoBehaviour
{
    List<GameObject> cubeBrokenList;
    bool isCrushing;
    // Start is called before the first frame update
    void Start()
    {
        cubeBrokenList = new List<GameObject>();
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public int GetListCount()
    {
        return cubeBrokenList.Count;
    }

    public void ClearListCount()
    {
        cubeBrokenList.Clear();
    }

    public bool IsCrushing()
    {
        return isCrushing;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent<Block>(out Block block))
        {
            if (block.GetHealth() > 0)
            {
                isCrushing = true;
                block.Damage();
            }
            else
            {
                isCrushing = false;
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.GetComponent<Rigidbody>().useGravity = true;
                if(!cubeBrokenList.Contains(other.gameObject))
                {
                    cubeBrokenList.Add(other.gameObject);
                }
            }
        }
        else
        {
            isCrushing = false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(TryGetComponent<Block>(out Block block))
    //    {
    //        if (block.GetHealth() > 0)
    //        {
    //            block.Damage();
    //        }
    //        else
    //        {
    //            collision.gameObject.AddComponent<Rigidbody>();
    //        }
    //    }
    //}
}
