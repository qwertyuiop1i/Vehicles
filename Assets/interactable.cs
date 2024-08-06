using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{
    public float detectRadius = 1.2f;
    [SerializeField]
    public Vector3 offset;
    public vehicle main;
    public Vector3 origin;
    public Quaternion origRot;
 

    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("Creation").GetComponent<vehicle>();

        origin = transform.position;
        origRot = transform.rotation;
    }

    // Update is called once per frame

    public void constructJoints()
    {
        Collider2D[] colliders;

        colliders = Physics2D.OverlapCircleAll(transform.position + offset, detectRadius);

        foreach (Collider2D collider in colliders)
        {

            if (collider.CompareTag("item") && collider.gameObject != gameObject)

            {

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
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position+offset, detectRadius);
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !main.shouldPlay)
        {
            Destroy(gameObject);
        }
    }

}
