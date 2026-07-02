using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    public GameObject cubePrefab;        
    public float spawnInterval = 0.15f;  
    public int cubesPerSpawn = 20;       


    public float spawnRadius = 10f;      
    public float minY = -10f;            
    public float maxY = -2f;             


    public Vector2 floatSpeedRange = new Vector2(1.5f, 3f);
    public Vector2 driftSpeedRange = new Vector2(0.5f, 1.5f);
    public Vector2 scaleRange = new Vector2(0.3f, 0.8f);

    private Transform player;
    private float timer;

    void Start()
    {
        
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            //SpawnCubes();
        }

        else
        {
            
        }
           
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnCubes();
        }
    }

    void SpawnCubes()
    {
        for (int i = 0; i < cubesPerSpawn; i++)
        {
            
            Vector3 spawnPos;
            if (player != null)
            {
                
                Vector2 circle = Random.insideUnitCircle.normalized * Random.Range(5f, spawnRadius);
                float y = Random.Range(minY, maxY);
                spawnPos = player.position + new Vector3(circle.x, y, circle.y);
            }
            else
            {
               
                spawnPos = new Vector3(
                    Random.Range(-spawnRadius, spawnRadius),
                    Random.Range(minY, maxY),
                    Random.Range(-spawnRadius, spawnRadius)
                );
            }

            GameObject cube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);

           
            FloatingCube fc = cube.GetComponent<FloatingCube>();
            if (fc != null)
            {
                fc.floatSpeed = Random.Range(floatSpeedRange.x, floatSpeedRange.y);
                fc.driftSpeed = Random.Range(driftSpeedRange.x, driftSpeedRange.y);
            }

            
            float s = Random.Range(scaleRange.x, scaleRange.y);
            cube.transform.localScale = Vector3.one * s;

            
            cube.transform.rotation = Random.rotation;
        }
    }
}