using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(AudioManager_Sinusoidal))]
[CanEditMultipleObjects]
public class AudioManager_Sinusoidal_Editor : Editor
{
    [MenuItem("PhysicsBasedAudio/SinusoidalAudio")]
    static void CreateSinusoidalAudioManager()
    {
        GameObject target = Selection.activeGameObject;
        if (target != null)
        {
            target.AddComponent<AudioManager_Sinusoidal>();
        }
    }

    AudioManager_Sinusoidal scriptTarget;

    private void OnEnable()
    {
        scriptTarget = (AudioManager_Sinusoidal)target;
    }

    public override void OnInspectorGUI()
    {
        //change skin for GUI
        GUISkin old_skin = GUI.skin;
        GUISkin mySkin = Resources.Load("angyGUISkin") as GUISkin;
        GUI.skin = mySkin;

        GUILayout.BeginHorizontal();
        EditorGUILayout.Space();
        mySkin.label.fontSize = 20; //make titles bigger
        GUILayout.Label(scriptTarget.gameObject.name.Split(' ')[0], GUILayout.Height(30));
        mySkin.label.fontSize = 0; //return to default
        GUILayout.EndHorizontal();

        DrawDefaultInspector();
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        EditorGUILayout.Space();
        mySkin.label.fontSize = 20; //make titles bigger
        GUILayout.Label("Material", GUILayout.Height(30));
        mySkin.label.fontSize = 0; //return to default 
        GUILayout.EndHorizontal();
        mySkin.label.normal.textColor = new Color(0.35f, 0.14f, 0.39f); //change font color rgb(90,35,100)
        GUILayout.BeginHorizontal();
        GUILayout.Space(35); // until 1300
        GUILayout.Label("Plastic", GUILayout.MaxWidth(40));
        GUILayout.Space(50); // until 3200
        GUILayout.Label("Ceramic", GUILayout.MaxWidth(45));
        GUILayout.Space(20);
        GUILayout.Label("Metal", GUILayout.MaxWidth(40));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        float material = scriptTarget.HeavyScript.GetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Qfactor);
        float newMaterial = EditorGUILayout.Slider("", material, 20f, 5000f);
        if (material != newMaterial)
        {
            scriptTarget.HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Qfactor, newMaterial);
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(90); // until 2200
        GUILayout.Label("Wood", GUILayout.MaxWidth(40));
        GUILayout.Space(40); // until 3600
        GUILayout.Label("Glass", GUILayout.MaxWidth(40));
        GUILayout.EndHorizontal();
        mySkin.label.normal.textColor = new Color(0.45f, 0.13f, 0.65f); //change font color rgb(115,32,167)

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        EditorGUILayout.Space();
        mySkin.label.fontSize = 20; //make titles bigger
        GUILayout.Label("Size", GUILayout.Height(30));
        mySkin.label.fontSize = 0; //return to default
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Small", GUILayout.Width(30));
        float size = 2 - scriptTarget.SetDataScript.multiplier;
        float newSize = EditorGUILayout.Slider("", size, 0.1f, 1.9f);
        if (size != newSize)
        {
            scriptTarget.HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Size, 2 - newSize);
            scriptTarget.SetDataScript.multiplier = 2 - newSize;
            scriptTarget.SetDataScript.SetTheFreqs();
        }
        GUILayout.Label("Big", GUILayout.Width(25));
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        EditorGUILayout.Space();
        mySkin.label.fontSize = 20; //make titles bigger
        GUILayout.Label("Object Roughness", GUILayout.Height(30));
        mySkin.label.fontSize = 0; //return to default        
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Low", GUILayout.Width(30));
        float roughness = scriptTarget.HeavyScript.GetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Object_roughness);
        float newRoughness = EditorGUILayout.Slider("", roughness, 0f, 50f);
        if (roughness != newRoughness)
        {
            scriptTarget.HeavyScript.SetFloatParameter(Hv_SinusRolling_AudioLib.Parameter.Object_roughness, newRoughness);
        }
        GUILayout.Label("High", GUILayout.Width(25));
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        GUI.skin = old_skin;
        
    }
}
