using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnObjects : MonoBehaviour
{
    public GameObject[] figures;
    public Transform spawnPoint;

    [SerializeField]
    public GameObject bird;

    private int random;
    public float nextSpawn = 0f;
    public float timeBetweenSpawns = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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
