using UnityEngine;
using UnityEngine.AI;

public class CameraFollow : MonoBehaviour
{
    GameObject Player;
    public Vector3 Camera_Position_From_Character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Player == null) //if player is not found
        {
            Player = GameObject.FindWithTag("Player");
        }
        Camera_Position_From_Character = new Vector3(0, 3, 5);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, Player.transform.position + Camera_Position_From_Character, 0.4f);
        gameObject.transform.LookAt(Player.transform);
        gameObject.transform.TransformDirection(Vector3.forward);
    }
}
