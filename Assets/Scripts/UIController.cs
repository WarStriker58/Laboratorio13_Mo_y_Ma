using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private RectTransform uiElement;
    [SerializeField] private Image uiImage;
    [SerializeField] private Text uiText;

    [Header("Animation Settings")]
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Vector3 targetScale;
    [SerializeField] private Vector3 targetRotation;
    [SerializeField] private float duration = 1f;
    [SerializeField] private Ease easeType = Ease.InOutQuad;

    private void Start()
    {
        AnimateUIElement();
    }

    public void AnimateUIElement()
    {
        Sequence uiSequence = DOTween.Sequence();

        uiSequence.Append(uiElement.DOAnchorPos(targetPosition, duration).SetEase(easeType));

        uiSequence.Join(uiElement.DOScale(targetScale, duration).SetEase(easeType));

        uiSequence.Join(uiElement.DORotate(targetRotation, duration, RotateMode.FastBeyond360).SetEase(easeType));

        if (uiImage != null)
        {
            uiSequence.Join(uiImage.DOColor(Color.red, duration).SetEase(easeType));
        }

        if (uiText != null)
        {
            uiSequence.Join(uiText.DOFade(0f, duration).SetEase(easeType));
        }

        uiSequence.Play();
    }
}