using UnityEditor;
using UnityEngine;

public class LevelGenerator : EditorWindow
{
  GameObject player;
  GameObject cell;
  GameObject level;
  int seed;
  int numCells;

  [MenuItem("Window/Level Generator")]
  static void OpenWindow()
  {
    GetWindow<LevelGenerator>();
  }

  void OnGUI()
  {
    player = (GameObject)EditorGUILayout.ObjectField("Player", player, typeof(GameObject), false);
    cell = (GameObject)EditorGUILayout.ObjectField("Cell", cell, typeof(GameObject), false);
    GUILayout.Space(5);
    seed = EditorGUILayout.IntField("Seed", seed);
    numCells = EditorGUILayout.IntField("Number of Cells", numCells);
    GUILayout.Space(5);
    GUILayout.BeginHorizontal();
    {
      if (GUILayout.Button("Generate From Seed"))
      {
        GenerateLevel();
      }
      if (GUILayout.Button("Generate Random"))
      {
        seed = Random.Range(0, int.MaxValue);
        Repaint();
        GenerateLevel();
      }
    }
    GUILayout.EndHorizontal();
  }

  void GenerateLevel()
  {
    if (level)
    {
      DestroyImmediate(level);
    }
    level = new GameObject("Level");
    Instantiate(player, level.transform);
    Random.InitState(seed);
    for (int i = 0; i < numCells; i++)
    {
      SpawnCell();
    }
  }

  void SpawnCell()
  {
    Vector2 position;
    Collider2D[] overlapping;
    int i = 0;
    do
    {
      position = new Vector2(Random.Range(-8f, 8), Random.Range(-5f, 5));
      overlapping = Physics2D.OverlapCircleAll(position, 0.5f);
      // If the new cell would overlap another cell, try again. Try a maximum of 1000 times.
    } while (overlapping.Length > 0 && i++ < 1000);

    Instantiate(cell, position, Quaternion.identity, level.transform);
  }
}
