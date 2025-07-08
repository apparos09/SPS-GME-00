using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

namespace RM_SPS_GME_00
{
    public class TitleManager : MonoBehaviour
    {
        // The singleton instance.
        private static TitleManager instance;

        // Gets set to 'true' when the singleton has been instanced.
        // This isn't needed, but it helps with the clarity.
        private static bool instanced = false;

        // The title screen UI.
        public TitleUI titleUI;

        // The title audio for the game.
        // public TitleAudio titleAudio;

        // Gets set to 'true' when late start is called.
        private bool calledLateStart = false;

        // Constructor
        private TitleManager()
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

                // // Checks if LOL SDK has been initialized.
                // GameSettings settings = GameSettings.Instance;
                // 
                // // Gets an instance of the LOL manager.
                // SystemManager systemManager = SystemManager.Instance;
                // 
                // // You can save and go back to the menu, so the continue button is usable under that circumstance.
                // if (systemManager.saveSystem.HasLoadedData()) // Game has loaded data.
                // {
                //     // TODO: manage tutorial content.
                // }
                // else // No loaded data.
                // {
                //     // TODO: manage tutorial content.
                // }

                // TODO: do you need this?
                // // Have the button be turned on no matter what for testing purposes.
                // titleUI.continueButton.interactable = true;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            // If the title UI has been instantiated, add it.
            // TODO: maybe create a instance if it doesn't exist?
            if(TitleUI.Instantiated)
            {
                // Gets the instance.
                titleUI = TitleUI.Instance;
            }
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
        public static TitleManager Instance
        {
            get
            {
                // Checks if the instance exists.
                if (instance == null)
                {
                    // Tries to find the instance.
                    instance = FindAnyObjectByType<TitleManager>(FindObjectsInactive.Include);


                    // The instance doesn't already exist.
                    if (instance == null)
                    {
                        // Generate the instance.
                        GameObject go = new GameObject("Title Manager (singleton)");
                        instance = go.AddComponent<TitleManager>();
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