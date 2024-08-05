using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public float detectRadius = 1.2f;
    public vehicle main;

 

    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("Creation").GetComponent<vehicle>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!main.shouldPlay)
        {
            Collider2D[] colliders;

            colliders = Physics2D.OverlapCircleAll(transform.position, detectRadius);

            foreach (Collider2D collider in colliders)
            {
                
                if (collider.CompareTag("item")&&collider.gameObject!=gameObject)

                {
                    Debug.Log("a");
                    GameObject otherObject = collider.gameObject;

                    FixedJoint2D[] myJoints = GetComponents<FixedJoint2D>();

                    bool jointExists = false;
                    foreach (FixedJoint2D joint in myJoints)
                    {
                        if (joint.connectedBody == otherObject.GetComponent<Rigidbody2D>())
                        {
                            jointExists = true;
                            break;
                        }
                    }

                    if (!jointExists)
                    {
                        gameObject.AddComponent<FixedJoint2D>().connectedBody = otherObject.GetComponent<Rigidbody2D>();


                    }

                }
            }

        }
    }

}
