using UnityEngine;
using UnityEditor;
using System.IO;
using Cinemachine;
using Cinemachine.Editor;

public class StoryBoardUtility : Editor
{
    [InitializeOnLoad]
    internal class CinemachineStoryboardMute
    {
        const string StoryboardGlobalMuteMenuName = "Cinemachine/Utility Mute #M";
        [MenuItem(StoryboardGlobalMuteMenuName, false)]
        public static void StoryboardGlobalMute()
        {
            bool enable = !CinemachineStoryboardMute.Enabled;
            CinemachineStoryboardMute.Enabled = enable;
        }

        static CinemachineStoryboardMute()
        {
            CinemachineStoryboard.s_StoryboardGlobalMute = Enabled;

             /// Delaying until first editor tick so that the menu
             /// will be populated before setting check state, and
             /// re-apply correct action
             EditorApplication.delayCall += () => { UnityEditor.Menu.SetChecked(StoryboardGlobalMuteMenuName, Enabled); };
        }

        public static string kEnabledKey = "StoryboardMute_Enabled";
        public static bool Enabled
        {
            get { return EditorPrefs.GetBool(kEnabledKey, false); }
            set
            {
                if (value != Enabled)
                {
                    EditorPrefs.SetBool(kEnabledKey, value);
                    CinemachineStoryboard.s_StoryboardGlobalMute = value;
                    UnityEditor.Menu.SetChecked(StoryboardGlobalMuteMenuName, value);

                    InspectorUtility.RepaintGameView();
                }
            }
        }
    }

    [CustomEditor(typeof(CinemachineStoryboard))]
    [CanEditMultipleObjects]
    internal sealed class CinemachineStoryboardEditor : BaseEditor<CinemachineStoryboard>
    {
    

        const float FastWaveformUpdateInterval = 0.1f;
        float mLastSplitScreenEventTime = 0;
        
        public override void OnInspectorGUI()
        {
            float now = Time.realtimeSinceStartup;
            if (now - mLastSplitScreenEventTime > FastWaveformUpdateInterval * 5)
           

            BeginInspector();
            CinemachineStoryboardMute.Enabled
                = EditorGUILayout.Toggle(
                    new GUIContent(
                        "Storyboard Global Mute",
                        "If checked, all storyboards are globally muted."),
                    CinemachineStoryboardMute.Enabled);

            Rect rect = EditorGUILayout.GetControlRect(true);
            EditorGUI.BeginChangeCheck();
            {
                float width = rect.width;
                rect.width = EditorGUIUtility.labelWidth + rect.height;
                EditorGUI.PropertyField(rect, FindProperty(x => x.m_ShowImage));

                rect.x += rect.width; rect.width = width - rect.width;
                EditorGUI.PropertyField(rect, FindProperty(x => x.m_Image), GUIContent.none);

                EditorGUILayout.PropertyField(FindProperty(x => x.m_Aspect));
                EditorGUILayout.PropertyField(FindProperty(x => x.m_Alpha));
                EditorGUILayout.PropertyField(FindProperty(x => x.m_Center));
                EditorGUILayout.PropertyField(FindProperty(x => x.m_Rotation));

                rect = EditorGUILayout.GetControlRect(true);
                EditorGUI.LabelField(rect, "Scale");
                rect.x += EditorGUIUtility.labelWidth; rect.width -= EditorGUIUtility.labelWidth;
                rect.width /= 3;
                serializedObject.SetIsDifferentCacheDirty(); // prop.hasMultipleDifferentValues always results in false if the SO isn't refreshed here
                var prop = FindProperty(x => x.m_SyncScale);
                var syncHasDifferentValues = prop.hasMultipleDifferentValues;
                GUIContent syncLabel = new GUIContent("Sync", prop.tooltip);
                EditorGUI.showMixedValue = syncHasDifferentValues;
                prop.boolValue = EditorGUI.ToggleLeft(rect, syncLabel, prop.boolValue);
                EditorGUI.showMixedValue = false;
                rect.x += rect.width;
                if (prop.boolValue || targets.Length > 1 && syncHasDifferentValues)
                {
                    prop = FindProperty(x => x.m_Scale);
                    float[] values = new float[1] { prop.vector2Value.x };
                    EditorGUI.showMixedValue = prop.hasMultipleDifferentValues;
                    EditorGUI.MultiFloatField(rect, new GUIContent[1] { new GUIContent("X") }, values);
                    EditorGUI.showMixedValue = false;
                    prop.vector2Value = new Vector2(values[0], values[0]);
                }
                else
                {
                    rect.width *= 2;
                    prop = FindProperty(x => x.m_Scale);
                    EditorGUI.showMixedValue = prop.hasMultipleDifferentValues;
                    EditorGUI.PropertyField(rect, prop, GUIContent.none);
                    EditorGUI.showMixedValue = false;
                }
                EditorGUILayout.PropertyField(FindProperty(x => x.m_MuteCamera));
            }
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(FindProperty(x => x.m_SplitView));
            if (EditorGUI.EndChangeCheck())
            {
                mLastSplitScreenEventTime = now;
           
                serializedObject.ApplyModifiedProperties();
            }
            rect = EditorGUILayout.GetControlRect(true);
            GUI.Label(new Rect(rect.x, rect.y, EditorGUIUtility.labelWidth, rect.height),
                "Waveform Monitor");
            rect.width -= EditorGUIUtility.labelWidth; rect.width /= 2;
            rect.x += EditorGUIUtility.labelWidth;
       
                
        }
    }
}

