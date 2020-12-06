using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        int playerNum = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[playerNum];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
