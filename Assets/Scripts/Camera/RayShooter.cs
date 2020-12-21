using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance = 300f;
    private GameObject lastObject = null;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = GetRayToScreenCenter();
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                // If hitted new object
                if (lastObject != null && lastObject != hit.collider.gameObject)
                {
                    lastObject.GetComponent<Interactable>().onEndInteract(gameObject);
                }
                else
                {
                    GameObject hittedObject = hit.collider.gameObject;
                    hittedObject.GetComponent<Interactable>().onInteract(gameObject);
                    lastObject = hit.collider.gameObject;
                }
            }
            else
            {
                lastObject.GetComponent<Interactable>().onEndInteract(gameObject);
            }
        }
        else
        {
            if(lastObject != null)
            {
                lastObject.GetComponent<Interactable>().onEndInteract(gameObject);
                lastObject = null;
            }

        }

    }
    Ray GetRayToScreenCenter()
    {
        return GetComponent<Camera>().ViewportPointToRay(Vector3.one * 0.5f);

    }
}
