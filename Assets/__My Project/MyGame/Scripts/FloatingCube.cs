using UnityEngine;

public class FloatingCube : MonoBehaviour
{

    public float floatSpeed = 2f;       
    public float driftSpeed = 1f;        
    public float destroyDistance = 3f;   
    public float maxHeight = 15f;


    public float randomDriftStrength = 0.3f; 

    private Transform player;
    private Vector3 randomOffset; 

    void Start()
    {
        
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }

        
        randomOffset = new Vector3(
            Random.Range(-1f, 1f),
            0,
            Random.Range(-1f, 1f)
        ).normalized * randomDriftStrength;
    }

    void Update()
    {
        
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime, Space.World);

        
        if (player != null)
        {
            
            Vector3 targetPos = player.position + randomOffset;
            Vector3 direction = (targetPos - transform.position).normalized;

            transform.Translate(direction * driftSpeed * Time.deltaTime, Space.World);

            //float dist = Vector3.Distance(transform.position, player.position);
            //if (dist < destroyDistance)
            //{
            //    Destroy(gameObject);
            //}
        }

        if (transform.position.y > maxHeight)
        {
            Destroy(gameObject);
        }
    }
}