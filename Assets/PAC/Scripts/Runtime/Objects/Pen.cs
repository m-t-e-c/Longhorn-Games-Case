using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class Pen : SelectableObject
    {
        public void DrawWhiteBoard(Whiteboard whiteboard)
        {
            whiteboard.Drawn(Color.black);
            Debug.Log("Whiteboard Drawn");
        }
    }
}