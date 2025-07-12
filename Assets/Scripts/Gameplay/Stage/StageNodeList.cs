using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RM_SPS_GME_00
{
    // The stage nodes.
    public class StageNodeList : MonoBehaviour
    {
        // The nodes for the stage.
        public List<StageNode> nodes = new List<StageNode>();

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // If there are no nodes, try getting a list of node objects in the children.
            if(nodes.Count == 0)
            {
                // Gets the node children as a list.
                nodes = new List<StageNode>(GetComponentsInChildren<StageNode>());

                // Sets this as the node list for this node.
                foreach(StageNode node in nodes)
                {
                    node.stageNodeList = this;
                }
            }
        }
    }
}