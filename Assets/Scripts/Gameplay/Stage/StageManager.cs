using UnityEngine;

namespace RM_SPS_GME_00
{
    // The stage manager.
    public class StageManager : MonoBehaviour
    {
        // The singleton instance.
        private static StageManager instance;

        // Gets set to 'true' when the singleton has been instanced.
        // This isn't needed, but it helps with the clarity.
        private static bool instanced = false;

        // Calculates the time the stage has been running.
        private float stageTime = 0.0F;

        public StageNodeList stageNodeList;

        // Constructor
        private StageManager()
        {
            // ...
        }

        // Awake is called when the script is being loaded
        protected virtual void Awake()
        {
            // If the instance hasn't been set, set it to this object.
            if (instance == null)
            {
                instance = this;
            }
            // If the instance isn't this, destroy the game object.
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

            // Run code for initialization.
            if (!instanced)
            {
                instanced = true;
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Gets the instance.
        public static StageManager Instance
        {
            get
            {
                // Checks if the instance exists.
                if (instance == null)
                {
                    // Tries to find the instance.
                    instance = FindAnyObjectByType<StageManager>(FindObjectsInactive.Include);


                    // The instance doesn't already exist.
                    if (instance == null)
                    {
                        // Generate the instance.
                        GameObject go = new GameObject("StageManager (singleton)");
                        instance = go.AddComponent<StageManager>();
                    }

                }

                // Return the instance.
                return instance;
            }
        }

        // Returns 'true' if the object has been instanced.
        public static bool Instantiated
        {
            get
            {
                return instanced;
            }
        }

        // Gets the stage time.
        public float GetStageTime()
        {
            return stageTime;
        }

        // Update is called once per frame
        void Update()
        {
            // TODO: check if the gmae is paused.
            // stageTime += Time.unscaledDeltaTime;
        }

        // This function is called when the MonoBehaviour will be destroyed.
        protected void OnDestroy()
        {
            // If the saved instance is being deleted, set 'instanced' to false.
            if (instance == this)
            {
                instanced = false;
            }
        }
    }
}