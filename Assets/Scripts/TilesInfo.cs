using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using MiniJSON;

public class RightTile{
    public string tile;
    public string rotation;


    public override string ToString()
    {
        return this.tile+","+this.rotation;
    } 
}

public class TilesInfo : MonoBehaviour
{

    private Tilemap tileMap;
    private TileBase[] cells;
    private BoundsInt bounds;
    private RightTile[] rightTiles;
    public TextAsset jsonLevel;
    // Start is called before the first frame update
    void C()
    {
        tileMap = GetComponent<Tilemap>();
        bounds = tileMap.cellBounds;
        cells = tileMap.GetTilesBlock(bounds);
        var jsonString = Json.Serialize(jsonLevel);
        Debug.Log(jsonString);
        var dictionary = Json.Deserialize(jsonString) as Dictionary<string,Dictionary<string,string>>;
        Debug.Log(dictionary.GetType());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int x = 0; x < bounds.size.x; x++) {
            for (int y = 0; y < bounds.size.y; y++) {
                TileBase tile = cells[x + y * bounds.size.x];
                if (tile != null) {
                    Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                } else {
                    Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        }  
        */            
    }
}
