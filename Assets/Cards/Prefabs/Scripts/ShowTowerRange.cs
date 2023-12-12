using UnityEngine;

public class ShowTowerRange : MonoBehaviour
{
    private LineRenderer lineRendererComponent;

    public int steps;
    public float radius;

    private void Awake()
    {
        lineRendererComponent = GetComponent<LineRenderer>();
        DrawCercleArea(steps, radius);
    }

    private void DrawCercleArea(int steps, float radius)
    {
        lineRendererComponent.positionCount = steps;

        for (int i = 0; i < steps;  i++)
        {
            float circumferenceProgress = (float)i / steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float zScaled = Mathf.Sin(currentRadian);

            float x = (xScaled * radius) + this.transform.position.x;
            float z = (zScaled * radius) + this.transform.position.z;

            Vector3 currentPosition = new Vector3(x, this.transform.position.y + 0.3f, z);

            lineRendererComponent.SetPosition(i, currentPosition);
        }
    }
}
