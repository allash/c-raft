using UnityEngine;
using System.Collections;
using ChunkRendering;
using System;

public class Chunk
{
	public static readonly int SliceHeight = 64;
	
	public static readonly int NumSlices = 256 / SliceHeight;
	public static readonly int MaxSliceIndex = NumSlices - 1;
	public static readonly int SliceHeightLimit = SliceHeight - 1;
	public ChunkSlice[] Slices = new ChunkSlice[NumSlices];
	public GameObject ChunkObject;
	public WorldBehaviour World;
	public int X;
	public int Z;
	public Color ChunkColor;
	
	public Chunk(int chunkX, int chunkZ, WorldBehaviour world, Color color)
	{
		ChunkColor = color;
		ChunkObject = new GameObject(String.Format("X {0} Z {1}", chunkX, chunkZ));
		ChunkBehaviour behaviour = ChunkObject.AddComponent(typeof(ChunkBehaviour)) as ChunkBehaviour;
		behaviour.Parent = this;
		ChunkObject.transform.position = new Vector3(chunkX*16,0,chunkZ*16);
		X = chunkX;
		Z = chunkZ;
		World = world;
		
		for(int i = 0; i < NumSlices; ++i)
			Slices[i] = new ChunkSlice(i);
		
		for (int x=0; x < 16; x++)
            for (int z=0; z< 16; z++)
                for (int y = 0; y < 256; y++)
                	Slices[y/Chunk.SliceHeight][x,y & Chunk.SliceHeightLimit,z] = 1;	
	}
}
