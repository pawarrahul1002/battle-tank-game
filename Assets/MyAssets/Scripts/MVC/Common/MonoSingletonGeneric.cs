using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        private static object m_lock = new Object();

        public static T GetInstance()
        {
            lock (m_lock)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();

                    if (instance == null)
                    {
                        GameObject obj = new GameObject();

                        obj.name = typeof(T).ToString();

                        instance = obj.AddComponent<T>();

                        DontDestroyOnLoad(obj);
                    }
                }
            }

            return instance;
        }
    }

}

//   public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
//     {
//         private static T instance;
//         public static T Instance { get { return instance; } }
//         protected virtual void Awake()
//         {
//             Debug.Log("Genric called");
//             if (instance == null)
//             {
//                 instance = this as T;
//             }
//             else
//             {
//                 Debug.LogError(Instance + "is Tring to create another instance");
//                 Destroy(this);
//             }
//         }
//     }