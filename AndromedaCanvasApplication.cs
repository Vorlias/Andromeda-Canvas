using AndromedaCanvas.Canvas;
using Andromeda2D.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaCanvas.Canvas
{
    public class CanvasApplication : Application
    {
        private BackgroundWorker _renderWorker;
        private DrawingSurface _control;
        public delegate void CanvasFrameEvent();

        public event CanvasFrameEvent OnUpdate;
        public event CanvasFrameEvent OnRender;

        public CanvasApplication(DrawingSurface handle) : base(handle.Handle)
        {
            _renderWorker = new BackgroundWorker();
            _control = handle;
            handle.CustomRenderingEnabled = true;
        }

        protected override void Update()
        {
            OnUpdate?.Invoke();
        }

        protected override void Render()
        {
            OnRender?.Invoke();
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

        private void WorkProcess(object sender, DoWorkEventArgs e)
        {
            InitializeApplication();
            while (Window.IsOpen)
            {
                UpdateDeltaClock();

                UpdateEvents();

                UpdateRendering();
            }
        }
    }
}
