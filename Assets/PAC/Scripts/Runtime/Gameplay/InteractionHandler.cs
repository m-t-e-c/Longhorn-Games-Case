using UnityEngine;

namespace PAC.Scripts.Runtime
{
    public class InteractionHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask interactionLayer;
        private Camera _camera;
        
        private SelectableObject _currentSelectedObject;
        
        private void Awake()
        {
            _camera = Camera.main;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, interactionLayer))
                {
                    if (hit.collider.TryGetComponent(out SelectableObject selectableObject))
                    {
                        _currentSelectedObject?.Deselect();
                        _currentSelectedObject = selectableObject;
                        _currentSelectedObject.Select();
                        return;
                    }
                    
                    if (_currentSelectedObject != null && _currentSelectedObject.gameObject != hit.collider.gameObject)
                    {
                        var strategy = _currentSelectedObject.GetStrategyForMatch(hit.collider.gameObject);
                        strategy?.Execute(_currentSelectedObject.transform, hit.transform);
                    }
                }
            }
        }
    }
}