using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class EditModeFunctions : EditorWindow
{
    [MenuItem("Window/Edit Mode Functions")]
    public static void ShowWindow()
    {
        GetWindow<EditModeFunctions>("Edit Mode Functions");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Grow Breasts"))
        {
            Player.instance.change_breast_size(1);
        }
        if (GUILayout.Button("Shrink Breasts"))
        {
            Player.instance.change_breast_size(-1);
        }
        if(GUILayout.Button("Master.Update_Hair_Color()"))
        {
            Master.instance.update_hair_color();
        }
    }
}
#endif 