using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckTile : MonoBehaviour
{
    //the correct tile to place
    public string rightTile;
    //is tile right or not
    public bool isTileRight;
    //the correct rotation to reach
    public string rightRotation;
    //the tile that is actually positioned
    private string positionedTile;

    public void Start()
    {
        isTileRight = false;
    }
    
    //Check whether or not the placed tile is correct
    public void CheckRightTile(Tilemap tileMap, string positionedRotation)
    {
        Vector3Int gridPos = tileMap.WorldToCell(transform.position);
        Tile tile = tileMap.GetTile<Tile>(gridPos);
        positionedTile = tile.name;
        if(string.Equals(rightTile, positionedTile) && string.Equals(rightRotation,positionedRotation)){
            isTileRight = true;
        }
    }
}
