namespace YTArchiveCollector.Helpers
{
    internal static class AnimationManager
    {
        internal static async void AnimatedChangeControlHeight(Control ControlToChange, int NewHeight)
        {
            await Task.Run(() =>
            {
                int OldHeight = ControlToChange.Height;
                if (NewHeight > OldHeight)
                    RaiseControlHeight(ControlToChange, NewHeight, OldHeight);
                else
                    LoweriseControlHeight(ControlToChange, NewHeight, OldHeight);
            });
        }

        private static void RaiseControlHeight(Control ControlToChange, int NewHeight, int OldHeight)
        {
            while (OldHeight < NewHeight)
            {
                OldHeight += OldHeight / 13;
                ControlToChange.Height = OldHeight;
                Thread.Sleep(1);
            }
        }

        private static void LoweriseControlHeight(Control ControlToChange, int NewHeight, int OldHeight)
        {
            while (OldHeight > NewHeight)
            {
                OldHeight -= OldHeight / 13;
                ControlToChange.Height = OldHeight;
                Thread.Sleep(1);
            }
        }

    }
}
