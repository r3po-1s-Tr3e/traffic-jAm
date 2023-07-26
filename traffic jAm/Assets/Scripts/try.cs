using UnityEngine;

public class TileBasedTerrainGenerator : MonoBehaviour


{
    [SerializeField] private GameObject[] tilePrefabs; // Array of tile prefabs with the Ground tile as the first element.
    [SerializeField] private int numberOfTiles = 20; // Number of tiles to generate initially.
    [SerializeField] private Transform player; // Reference to the player's transform.
    [SerializeField] private float tileLength = 10f; // Length of each tile.
    [SerializeField] private float despawnDistance = 30f; // Distance after which tiles are despawned.
    [SerializeField] private float spawnOffset = 5f; // Offset for spawning new tiles.

    private Transform[] spawnedTiles; // Array to keep track of spawned tiles.
    private int lastTileIndex = 0; // Index of the last tile in the spawnedTiles array.
    private int maxConsecutiveRepeats = 2; // Maximum number of consecutive repeats for each tile.
    Rigidbody PlayerBody;
    [SerializeField] private float velocity;

    private void Start()
    {
        PlayerBody = GetComponent<Rigidbody>();
        spawnedTiles = new Transform[numberOfTiles];
        for (int i = 0; i < numberOfTiles; i++)
        {
            spawnedTiles[i] = SpawnTile(i * tileLength);
        }
    }

    private void Update()
    {
        if ( Input.GetKey("space"))
        {
            PlayerBody.velocity = new Vector3(velocity, PlayerBody.velocity.y, PlayerBody.velocity.z);
        }

        // Check if the player has moved past the last spawned tile.
        if (player.position.z > spawnedTiles[lastTileIndex].position.z)
        {
            DespawnTile(spawnedTiles[lastTileIndex]);
            lastTileIndex = (lastTileIndex + 1) % numberOfTiles;
            float spawnPos = spawnedTiles[lastTileIndex].position.z + tileLength;
            spawnedTiles[lastTileIndex] = SpawnTile(spawnPos);
        }
    }

    private Transform SpawnTile(float zPosition)
    {
        int tileIndex = RandomTileIndex();
        GameObject tilePrefab = tilePrefabs[tileIndex];
        Vector3 spawnPosition = new Vector3(0f, 0f, zPosition);
        return Instantiate(tilePrefab, spawnPosition, Quaternion.identity).transform;
    }

    private int RandomTileIndex()
    {
        // Generate a random tile index but ensure it doesn't exceed the maximum consecutive repeats.
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        } while (randomIndex == lastTileIndex || IsTileRepeated(randomIndex));
        return randomIndex;
    }

    private bool IsTileRepeated(int tileIndex)
    {
        // Check if the tile at tileIndex is repeated consecutively more than maxConsecutiveRepeats times.
        int consecCount = 0;
        for (int i = 1; i <= maxConsecutiveRepeats; i++)
        {
            int prevIndex = (lastTileIndex - i + numberOfTiles) % numberOfTiles;
            if (spawnedTiles[prevIndex].CompareTag(tilePrefabs[tileIndex].tag))
            {
                consecCount++;
            }
            else
            {
                break;
            }
        }
        return consecCount >= maxConsecutiveRepeats;
    }

    private void DespawnTile(Transform tile)
    {
        Destroy(tile.gameObject);
    }
}
