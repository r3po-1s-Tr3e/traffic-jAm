using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace trafficLevel
{
    public enum TileType
    {
        PlainGround,
        GroundType1,
        GroundType2,
        GroundType3,
        GroundType4,
        GroundType5,
        GroundType6,
    }
    public class Tile : MonoBehaviour
    {

        public TileType type;



    }
}
