using UnityEngine;

public class InteractableTree : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject fruit;
    [SerializeField] private int spawnCount = 3;
    [SerializeField] private string interactionMessage = "You shook the Tree";

    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float maxDistance = 3f;

    [SerializeField] private Vector3 spawnOffset = Vector3.zero;

    public void Interact()
    {
        ServiceHub.Instance.UiManager.ShowMessage(interactionMessage);

        for (int i = 0; i < spawnCount; i++)
        {
            float xOffset = Random.Range(minDistance, maxDistance) * (Random.value > 0.5f ? 1 : -1);
            float yOffset = Random.Range(minDistance, maxDistance) * (Random.value > 0.5f ? 1 : -1);

            Vector3 randomOffset = new Vector3(xOffset, yOffset, 0f);
            Instantiate(fruit, transform.position + spawnOffset + randomOffset, Quaternion.identity);
        }
    }

    public void OnFocus()
    {
        ServiceHub.Instance.UiManager.ShowInteractionPrompt(true);
    }

    public void OnUnfocus()
    {
        ServiceHub.Instance.UiManager.ShowInteractionPrompt(false);
    }
}
