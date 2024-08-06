using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicle : MonoBehaviour
{
    public bool shouldPlay;

    public float cellSize = 2f;

    public GameObject buildPanel;
    public GameObject buildGrid;
    // Start is called before the first frame update
    void Start()
    {
        shouldPlay = false;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toggleFans()
    {

        Transform[] children = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in children)
        {

            ConstantForce2D force = child.GetComponent<ConstantForce2D>();

            if (force != null)
            {
                force.enabled = !force.enabled;
            }
        }
    }
    public void play()
    {
        shouldPlay = !shouldPlay;
        if(shouldPlay)
        {
            buildPanel.SetActive(false);
            buildGrid.SetActive(false);


            Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();

            interactable[] i;
            i = GetComponentsInChildren<interactable>();
            foreach (interactable ib in i)
            {
                ib.constructJoints();
            }

            foreach (Rigidbody2D rb in rbs)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        else
        {
            buildPanel.SetActive(true);
            buildGrid.SetActive(true);
            
            foreach (Transform child in transform)
            {

                interactable childScript = child.GetComponent<interactable>();



                child.position = childScript.origin;
                child.rotation = childScript.origRot;
         
            }

            Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
            foreach(Rigidbody2D rb in rbs)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
            
        }
    }

}
