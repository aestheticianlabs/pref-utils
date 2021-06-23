using System;
using UnityEngine;
using UnityEditor;

namespace PrefUtils.Editor
{
    internal static class EditorMenu
    {
        [MenuItem("Tools/Pref Utils/Delete All Player Prefs")]
        private static void DeleteAllPlayerPrefs() => ConfirmationDialog(
            "Delete all player preferences?",
            "Are you sure you'd like to remove all keys and values from " +
            "player preferences?\nThis action cannot be undone.",
            PlayerPrefs.DeleteAll
        );
        [MenuItem("Tools/Pref Utils/Delete All Editor Prefs")]
        private static void DeleteAllEditorPrefs() => ConfirmationDialog(
            "Delete all editor preferences?",
            "Are you sure you'd like to remove all keys and values from " +
            "editor preferences?\nThis action cannot be undone.",
            EditorPrefs.DeleteAll
        );

        private static void ConfirmationDialog(
            string title, string message, Action confirm, Action cancel = null
        )
        {
            if (EditorUtility.DisplayDialog(title, message, "Yes", "No"))
                confirm?.Invoke();
            else
                cancel?.Invoke();
        }
    }
}