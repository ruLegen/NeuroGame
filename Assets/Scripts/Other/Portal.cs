using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Shader portalShader;
    // Start is called before the first frame update
    public Portal destinationPortal;
    public Camera thisPortalCamera;
    public bool isActive = true;
    public bool isCLipNear = true;
    public float clipCoof  = 1.5f;
    
    void Start()
    {
        // First child should be always camera

        destinationPortal.thisPortalCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        Material portalMaterial = new Material(portalShader);
        portalMaterial.mainTexture = destinationPortal.thisPortalCamera.targetTexture;
        GetComponentInChildren<MeshRenderer>().sharedMaterial= portalMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mainCameraPositionInLocalCoords = destinationPortal.transform.worldToLocalMatrix.MultiplyPoint3x4((Camera.main.transform.position));
        // Inverse left to right and right to left
        mainCameraPositionInLocalCoords.x *= -1;
        mainCameraPositionInLocalCoords.z *= -1;
        thisPortalCamera.transform.localPosition = mainCameraPositionInLocalCoords;

        // Rotation
        Quaternion differense = transform.rotation * Quaternion.Inverse(destinationPortal.transform.rotation * Quaternion.Euler(0,180,0));

        thisPortalCamera.transform.rotation = differense * Camera.main.transform.rotation;
        if(isCLipNear)
            thisPortalCamera.nearClipPlane = mainCameraPositionInLocalCoords.magnitude/clipCoof;
    }

    
    private void OnTriggerStay(Collider other)
    {
        Vector3 objectInLocalSpace = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position);
        if (objectInLocalSpace.z < 0 && isActive && destinationPortal.isActive)
           Teleport(other.transform);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT");
        isActive = true;
        Debug.Log("FRom "+ this.name +"  To" + destinationPortal.name);
    }
    private void Teleport (Transform obj)
    {

        Debug.Log("TElEPOR");
        Debug.Log("FRom "+ this.name +"  To" + destinationPortal.name);

       Vector3 objInLocalPos = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
       objInLocalPos.x *= -1;
       objInLocalPos.z *= -1;
       obj.position = destinationPortal.transform.localToWorldMatrix.MultiplyPoint3x4(objInLocalPos);
      
        // Rotation
        Quaternion difference = destinationPortal.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
        obj.rotation= difference * obj.rotation;

        // Save velocity
        Vector3 newVelocityVector = destinationPortal.transform.forward * obj.GetComponent<Rigidbody>().velocity.magnitude;
        newVelocityVector.y = obj.GetComponent<Rigidbody>().velocity.y;
        obj.GetComponent<Rigidbody>().velocity = newVelocityVector;

        destinationPortal.isActive = false;
    }

}
