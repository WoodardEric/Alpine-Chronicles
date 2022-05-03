using UnityEngine;

/*
* Summary: A simple camera that follows a game object
* 
* Member Variables:
* targetTransform - the transform of the object being followed
*/
public class CameraFollow : MonoBehaviour
{
    public Transform targetTransfrom;


    /*
    * Summary: initilize the target transform to the player when a scene starts
    */
    private void Start()
    {
        targetTransfrom = PlayerClass.Instance.transform;
    }


    /*
    * Summary: Updates the camera to the targetTransform on every fixed frame.
    */
    void FixedUpdate()
    {
        transform.position = new Vector3(targetTransfrom.position.x, targetTransfrom.position.y, transform.position.z);
    }
}
