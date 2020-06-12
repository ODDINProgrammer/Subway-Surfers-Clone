using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class WorldGeneration : MonoBehaviour
{
    //Variables
    [SerializeField] private Transform Player;                              // Access to player game object
    [SerializeField] private Chunk[] Chunks;                                // Array of chunks 
    [SerializeField] private List<Chunk> SpawnedChunks = new List<Chunk>(); // List of spawned chunks currently visible on screen
    [SerializeField] private Chunk StartingChunk;                           // Starting chunk reference
    
    // Start is called before the first frame update
    private void Start()
    {
        SpawnedChunks.Add(StartingChunk); // Add starting chunk to list. This is the one without any obstacles and collectibles.
        // Initialize world for the begining of the game
        while (SpawnedChunks.Count < 3)
        {
            SpawnChunk();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //When player exit previous chunk, spawn a new one and remove the one, which player just moved from.
        //I have added a small number to end position check, so that player cant notice chunk being deleted.
        if (Player.position.z > SpawnedChunks[0].End.position.z + 5)
        {
            SpawnChunk();
            Destroy(SpawnedChunks[0].gameObject);
            SpawnedChunks.RemoveAt(0);
        }
    }

    private void SpawnChunk()
    {

        Chunk newChunk = Instantiate(Chunks[1]); // Spawn new chunk
        newChunk.transform.parent = transform;   // Make new chunk a child of World game object. Makes game inspector cleaner.
        newChunk.transform.position = SpawnedChunks[SpawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition; // Move new chunk to allign with end point of previous one.
        SpawnedChunks.Add(newChunk);             // Add new chunk to list of chunks
    }

   
}
