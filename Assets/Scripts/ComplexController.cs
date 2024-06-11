using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ComplexController : MonoBehaviour
{
    [SerializeField] private Transform[] Bodies;

    [ContextMenu("Run Animations")]
    public void RunSequences()
    {
        Tasks();
    }

    private async void AsynSequence()
    {
        foreach (Transform item in Bodies)
        {
            await item.DOScale(Vector3.one * Random.Range(0.5f, 2.5f), 1f).SetEase(Ease.InOutQuad).AsyncWaitForCompletion();
        }
    }

    private async void Tasks()
    {
        List<Task> currentTasks = new List<Task>();

        foreach (Transform item in Bodies)
        {
            currentTasks.Add(item.DOScale(Vector3.one * Random.Range(0.5f, 2.5f), 1f).SetEase(Ease.InOutQuad).AsyncWaitForCompletion());
        }

        await Task.WhenAll(currentTasks);
    }
}