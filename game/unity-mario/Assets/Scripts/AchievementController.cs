using UnityEngine;

public class AchievementController : MonoBehaviour {

    public SpriteRenderer collectRingSpriteRenderer;
    public SpriteRenderer killOctiopusSpriteRenderer;
    public SpriteRenderer passStarPostSpriteRenderer;

    void Start() {
        Sprite[] monitorSprites = Resources.LoadAll<Sprite>("Sprites/monitors");
        Sprite achievementReachedMonitor = monitorSprites[3];
        if (PlayerPrefs.GetInt(EnemyOctopusDestroy.DESTROY_FIRST_OCTOPUS) == 1)
        {
            killOctiopusSpriteRenderer.sprite = achievementReachedMonitor;
        }
        if (PlayerPrefs.GetInt(UIController.RINGS_30_ACH) == 1)
        {
            collectRingSpriteRenderer.sprite = achievementReachedMonitor;
        }
        if (PlayerPrefs.GetInt(PassDetector.STAR_POST_PASSED) == 1)
        {
            passStarPostSpriteRenderer.sprite = achievementReachedMonitor;
        }
	}

}
