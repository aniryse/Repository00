using UnityEngine;
using System.Collections;

public class LookCrosshair : MonoBehaviour {

    private float oldX = 0;
    private float oldY = 0;
    private float oldZ = 0;
   
    void Update()
    {
        Transform camera = Camera.main.transform;
        
        Ray ray;
        RaycastHit hit;
        GameObject hitObject;

        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100.0f);
        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        //only process if the camera position changes.
        if (newPosition(camera))
        {
            //Debug.Log("lastCameraPosition: " + lastCamera + "this Camera Position: " + camera.position);
            if (Physics.Raycast(ray, out hit))
            {
                             
                    hitObject = hit.collider.gameObject;
                   // Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                    transform.position = hit.point;
                
            }
        }
       
    }

    //checks the position of the current camera versus the old cameras position
    // if the camera poistion is the same then returns false;
    //if the position is new, false is returned and the old camera position is given the new camera position.
    bool newPosition(Transform current)
    {
        float currentX = current.position.x;
        float currentY = current.position.y;
        float currentZ = current.position.z;
        //Debug.Log("old X,Y,Z: " + oldX.ToString("F2") + ", " + oldY.ToString("F2") + ", " + oldZ.ToString("F2")
           // + " current X, Y, Z: " + currentX.ToString("F2") + ", " + currentY.ToString("F2") + ", " + currentZ.ToString("F2"));

        //if the camera hasn't moved
        if ((currentX == oldX) && (currentY == oldY) && (currentZ == oldZ))
        {
            //Debug.Log("equal");
            return false;
        }
        //otherwise the camera has moved.
        else
        {
            //Debug.Log("not equal");
            oldX = currentX;
            oldY = currentY;
            oldZ = currentZ;
            return true;
        }
    }
}
