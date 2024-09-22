using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace DouduckLib.MipmapMaker {
    [CustomEditor (typeof (MipmapMaker))]
    public class MipmapMakerEditor : Editor {

        ReorderableList list;

        void OnEnable () {
            var property = serializedObject.FindProperty ("sources");
            list = new ReorderableList (property.serializedObject, property, true, true, true, true);
            list.drawHeaderCallback = OnDrawListHeader;
            list.drawElementCallback = OnDrawListElement;
        }

        void OnDrawListHeader (Rect rect) {
            EditorGUI.LabelField (rect, "Mipmap level settings");
        }

        void OnDrawListElement (Rect rect, int index, bool isActive, bool isFocused) {
            var element = list.serializedProperty.GetArrayElementAtIndex (index);
            EditorGUI.PropertyField (rect, element, new GUIContent ("Mip " + index));
        }

        public override void OnInspectorGUI () {
            this.serializedObject.Update ();

            var property = list.serializedProperty;
            property.isExpanded = EditorGUILayout.Foldout (property.isExpanded, property.displayName);
            if (property.isExpanded) {
                this.list.DoLayoutList ();
            }

            this.serializedObject.ApplyModifiedProperties ();

            if (GUILayout.Button ("Create Texture")) {
                CreateMipMap ();
            }
        }

        bool ValidateSources (List<Texture2D> sources) {
            if (sources == null || sources.Count < 1) {
                Debug.LogError ("`sources` list is empty");
                return false;
            }

            var width = sources[0].width;
            var height = sources[0].height;
            for (int i = 0; i < sources.Count; i++) {
                if (width != sources[i].width || height != sources[i].height) {
                    Debug.LogErrorFormat ("`sources` item {0} has invalidated resolution", i);
                    return false;
                }
                width /= 2;
                height /= 2;
            }
            return true;
        }

        string GetFileName () {
            var path = AssetDatabase.GetAssetPath (target);
            return Path.Combine (Path.GetDirectoryName (path), target.name + "_texture.asset");
        }

        void CreateMipMap () {
            var sources = ((MipmapMaker)target).sources;
            if (!ValidateSources (sources)) {
                return;
            }

            var texture = new Texture2D (sources[0].width, sources[0].height);
            texture.name = sources[0].name;
            texture.SetPixels (sources[0].GetPixels ());
            texture.Apply ();

            for (int i = 1; i < sources.Count; i++) {
                var pixels = sources[i].GetPixels ();
                texture.SetPixels (pixels, i);
            }
            texture.Apply (false, true);

            AssetDatabase.CreateAsset (texture, GetFileName ());
            // AssetDatabase.SaveAssets ();
            // AssetDatabase.Refresh ();
        }
    }
}