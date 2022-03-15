using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetTransfrom;
    private void Start()
    {
        targetTransfrom = PlayerClass.Instance.transform;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(targetTransfrom.position.x, targetTransfrom.position.y, transform.position.z);
    }
}
