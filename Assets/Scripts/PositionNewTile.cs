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

    //Get Quaternion from Matrix4x4 (used to convert tilemap's Transform Matrix) credits to runevision
    public static Quaternion QuaternionFromMatrix(Matrix4x4 m) {
        Quaternion q = new Quaternion();
        q.w = Mathf.Sqrt( Mathf.Max( 0, 1 + m[0,0] + m[1,1] + m[2,2] ) ) / 2; 
        q.x = Mathf.Sqrt( Mathf.Max( 0, 1 + m[0,0] - m[1,1] - m[2,2] ) ) / 2; 
        q.y = Mathf.Sqrt( Mathf.Max( 0, 1 - m[0,0] + m[1,1] - m[2,2] ) ) / 2; 
        q.z = Mathf.Sqrt( Mathf.Max( 0, 1 - m[0,0] - m[1,1] + m[2,2] ) ) / 2; 
        q.x *= Mathf.Sign( q.x * ( m[2,1] - m[1,2] ) );
        q.y *= Mathf.Sign( q.y * ( m[0,2] - m[2,0] ) );
        q.z *= Mathf.Sign( q.z * ( m[1,0] - m[0,1] ) );
    return q;
    }

    //Position selected tile on selecten cell
    void OnMouseDown()
    {
        //Gets the cell at which the mouse is pointing
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = tileMap.WorldToCell(mousePos);
        Tile tile = tileMap.GetTile<Tile>(gridPos);
        if (tile.name=="EmptyPiece" || tileDispencer.tileToPlace.name=="EmptyPiece")
        {
           if(tileDispencer.tileToPlace!=null)
           {
                tileMap.SetTile(gridPos,tileDispencer.tileToPlace);
           }
           
        }
        else
        {
            //Rotation of the tile achived by adding a (0,0,90) quaternion to the tilemap transform matrix in tile's position
            Matrix4x4 m = tileMap.GetTransformMatrix(gridPos);
            Quaternion tileMapQuat = QuaternionFromMatrix(m);
            var tileTransform = Matrix4x4.Rotate(tileMapQuat * Quaternion.Euler(0,0,90));
            var tileChangeData = new TileChangeData
            {
                position = gridPos,
                tile = tile,
                color = Color.white,
                transform = tileTransform
                
            };
            //Changes old tile with the new rotated one
            tileMap.SetTile(tileChangeData, false);
        }

    }
}
