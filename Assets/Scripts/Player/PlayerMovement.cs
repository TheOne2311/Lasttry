using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        transform.position = transform.position + movement * speed * Time.deltaTime;
    }
}