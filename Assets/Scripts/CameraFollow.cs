using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(10f, 10f, -10f);
    public float smoothSpeed = 5f;
   
   void LateUpdate(){
    if (target != null){
        Vector3 desired = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desired, smoothSpeed * Time.deltaTime);
    }
   }
}
