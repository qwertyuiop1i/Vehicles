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

    public float jointStrength=50f;

    

    // Start is called before the first frame update
    void Start()
    {
        main = GameObject.Find("Creation").GetComponent<vehicle>();

        
    }

    // Update is called once per frame

    public void constructJoints()
    {
        foreach(Transform child in transform)
        {
            child.localPosition = new Vector3(0, 0, 0);
        }

        origin = transform.position;
        
        origRot = transform.rotation;
        Collider2D[] colliders;

        colliders = Physics2D.OverlapCircleAll(transform.position + (Vector3)RotateVector(offset,transform.eulerAngles.z), detectRadius);

        foreach (Collider2D collider in colliders)
        {

            if (collider.gameObject.layer == LayerMask.NameToLayer("item") && collider.gameObject != gameObject)

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
                    FixedJoint2D fj = gameObject.AddComponent<FixedJoint2D>();
                    fj.connectedBody = otherObject.GetComponent<Rigidbody2D>();
                    fj.breakForce = jointStrength;
                    

                }

            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position+ (Vector3)RotateVector(offset, transform.eulerAngles.z), detectRadius);
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !main.shouldPlay)
        {
            Destroy(gameObject);
        }
    }

    Vector2 RotateVector(Vector2 v, float angle)
    {
        float radians = angle * Mathf.Deg2Rad;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 rotatedVector3 = rotation * new Vector3(v.x, v.y, 0);
        return new Vector2(rotatedVector3.x, rotatedVector3.y);
    }

}
