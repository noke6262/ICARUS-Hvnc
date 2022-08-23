using BirdBrainmofo.JCS;

namespace BirdBrainmofo.ToggleSwitch
{
    public class BeforeRenderingEventArgs
    {
        public ToggleSwitchRendererBase Renderer { get; set; }

        public BeforeRenderingEventArgs(ToggleSwitchRendererBase renderer)
        {
            this.Renderer = renderer;
        }
    }
}