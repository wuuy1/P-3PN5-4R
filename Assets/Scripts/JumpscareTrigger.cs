using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JumpscareTrigger : MonoBehaviour
{
    public Image jumpscareImage;
    public AudioSource jumpscareSound;
    public float jumpscareDuration = 5f;

    private void Start()
    {
        // patikrina, kad pradzioj jumpscare image nesimatytu
        jumpscareImage.color = new Color(jumpscareImage.color.r, jumpscareImage.color.g, jumpscareImage.color.b, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TriggerJumpscare());
        }
    }

    private IEnumerator TriggerJumpscare()
    {
        // paleidzia jumpscare
        jumpscareImage.color = new Color(jumpscareImage.color.r, jumpscareImage.color.g, jumpscareImage.color.b, 1);
        jumpscareSound.Play();

        // laukia kito jumpscare
        yield return new WaitForSeconds(jumpscareDuration);

        // paslepia image
        jumpscareImage.color = new Color(jumpscareImage.color.r, jumpscareImage.color.g, jumpscareImage.color.b, 0);
    }
}