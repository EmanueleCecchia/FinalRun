using UnityEngine;
using UnityEditor;

public class PlayerPrefRemover : EditorWindow
{
    [MenuItem("Tools/PlayerPref Remover")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs Deleted!");
    }
}
