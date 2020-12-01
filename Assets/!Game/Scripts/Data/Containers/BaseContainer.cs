using System;
using System.Linq;
using UnityEngine;

namespace Company.Core
{
#if UNITY_EDITOR
    using UnityEditor;

#endif

    public abstract class BaseContainer : ScriptableObject
    {
        protected abstract void OnEnable();

        public static void CreateAsset(Type containerType)
        {
            if (AssetDatabase.FindAssets("t:" + containerType.Name).Length > 0)
            {
                Debug.LogError("Container of this type already present!");
                return;
            }

            var path = string.Format("{0}{1}", "Assets/!Game/Containers/", containerType.Name + ".asset");

            var container = ScriptableObject.CreateInstance(containerType.FullName);

            var assets = UnityEditor.PlayerSettings.GetPreloadedAssets().ToList();
            assets.Add(container);
            PlayerSettings.SetPreloadedAssets(assets.ToArray());

            AssetDatabase.CreateAsset(container, path);
            ProjectWindowUtil.ShowCreatedAsset(container);
            EditorUtility.SetDirty(container);
        }
    }
}