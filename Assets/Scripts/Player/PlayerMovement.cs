using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0F;
    float moveHorizontal, moveVertical;
    public Animator Anim;
    public GameObject Camera;
    private Vector3 movement;
    public void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal <0)
        {
            transform.localScale = new Vector3(1, 1, 1);  
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (moveVertical != 0 || moveHorizontal != 0)
        {
            Debug.Log("The Horizontal is " + moveHorizontal);
            Debug.Log("The Vertical is" + moveVertical);
        }
        
        movement = new Vector3(moveHorizontal, moveVertical, 0);
        Player_Move(movement);
        Camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -3);
    }
    void FixedUpdate()
    {
        this.transform.position +=  movement * speed * Time.deltaTime;
    }
    void Player_Move(Vector3 movement)
    {
        if (Anim != null)
        {
            if (movement.magnitude > 0)
            {
                Anim.SetBool("isMoving", true);
                Anim.SetFloat("horizontal", movement.x);
                Anim.SetFloat("vertical", movement.y);
            }    
            else
            {
                Anim.SetBool("isMoving", false);
            }
        }
    }    
}