using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour {
    public void TakeScreenshot() {
        string screenshotPath = Path.Combine(Application.persistentDataPath, "Screenshots");
        Directory.CreateDirectory(screenshotPath); // Ensure folder exists
        string filename = $"Screenshot_{System.DateTime.Now:yyyyMMdd_HHmmss}.png";
        ScreenCapture.CaptureScreenshot(Path.Combine(screenshotPath, filename));
        Debug.Log($"Screenshot saved to: {screenshotPath}");
    }
}