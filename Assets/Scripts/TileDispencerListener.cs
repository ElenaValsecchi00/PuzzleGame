using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDispencerListener : MonoBehaviour
{
    //public and private references
    public Tile tileToPlace;

    // Start is called before the first frame update
    void Start()
    {
        tileToPlace = null;
    }

}
