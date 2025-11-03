

public static class Utils
{
    public static float CalculateAcceleration(int stage, float maxAcceleration, float currentSpeed)
    {
        currentSpeed *= 3.6f;
        switch (stage)
        {
            case 1:
                {
                    if (currentSpeed > 40f) return maxAcceleration * 0.1f;
                    if (currentSpeed < 20f && currentSpeed < 40f) return maxAcceleration * 1.2f;
                    if (currentSpeed < 20f) return maxAcceleration;
                    break;
                }
            case 2:
                {
                    if (currentSpeed > 60f) return maxAcceleration * 0.1f;
                    if (currentSpeed > 40f && currentSpeed < 60f) return maxAcceleration * 1.2f;
                    if (currentSpeed > 20f && currentSpeed < 40f) return maxAcceleration;
                    if (currentSpeed < 20f) return maxAcceleration * 0.8f;
                    break;
                }
            case 3:
                {
                    if (currentSpeed > 80f) return maxAcceleration * 0.1f;
                    if (currentSpeed > 60f && currentSpeed < 80f) return maxAcceleration * 1.2f;
                    if (currentSpeed > 40f && currentSpeed < 60f) return maxAcceleration;
                    if (currentSpeed > 20f && currentSpeed < 40f) return maxAcceleration * 0.8f;
                    if (currentSpeed < 20f) return maxAcceleration * 0.5f;
                    break;
                }
            case 4:
                {
                    if (currentSpeed > 100f) return maxAcceleration * 0.1f;
                    if (currentSpeed > 80f && currentSpeed < 100f) return maxAcceleration * 1.2f;
                    if (currentSpeed > 60f && currentSpeed < 80f) return maxAcceleration;
                    if (currentSpeed > 40f && currentSpeed < 60f) return maxAcceleration * 0.8f;
                    if (currentSpeed > 20f && currentSpeed < 40f) return maxAcceleration * 0.5f;
                    if (currentSpeed < 20f) return maxAcceleration * 0.3f;
                    break;
                }
            case 5:
                {
                    if (currentSpeed > 120f) return maxAcceleration * 0.1f;
                    if (currentSpeed > 100f && currentSpeed < 120f) return maxAcceleration * 1.2f;
                    if (currentSpeed > 80f && currentSpeed < 100f) return maxAcceleration;
                    if (currentSpeed > 60f && currentSpeed < 80f) return maxAcceleration * 0.8f;
                    if (currentSpeed > 40f && currentSpeed < 60f) return maxAcceleration * 0.5f;
                    if (currentSpeed > 20f && currentSpeed < 40f) return maxAcceleration * 0.3f;
                    if (currentSpeed < 20f) return maxAcceleration * 0.1f;
                    break;
                }
        }
        return maxAcceleration;
    }

}
