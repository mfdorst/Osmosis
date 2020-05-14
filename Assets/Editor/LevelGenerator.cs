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
      if (GUILayout.Button("Randomize Seed"))
      {
        seed = Random.Range(0, int.MaxValue);
        Repaint();
      }
      if (GUILayout.Button($"{(level ? "Regenerate" : "Generate")} Level"))
      {
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
    for (int i = 0; i < numCells; i++)
    {
      SpawnCell();
    }
  }

  void SpawnCell()
  {
    Vector2 position;
    Collider2D[] overlapping;
    do
    {
      position = new Vector2(Random.Range(-8, 8), Random.Range(-5, 5));
      overlapping = Physics2D.OverlapCircleAll(position, 1);
    } while (overlapping.Length > 0);

    Instantiate(cell, position, Quaternion.identity, level.transform);
  }
}
