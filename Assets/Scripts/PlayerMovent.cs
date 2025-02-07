using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
        if(moveDirection != Vector3.zero){
            transform.forward = moveDirection;
        }
    }
}
