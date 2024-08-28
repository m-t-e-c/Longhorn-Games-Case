using UnityEngine;

namespace PAC.Scripts.Runtime
{
    public class Whiteboard : MonoBehaviour
    {
        private Renderer _renderer;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        public void Drawn(Color color)
        {
            _renderer.material.color = color;
        }
    }
}