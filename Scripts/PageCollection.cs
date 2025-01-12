using TMPro;
using UnityEngine;

public class Collection : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private FirstPersonMovement player;
    [SerializeField] private Flashlight flashlight;
    [SerializeField] private TMP_Text pagesText;

    private int collectedPages = 0;

    private void Start()
    {
        UpdatePagesUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Page"))
        {
            CollectPage(collision.gameObject);
        }
    }

    private void CollectPage(GameObject page)
    {
        collectedPages++;
        UpdatePagesUI();
        page.SetActive(false);

        enemy.AdjustDifficulty(collectedPages);

        flashlight.RechargeBattery(10);

        if (collectedPages >= 2)
        {
            player.EnableSprint();
        }
    }

    private void UpdatePagesUI()
    {
        pagesText.text = $"Pages collected: {collectedPages}";
    }
}
