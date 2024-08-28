using UnityEngine;

namespace PAC.Scripts.Runtime.Objects
{
    public class Whiteboard : CompleteableObject
    {
        private Renderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        public void Drawn(Color color)
        {
            _renderer.material.color = color;
            Complete();
        }
    }
}