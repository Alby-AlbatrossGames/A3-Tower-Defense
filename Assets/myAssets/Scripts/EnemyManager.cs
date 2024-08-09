using System.Collections.Generic;
using UnityEngine;

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
}
