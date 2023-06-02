using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coin;
    public Transform[] spawnPos;

    private GameObject spawnedCoin;
    private float spawnTimer = 0f;

    void Update()
    {
        SpawnCoin();
        DestroyCoin();
    }

    private void SpawnCoin()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= 10f && spawnedCoin != null)
        {
            Destroy(spawnedCoin);
            spawnedCoin = null;
            spawnTimer = 0f;
        }

        if (spawnedCoin == null)
        {
            int rnd = Random.Range(0, spawnPos.Length);
            spawnedCoin = Instantiate(coin, spawnPos[rnd].transform.position, Quaternion.identity);
        }
    }

    private void DestroyCoin()
    {
        if (spawnedCoin != null && spawnedCoin.transform.position.y < -10f)
        {
            Destroy(spawnedCoin);
            spawnedCoin = null;
            spawnTimer = 0f;
        }
    }
}

