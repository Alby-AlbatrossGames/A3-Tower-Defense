using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    Menu,
    Prep,
    Attack
}


public class EnemyManager : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public Transform[] NodeList;
    public List<GameObject> ActiveEnemyList;
}
