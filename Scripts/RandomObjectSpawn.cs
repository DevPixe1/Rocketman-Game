using UnityEngine;

public class RandomObjectSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] Objects;

    [SerializeField] GameObject[] spawnPoints;
    public int NumberOfSpawnPoints;
    public int NumberOfObjects;

    private float timer;
    public float timeBetweenSpawns;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, NumberOfSpawnPoints);
            int randNum2 = Random.Range(0, NumberOfObjects);

            Instantiate(Objects[randNum2], spawnPoints[randNum].transform.position, Quaternion.identity);
        }
    }
}
