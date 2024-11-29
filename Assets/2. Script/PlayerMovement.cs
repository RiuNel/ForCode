using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float Move_Speed = 5.0f; //Move Speed
    float Jump_Force = 5.0f; //Jump Force
    float Move_x,Move_y; //Move Value
    bool Is_Ground = false; //Grouned Check
    Ray ray;
    RaycastHit hit;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        if(Input.GetKey(KeyCode.K))
        {
            CheckObject();
        }
    }
    private void Move()
    {
        //Move Value the player
        Move_x = Input.GetAxisRaw("Horizontal") * Move_Speed * Time.deltaTime;
        Move_y = Input.GetAxisRaw("Vertical") * Move_Speed * Time.deltaTime;

        //Move the player
        gameObject.transform.position -= new Vector3(Move_x, 0, Move_y);
    }
    private void Jump()
    {
        if (Is_Ground && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Jump_Force, ForceMode.Impulse);
            Is_Ground = false;
        }
    }
    private void CheckObject()
    {
        var Object_in_layer = Physics.SphereCastAll(ray.origin, 5.0f, Vector3.up, 10.0f);

        foreach (var Object in Object_in_layer)
        {
            Debug.Log(Object.collider.tag);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Is_Ground = true;
        }
        
    }
}
