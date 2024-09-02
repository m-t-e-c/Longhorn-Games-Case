using Cysharp.Threading.Tasks;
using PAC.Scripts.Runtime.Objects;
using UnityEngine;

namespace PAC.Scripts.Runtime.Gameplay
{
    public class InteractionHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask interactionLayer;
        private Camera _camera;
        private SelectableObject _currentSelectedObject;
        private bool _isStrategyProcessing;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_isStrategyProcessing)
            {
                HandleMouseClick();
            }
        }

        private void HandleMouseClick()
        {
            if (TryGetRaycastHit(out RaycastHit hit))
            {
                HandleRaycastHit(hit);
            }
            else
            {
                DeselectCurrentObject();
            }
        }

        private bool TryGetRaycastHit(out RaycastHit hit)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out hit, Mathf.Infinity, interactionLayer);
        }

        private void HandleRaycastHit(RaycastHit hit)
        {
            HandleActivation(hit);
            HandleSelection(hit);
            HandleStrategyAsync(hit).Forget(); // Use Forget to handle the async task without awaiting it in this context
        }

        private void HandleActivation(RaycastHit hit)
        {
            if (hit.collider.TryGetComponent(out IActivateable activateable))
            {
                activateable.Activate();
            }
        }

        private void HandleSelection(RaycastHit hit)
        {
            if (hit.collider.TryGetComponent(out SelectableObject selectableObject) && !selectableObject.IsUsed)
            {
                DeselectCurrentObjectIfNeeded(selectableObject);
                SelectObject(selectableObject);
            }
        }

        private void DeselectCurrentObjectIfNeeded(SelectableObject newSelection)
        {
            if (_currentSelectedObject != null && _currentSelectedObject != newSelection && !_currentSelectedObject.IsUsed)
            {
                _currentSelectedObject.Deselect();
            }
        }

        private void SelectObject(SelectableObject newSelection)
        {
            _currentSelectedObject = newSelection;
            _currentSelectedObject.Select();
        }

        private void DeselectCurrentObject()
        {
            _currentSelectedObject?.Deselect();
            _currentSelectedObject = null;
        }

        private async UniTaskVoid HandleStrategyAsync(RaycastHit hit)
        {
            if (_currentSelectedObject == null || _currentSelectedObject.gameObject == hit.collider.gameObject)
                return;

            var strategy = _currentSelectedObject.GetStrategyForMatch(hit.collider.gameObject);
            if (strategy == null)
                return;

            _isStrategyProcessing = true;

            bool result = await strategy.Execute(_currentSelectedObject.transform, hit.transform);
            if (result)
            {
                _currentSelectedObject = null;
            }

            _isStrategyProcessing = false;
        }
    }
}
