using UnityEngine;

namespace RM_SPS_GME_00
{
    public class TitleUI : MonoBehaviour
    {
        // The singleton instance.
        private static TitleUI instance;

        // Gets set to 'true' when the singleton has been instanced.
        // This isn't needed, but it helps with the clarity.
        private static bool instanced = false;

        // The title manager.
        public TitleManager titleManager;

        // The title audio for the game.
        // public TitleAudio titleAudio;

        // Gets set to 'true' when late start is called.
        private bool calledLateStart = false;

        // Constructor
        private TitleUI()
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

        // Start is called before the first frame update
        void Start()
        {
            // Gets the title manager instance.
            if (titleManager == null)
                titleManager = TitleManager.Instance;
        }

        // Called on the first update frame.
        public void LateStart()
        {
            // Late start has been called.
            calledLateStart = true;

            // Makes sure the audio is adjusted to the current settings.
            // For some reason, this doesn't happen properly in the LOL harness when done in Start()...
            // By other scripts, so it's done here to make another correction.
            // Opening the settings window automatically adjusts the audio levels...
            // So doing this in the title script should be fine.
            // GameSettings.Instance.AdjustAllAudioLevels();
        }

        // Gets the instance.
        public static TitleUI Instance
        {
            get
            {
                // Checks if the instance exists.
                if (instance == null)
                {
                    // Tries to find the instance.
                    instance = FindAnyObjectByType<TitleUI>(FindObjectsInactive.Include);


                    // The instance doesn't already exist.
                    if (instance == null)
                    {
                        // Generate the instance.
                        GameObject go = new GameObject("Title UI (singleton)");
                        instance = go.AddComponent<TitleUI>();
                    }

                }

                // Return the instance.
                return instance;
            }
        }

        // Returns 'true' if the object has been initialized.
        public static bool Instantiated
        {
            get
            {
                return instanced;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}