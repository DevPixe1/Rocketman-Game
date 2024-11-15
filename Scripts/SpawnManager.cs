using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject[] spawnPoints;

    private float timer;
    public float timeBetweenSpawns;

    public int Points;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            int randNum = Random.Range(0, Points);

            Instantiate(spawnObject, spawnPoints[randNum].transform.position, Quaternion.identity);
        }
    }
}
