using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float initialTime = 60f;
    private float currentTime;

    // Variables for increasing timer gradually
    private bool isIncreasing = false;
    private float increaseTimerDuration = 400f; // Adjust the duration for slower increase
    private float increaseTimerStartTime;
    private float targetIncreaseTime;

    void Start()
    {
        currentTime = initialTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!isIncreasing && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (isIncreasing)
        {
            float timeSinceStarted = Time.time - increaseTimerStartTime;
            float percentageComplete = timeSinceStarted / increaseTimerDuration;

            currentTime = Mathf.Lerp(currentTime, targetIncreaseTime, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                isIncreasing = false;
                currentTime = targetIncreaseTime;
            }

            UpdateTimerDisplay();
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            // Perform actions when timer reaches zero (e.g., game over)
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void IncreaseTimerWithDelay()
    {
        if (!isIncreasing && currentTime > 0)
        {
            StartCoroutine(IncreaseTimerCoroutine());
        }
    }

    private System.Collections.IEnumerator IncreaseTimerCoroutine()
    {
        isIncreasing = true;
        targetIncreaseTime = currentTime + 30f;
        increaseTimerStartTime = Time.time;
        
        yield return new WaitForSeconds(2f); // 1-second delay
        
        isIncreasing = false;
    }
}
