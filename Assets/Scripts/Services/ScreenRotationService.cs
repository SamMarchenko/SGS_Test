using UnityEngine;

namespace Services
{
    public class ScreenRotationService
    {
        public enum Orientation
        {
            Any,
            Portrait
        }

        public void SetOrientation(Orientation value)
        {
            switch (value)
            {
                case Orientation.Any:
                    Screen.orientation = ScreenOrientation.AutoRotation;
                    Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                    Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                    break;

                case Orientation.Portrait:
                    Screen.orientation = ScreenOrientation.Portrait;
                    Screen.orientation = ScreenOrientation.AutoRotation;

                    Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                    Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
                    break;
            }
        }
    }
}