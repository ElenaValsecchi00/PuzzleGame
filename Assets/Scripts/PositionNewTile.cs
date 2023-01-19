using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PositionNewTile : MonoBehaviour
{
    private Tilemap tileMap;
    private Camera cam;
    private TileDispencerListener tileDispencer;

    // Start is called before the first frame update
    void Start()
    {
        tileMap = GetComponent<Tilemap>();
        cam = Camera.main;
        tileDispencer = Object.FindObjectOfType<TileDispencerListener>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    void OnMouseDown()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = tileMap.WorldToCell(mousePos);
        if (tileMap.GetTile(gridPos).name=="EmptyPiece")
        {
           if(tileDispencer.tileToPlace!=null)
           {
                tileMap.SetTile(gridPos,tileDispencer.tileToPlace);
           }
           
        }

    }
}
