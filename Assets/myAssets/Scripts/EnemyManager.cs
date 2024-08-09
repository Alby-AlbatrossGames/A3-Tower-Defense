using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public enum GameMode //put in GameManager script
{
    Menu,
    Prep,
    Attack
}


public class EnemyManager : Singleton<EnemyManager>
{
    public GameObject[] EnemyPrefabs;
    public Transform[] NodeList;
    public List<GameObject> ActiveEnemyList;

    void SpawnEnemy(int _type)
    {
        GameObject thisEnemy = Instantiate(EnemyPrefabs[_type]);
        ActiveEnemyList.Add(thisEnemy);
    }

    public void KillEnemy(GameObject go)
    {
        ActiveEnemyList.Remove(go);
        Destroy(go);
    }

    public IEnumerator SpawnWave(int _hordeCount, int _hordeSize, int _type)
    {
        for (int i = 0; i < _hordeCount; i++)
        {
            StartCoroutine(SpawnHorde(_hordeSize, _type));
            Debug.Log("SpawnWave");
            yield return new WaitForSeconds(Random.Range(0.5f,1.5f)); //fix time
        }
        
    }

    public IEnumerator SpawnHorde(int _count, int _type)
    {
        for (int i = 0; i < _count; i++)
        {
            SpawnEnemy(_type);
            Debug.Log("SpawnEnemy");
            yield return new WaitForSeconds(Random.Range(0.5f,1.5f)); //fix time
        }
    }
}
