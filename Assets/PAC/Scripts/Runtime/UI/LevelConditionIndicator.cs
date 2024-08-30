using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PAC.Scripts.Runtime.UI
{
    public class LevelConditionIndicator : MonoBehaviour
    {
        [SerializeField] private Image notCompletedIcon;
        [SerializeField] private Image completedIcon;

        public void SetCompleted()
        {
            notCompletedIcon.transform.DOScale(0f, 0.2f);
            completedIcon.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        }
    }
}