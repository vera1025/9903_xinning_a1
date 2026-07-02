using UnityEngine;

public class WallMover : MonoBehaviour
{
    public Transform target;      
    public float moveSpeed = 1f;   
    public float stopDistance = 2f; 

    void Update()
    {
        if (target == null) return;

        
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0; 
        direction.z = 0;


        float currentDistance = Vector3.Distance(transform.position, target.position);


        if (transform.gameObject.name.Contains("Left") && transform.position.x > 5)
        {

            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }

        if (transform.gameObject.name.Contains("Right") && transform.position.x < -5)
        {

            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}