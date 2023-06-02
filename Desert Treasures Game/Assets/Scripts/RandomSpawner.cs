using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] figures;
    public Transform spawnPoint;

    [SerializeField]
    public GameObject bird;

    private int random;
    public float nextSpawn = 5f;
    public float timeBetweenSpawns = 2f;

    void Update()
    {
        if (Time.time > nextSpawn ) 
        { 
            random = Random.Range(0, figures.Length);
            var obj = Instantiate(figures[random], spawnPoint.transform.position, Quaternion.identity, bird.transform);
            obj.GetComponent<Rigidbody2D>().simulated = false;
            nextSpawn = Time.time + timeBetweenSpawns;
        }
    }
}
