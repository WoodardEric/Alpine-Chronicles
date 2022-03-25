using UnityEngine;

namespace SAP2D
{
    public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
    {

        public static T singleton
        {
            get
            {
                if(instance == null)
                {
                    instance = FindObjectOfType<T>();

                    if(instance == null)
                    {
                        Debug.LogError("Singleton " + typeof(T) + " was't found.");
                    }
                }
                return instance;
            }
        }

        private static T instance;
    }
}

