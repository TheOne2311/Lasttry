using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0F;
    public Animator Anim;
    public GameObject Camera;
    public int inventorysize = 5;

    private float moveHorizontal, moveVertical;
    private Vector3 movement;
    [SerializeField] Inventory inventoryUI;

    public void Start()
    {
        inventoryUI.InitializeInventory(inventorysize);
    }
    public void Update()
    {
        //How The Player Move
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
        
        movement = new Vector3(moveHorizontal, moveVertical, 0);
        Player_Move(movement);
        
        // The Camera moves with player
        Camera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -3);

        //Inventory Toggle
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
            }
            else
            {
                inventoryUI.Hide();
            }
        }
    }
    // Fixed Update for better collision with Rigidbody
    void FixedUpdate()
    {
        this.transform.position +=  movement * speed * Time.deltaTime;
    }

    // How the is Player Animated
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