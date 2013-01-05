using System.Collections.Generic;
using UnityEngine;

namespace ChunkRendering
{
	class ChunkRenderer
	{
	
	    public static void render(Chunk chunk)
	    {
	        List<Vector3> vertices = new List<Vector3>();
	        List<int> triangles = new List<int>();
			List<Color> colors = new List<Color>();
			WorldBehaviour world = chunk.World;
			
			for(int i = 0; i < Chunk.NumSlices; ++i)
			{
				ChunkSlice chunkSlice = chunk.Slices[i];
		        for (int x = 0; x < 16; x++)
				{
		            for (int z = 0; z < 16; z++)
					{
		                for (int y = 0; y < Chunk.SliceHeight; y++)
		                {								
		                    byte block = chunkSlice[x, y, z];
							byte top;
							
							if(y + 1 > Chunk.SliceHeightLimit)
							{
								if(i + 1 > Chunk.MaxSliceIndex)
									top = 0;
								else
								{
									ChunkSlice topSlice = chunk.Slices[i + 1];
									top = topSlice[x, (y + 1) & Chunk.SliceHeightLimit, z];
								}
							}
		                    else
								top = chunkSlice[x, y + 1, z];
		
		                    // we are checking the top face of the block, so see if the top is exposed
		                    if (top == 0)
		                    {
		                        int vertexIndex = vertices.Count;
		                        vertices.Add(new Vector3(x, y + 1, z));
		                        vertices.Add(new Vector3(x, y + 1, z + 1));
		                        vertices.Add(new Vector3(x + 1, y + 1, z + 1));
		                        vertices.Add(new Vector3(x + 1, y + 1, z));
		
		                        // first triangle for the block top
		                        triangles.Add(vertexIndex);
		                        triangles.Add(vertexIndex+1);
		                        triangles.Add(vertexIndex+2);
		                        
		                        // second triangle for the block top
		                        triangles.Add(vertexIndex+2);
		                        triangles.Add(vertexIndex+3);
		                        triangles.Add(vertexIndex);
							
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);						
		                    }
						
							byte front;
							if(z - 1 < 0)
							{
								int worldX = chunk.X << 4;
								int worldZ = ((chunk.Z - 1) << 4);
								
								front = world.GetBlockType(worldX, y, worldZ);
							}
							else
								front = chunkSlice[x, y, z - 1];
						
							if (front == 0)
		                    {
		                        int vertexIndex = vertices.Count;
		                        vertices.Add(new Vector3(x, y, z));
		                        vertices.Add(new Vector3(x, y + 1, z));
		                        vertices.Add(new Vector3(x + 1, y + 1, z));
		                        vertices.Add(new Vector3(x + 1, y, z));
		
		                        // first triangle for the block top
		                        triangles.Add(vertexIndex);
		                        triangles.Add(vertexIndex+1);
		                        triangles.Add(vertexIndex+2);
		                        
		                        // second triangle for the block top
		                        triangles.Add(vertexIndex+2);
		                        triangles.Add(vertexIndex+3);
		                        triangles.Add(vertexIndex);
							
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
		                    }
						
							byte right;
							
							if(x + 1 > 15)
							{	
								int worldX = ((chunk.X+1) << 4);
								int worldZ = chunk.Z << 4;
								right = world.GetBlockType(worldX, y, worldZ);
							}
							else
								right = chunkSlice[x + 1, y, z];
		
		                    if (right == 0)
		                    {
		                        int vertexIndex = vertices.Count;
		                        vertices.Add(new Vector3(x + 1, y, z));
		                        vertices.Add(new Vector3(x + 1, y + 1, z));
		                        vertices.Add(new Vector3(x + 1, y + 1, z + 1));
		                        vertices.Add(new Vector3(x + 1, y, z + 1));
		
		                        // first triangle for the block top
		                        triangles.Add(vertexIndex);
		                        triangles.Add(vertexIndex+1);
		                        triangles.Add(vertexIndex+2);
		                        
		                        // second triangle for the block top
		                        triangles.Add(vertexIndex+2);
		                        triangles.Add(vertexIndex+3);
		                        triangles.Add(vertexIndex);
							
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
		                    }
						
							byte back;
							
							if(z + 1 > 15)
							{
								int worldX = chunk.X << 4;
								int worldZ = ((chunk.Z + 1) << 4);
								back = world.GetBlockType(worldX, y, worldZ);
							}
							else
								back = chunkSlice[x, y, z + 1];
						
							if (back == 0)
		                    {
		                        int vertexIndex = vertices.Count;
		                        vertices.Add(new Vector3(x + 1, y, z + 1));
		                        vertices.Add(new Vector3(x + 1, y + 1, z + 1));
		                        vertices.Add(new Vector3(x, y + 1, z + 1));
		                        vertices.Add(new Vector3(x, y, z + 1));
		
		                        // first triangle for the block top
		                        triangles.Add(vertexIndex);
		                        triangles.Add(vertexIndex+1);
		                        triangles.Add(vertexIndex+2);
		                        
		                        // second triangle for the block top
		                        triangles.Add(vertexIndex+2);
		                        triangles.Add(vertexIndex+3);
		                        triangles.Add(vertexIndex);
							
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
		                    }
						
							byte left;
							
							if(x - 1 < 0)
							{
								int worldX = ((chunk.X - 1) << 4);
								int worldZ = chunk.Z << 4;
								left = world.GetBlockType(worldX, y, worldZ);
							}
							else
								left = chunkSlice[x - 1, y, z];
						
							if (left == 0)
		                    {
		                        int vertexIndex = vertices.Count;
		                        vertices.Add(new Vector3(x, y, z + 1));
		                        vertices.Add(new Vector3(x, y + 1, z + 1));
		                        vertices.Add(new Vector3(x, y + 1, z));
		                        vertices.Add(new Vector3(x, y, z));
		
		                        // first triangle for the block top
		                        triangles.Add(vertexIndex);
		                        triangles.Add(vertexIndex+1);
		                        triangles.Add(vertexIndex+2);
		                        
		                        // second triangle for the block top
		                        triangles.Add(vertexIndex+2);
		                        triangles.Add(vertexIndex+3);
		                        triangles.Add(vertexIndex);
							
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
		                    }
						
							byte bottom;
							
							if(y - 1 < 0)
								bottom = 1;
							else
								bottom = chunkSlice[x, y - 1, z];
						
							if (bottom == 0)
		                    {
		                        int vertexIndex = vertices.Count;
		                        vertices.Add(new Vector3(x, y, z + 1));
		                        vertices.Add(new Vector3(x, y, z));
		                        vertices.Add(new Vector3(x + 1, y, z));
		                        vertices.Add(new Vector3(x + 1, y, z + 1));
		
		                        // first triangle for the block top
		                        triangles.Add(vertexIndex);
		                        triangles.Add(vertexIndex+1);
		                        triangles.Add(vertexIndex+2);
		                        
		                        // second triangle for the block top
		                        triangles.Add(vertexIndex+2);
		                        triangles.Add(vertexIndex+3);
		                        triangles.Add(vertexIndex);
							
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
								colors.Add(Color.gray);
		                    }
		                }
					}
				}
				
				// Build the Mesh:
		        Mesh mesh = new Mesh();
		        mesh.vertices = vertices.ToArray();
		        mesh.triangles = triangles.ToArray();
				mesh.colors = colors.ToArray();
				
				mesh.RecalculateNormals();
				mesh.RecalculateBounds ();
				
				ChunkBehaviour behaviour = chunk.ChunkObject.GetComponent<ChunkBehaviour>();
				GameObject chunkSliceObject = behaviour.ChunkSliceObjects[i];
				MeshFilter filter = chunkSliceObject.GetComponent<MeshFilter>();
				filter.mesh = mesh;
			}
	    }
	}
}
