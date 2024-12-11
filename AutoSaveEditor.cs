using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections;

[InitializeOnLoad]
public class AutoSaveEditor
{
    private static Timer timer = new Timer(20);

    // Static constructor to initialize the script
    static AutoSaveEditor()
    {
        EditorApplication.update += Update; // Add the update method to the editor's update loop
    }

    // Update method that runs every frame in the editor
    private static void Update()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
            return; // Don't auto-save while the game is running or about to start
        Scene activeScene = EditorSceneManager.GetActiveScene();
        if (timer.Count(false) && activeScene.isDirty){
            EditorSceneManager.SaveScene(activeScene); // Save the active scene
            Debug.Log("Scene auto-saved at: " + System.DateTime.Now);
            timer.Reset();
        }
    }
}
