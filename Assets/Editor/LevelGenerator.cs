using UnityEditor;
using UnityEngine;

public class LevelGenerator : EditorWindow
{
  GameObject player;
  GameObject cell;

  [MenuItem("Window/Level Generator")]
  static void OpenWindow()
  {
    GetWindow<LevelGenerator>();
  }

  void OnGUI()
  {
    player = (GameObject)EditorGUILayout.ObjectField(player, typeof(GameObject), false);
    cell = (GameObject)EditorGUILayout.ObjectField(cell, typeof(GameObject), false);

    if (GUILayout.Button("Generate Level"))
    {
      GameObject level = new GameObject("Level");
      Instantiate(player, level.transform);
      Instantiate(cell, new Vector3(3, 3, 0), Quaternion.identity, level.transform);
    }
  }
}
