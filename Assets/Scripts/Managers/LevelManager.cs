using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject levelThree;
    public GameObject levelFour;

    private GameObject player;

    private GameObject currentActiveLevel;

    private void Start()
    {
        player = ServiceHub.Instance.playerController.gameObject;
        currentActiveLevel = levelOne;
    }

    public void LevelChange(Transform spawnLocation, GameObject LevelToActivate)
    {
        currentActiveLevel.SetActive(false);
        LevelToActivate.SetActive(true);
        currentActiveLevel = LevelToActivate;

        player.transform.position = spawnLocation.position;

    }
}