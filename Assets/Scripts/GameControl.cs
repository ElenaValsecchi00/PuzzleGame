using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private CheckTile[] allTiles;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = FindObjectsOfType<CheckTile>();
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        foreach(CheckTile tile in allTiles)
        {
            if(tile.isTileRight) count+=1;
        }
        if(count==allTiles.Length)
        {
            Debug.Log("GAME OVER");
        } 
    }
}
