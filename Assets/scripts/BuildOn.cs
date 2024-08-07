using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOn : MonoBehaviour
{
    public GameObject ?OnMe=null;
    public buildScript bs;
    [SerializeField]
    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!OnMe)
            {

                OnMe = Instantiate(bs.selected, transform.position, Quaternion.identity, parent);
            }


        }
    }
}
