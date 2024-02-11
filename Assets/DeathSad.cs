using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSad : MonoBehaviour
{
    public string attackTag = "Attack"; // Tag to check for collision
    public Sprite deathSprite; // Sprite for the death effect

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider's tag matches the attackTag
        if (other.CompareTag(attackTag))
        {
            // Destroy the parent object
            Destroy(transform.parent.gameObject);

            // Create a new GameObject for the death sprite
            GameObject deathSpriteObject = new GameObject("DeathSprite");
            deathSpriteObject.transform.position = transform.position;

            // Add SpriteRenderer component and set the sprite
            SpriteRenderer spriteRenderer = deathSpriteObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = deathSprite;

            // Optionally, you can add fading behavior here
            FadeOut(deathSpriteObject, 3f);
        }
    }


    IEnumerator FadeOut(GameObject obj, float duration)
    {
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        Color startColor = spriteRenderer.color;
        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            spriteRenderer.color = Color.Lerp(startColor, Color.clear, t);
            yield return null;
        }

        // Destroy the sprite object after fading out
        Destroy(obj);
    }
}