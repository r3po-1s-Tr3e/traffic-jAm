using System.Collections.Generic;
using UnityEngine;

namespace trafficLevel {

    public class TileSpawner : MonoBehaviour
    {

        [SerializeField] int minimumStraightTiles = 0;
        [SerializeField] int maximumStraightTiles = 3;
        [SerializeField] Transform player;
        [SerializeField] private GameObject startingTile;
        [SerializeField] private List<GameObject> jumpTiles;

        private Vector3 currentTileLocation = Vector3.zero;
        private Vector3 TileDirection = new Vector3(1f, 0f, 0f);
        private GameObject prevTile;
        private List<GameObject> currentTiles;

        private void Start()
        {
            currentTiles = new List<GameObject>();
            Random.InitState(System.DateTime.Now.Millisecond);

            for (int i = 0; i < Random.Range(minimumStraightTiles+1, 5 + 1); ++i)
            {
                SpawnTile(startingTile.GetComponent<Tile>());
            }

            SpawnTile(SelectRandomObjectFromList(jumpTiles).GetComponent<Tile>());
        }
        void SpawnTile(Tile tile)
            {
                prevTile = GameObject.Instantiate(tile.gameObject, currentTileLocation, Quaternion.identity);
                currentTiles.Add(prevTile);
                currentTileLocation += Vector3.Scale(prevTile.GetComponent<Renderer>().bounds.size, TileDirection);
                Debug.Log(currentTileLocation);
            }

        GameObject SelectRandomObjectFromList(List<GameObject> list)
            {
                return list[Random.Range(0, list.Count)];
            }

        void DeletePreviousTiles()
        {
            while (currentTiles.Count >= 5)
            {
                GameObject tile = currentTiles[0];
                currentTiles.RemoveAt(0);
                Destroy(tile);
            }
        }

        private void Update()
        {
            if (player.position.x >= currentTileLocation.x - 100f)
            {
                SpawnTile(SelectRandomObjectFromList(jumpTiles).GetComponent<Tile>());
                SpawnTile(SelectRandomObjectFromList(jumpTiles).GetComponent<Tile>());
                DeletePreviousTiles();
            }

        }

    }
}

