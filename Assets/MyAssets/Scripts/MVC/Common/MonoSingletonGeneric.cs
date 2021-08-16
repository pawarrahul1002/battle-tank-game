using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    // public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
    // {

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






    //     private static T instance;
    //     public static T Instance { get { return instance; } }
    //     protected virtual void Awake()
    //     {
    //         if (instance == null)
    //         {
    //             instance = (T)this;
    //         }
    //         else
    //         {
    //             Debug.LogError(Instance + "is Tring to create another instance");
    //             Destroy(this);
    //         }
    //     }
    // }
}




// public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoBehaviour
// {
//     private static T instance;

//     private static object m_lock = new Object();

//     public static T GetInstance()
//     {
//         lock (m_lock)
//         {
//             if (instance == null)
//             {
//                 instance = FindObjectOfType<T>();

//                 if (instance == null)
//                 {
//                     GameObject obj = new GameObject();

//                     obj.name = typeof(T).ToString();

//                     instance = obj.AddComponent<T>();

//                     DontDestroyOnLoad(obj);
//                 }
//             }
//         }

//         return instance;
//     }
// }

// }