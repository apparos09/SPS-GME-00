using UnityEngine;

namespace RM_SPS_GME_00
{
    // A node for the stage, which is used for moving the stage window.
    public class StageNode : MonoBehaviour
    {
        // The stage node list.
        public StageNodeList stageNodeList;
       
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // If the list this node is part of has not been set.
            if(stageNodeList == null)
            {
                // Set the node list.
                stageNodeList = GetComponentInParent<StageNodeList>();
            }
        }

        // Called when the node has been set as the next target.
        public void OnNodeTargeted()
        {
            // ...
        }

        // Called when the node has been reached.
        public void OnNodeEnter()
        {
            // ...
        }

        // Called when the node has been abandoned.
        public void OnNodeExit()
        {
            // ...
        }

        // // Update is called once per frame
        // void Update()
        // {
        // 
        // }
    }
}