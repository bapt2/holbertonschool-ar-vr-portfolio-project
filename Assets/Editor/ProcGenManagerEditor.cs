using System.Collections;
using UnityEditor;
using UnityEngine;
using Unity.EditorCoroutines.Editor;

[CustomEditor(typeof(ProcGenManager))]
public class ProcGenManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Regenerate World"))
        {
            ProcGenManager targetManager = serializedObject.targetObject as ProcGenManager;
            EditorCoroutineUtility.StartCoroutine(PerformRegeneration(targetManager), this);
        }

        if (GUILayout.Button("Regenerate Texture"))
        {
            ProcGenManager targetManager = serializedObject.targetObject as ProcGenManager;
            targetManager.RegenerateTextures();
        }

        if (GUILayout.Button("Regenerate Detail Prototypes"))
        {
            ProcGenManager targetManager = serializedObject.targetObject as ProcGenManager;
            targetManager.RegenerateDetailPrototypes();
        }
    }

    int progressID;
    IEnumerator PerformRegeneration(ProcGenManager targetManager)
    {
        progressID = Progress.Start("Regenerating terrain");
        yield return targetManager.AsyncRegenerateWorld(OnStatusReported);

        Progress.Remove(progressID);

        yield return null;
    }

    void OnStatusReported(EGenerationStage currentStage, string status)
    {
        Progress.Report(progressID, (int)currentStage, (int)EGenerationStage.NumStage, status);
    }
}
