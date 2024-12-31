using UnityEditor;
using UnityEngine;

namespace Le0der.Toolkits
{
    [CustomEditor(typeof(MonoSingleton<>), true)]
    public class SingletonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            // 获取泛型类型
            var monoSingletonType = target.GetType();
            var baseType = monoSingletonType.BaseType;

            // 确保类型是 MonoSingleton<> 类型
            if (baseType != null && baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(MonoSingleton<>))
            {
                // 获取单例实例
                var instanceField = baseType.GetField("Instance", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                var instance = instanceField?.GetValue(null);

                if (instance != null)
                {
                    EditorGUILayout.LabelField("Singleton Instance: " + instance.GetType().Name);
                }
                else
                {
                    EditorGUILayout.HelpBox("Singleton instance is null", MessageType.Warning);
                }
            }
        }
    }
}