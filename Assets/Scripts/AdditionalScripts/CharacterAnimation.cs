using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public float swayAngle = 10f; // The maximum angle the character will sway to.
    public float swayDuration = 0.5f; // Duration for one side sway
    
    private int _swayDirection = 1; //should I sway right or left

    private void Start()
    {
        StartCoroutine(Sway()); //start swaying animation
    }

    private IEnumerator Sway()
    {
        float elapsedTime = 0; //how longe have I been swaying
        var initialRotation = transform.rotation;
        _swayDirection *= -1; // Change direction for the next sway

        // Calculate the sway rotation
        float targetAngle = _swayDirection * swayAngle; //angle to use for rotation
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle); //Quaternion represents rotation and allows for interpolation

        while (elapsedTime < swayDuration) //keep rotation for "swayDuration"
        {
            elapsedTime += Time.deltaTime; 
            float progress = elapsedTime / swayDuration;
            float easedProgress = EaseInOutQuad(progress); // Use the easing function
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, easedProgress); //interpolate between start end target rotation
            yield return null; //return the control to go to the next frame
        }

        // Sway back to the initial rotation with easing
        elapsedTime = 0; // Reset elapsedTime for the return sway
        while (elapsedTime < swayDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / swayDuration;
            float easedProgress = EaseInOutQuad(progress); // Use the easing function
            transform.rotation = Quaternion.Lerp(targetRotation, initialRotation, easedProgress);
            yield return null;
        }
        
        // When input.magnitude is 0, stop swaying and reset rotation
        transform.rotation = initialRotation;
        // Restart swaying animation
        StartCoroutine(Sway());

    }
    
    // Easing function for smooth start and end
    private float EaseInOutQuad(float progress)
    {
        if (progress < 0.5f)
        {
            return 2 * progress * progress;
        }
        else
        {
            return -1 + (4 - 2 * progress) * progress;
        }
    }
}
