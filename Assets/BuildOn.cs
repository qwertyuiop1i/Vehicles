using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOn : MonoBehaviour
{
    public GameObject ?OnMe=null;
    public buildScript bs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !OnMe)
        {
            Instantiate(bs.selected, transform.position, Quaternion.identity);
        }
    }
}
