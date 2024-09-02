using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class Whiteboard : CompleteableObject
    {
        [SerializeField] private Transform drawingPoint;
        [SerializeField] private Transform penHolderPoint;
        
        private Renderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        public Transform GetDrawingPoint()
        {
            return drawingPoint;
        }
        
        public Transform GetPenHolderPoint()
        {
            return penHolderPoint;
        }

        public void Drawn(Color color)
        {
            _renderer.material.color = color;
            Complete();
        }
    }
}