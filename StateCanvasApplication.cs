using Andromeda2D.System;
using System.ComponentModel;

namespace AndromedaCanvas.Canvas
{
    /// <summary>
    /// A state canvas application
    /// </summary>
    public class StateCanvasApplication : StateApplication
    {
        private BackgroundWorker _renderWorker;
        private DrawingSurface _control;

        public StateCanvasApplication(DrawingSurface handle) : base(handle.Handle)
        {
            _renderWorker = new BackgroundWorker();
            _control = handle;
            handle.CustomRenderingEnabled = true;
        }

        public override void Run()
        {
            _renderWorker.DoWork += WorkProcess;
            _renderWorker.RunWorkerAsync(_control);
        }

        /// <summary>
        /// Performs the update actions
        /// </summary>
        protected override void UpdateEvents()
        {
            System.Windows.Forms.Application.DoEvents();
            Window.DispatchEvents();
            Update();
        }

        public virtual void BeforeWork()
        {

        }

        private void WorkProcess(object sender, DoWorkEventArgs e)
        {
            InitializeApplication();
            BeforeWork();
            while (Window.IsOpen)
            {
                UpdateDeltaClock();

                UpdateEvents();

                UpdateRendering();
            }
        }
    }
}
