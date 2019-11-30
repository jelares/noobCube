
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public gameManager gameManager;

    private void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
    }
}
