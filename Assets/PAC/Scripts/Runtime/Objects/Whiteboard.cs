using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class Whiteboard : CompleteableObject
    {
        [SerializeField] private Transform drawingPoint;
        private Renderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        public Transform GetDrawingPoint()
        {
            return drawingPoint;
        }

        public void Drawn(Color color)
        {
            _renderer.material.color = color;
            Complete();
        }
    }
}