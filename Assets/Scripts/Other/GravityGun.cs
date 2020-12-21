using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GravityGun : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance = 300f;
    public float capturedDistance = 0;
    public Rigidbody capturedRigidBody = null;
    public float torqueCooficient = 0.03f;
    public float speedRate= 20f;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(capturedRigidBody == null)
            {
                Ray ray = GetRayToScreenCenter();
                Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.blue, 0.01f);

                RaycastHit hit;
                if(Physics.Raycast(ray,out hit,maxDistance))
                {
                    // If rigidBody is exist
                    if(hit.rigidbody != null)
                    {
                        capturedRigidBody = hit.rigidbody;
                        capturedDistance = Vector3.Distance(ray.origin, hit.point);

                    }
                }
            }
        }
        else
        {
            if (capturedRigidBody != null)
            {
                capturedRigidBody = null;
            }
            // No need calcute after
            return;
        }
    }
    private void FixedUpdate()
    {
        if(capturedRigidBody)
        {
            Ray ray = GetRayToScreenCenter();
            Vector3 pointOnObject = ray.GetPoint(capturedDistance);
            Vector3 toDestination = (pointOnObject - capturedRigidBody.transform.position);
            // Calculate force
            Vector3 force = toDestination/speedRate/ Time.fixedDeltaTime;
            capturedRigidBody.velocity = Vector3.zero;
            capturedRigidBody.AddForce(force, ForceMode.VelocityChange);
            capturedRigidBody.AddTorque(new Vector3(Random.Range(-1,1), Random.Range(-1, 1), Random.Range(-1, 1)) * Random.Range(0,torqueCooficient));
        }
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        //{
        //    GameObject gameObject = hit.collider.gameObject;
        //    gameObject.GetComponent<Interactable>().onInteract(hit.point);
        //    GetComponent<LineRenderer>().SetPositions(new Vector3[] { ray.origin, ray.direction * 100 });
        //}
    }

    public void Disable()
    {
        capturedRigidBody = null;
        this.enabled = false;
    }
    Ray GetRayToScreenCenter()
    {
        return GetComponent<Camera>().ViewportPointToRay(Vector3.one * 0.5f);

    }
}
