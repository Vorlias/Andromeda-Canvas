using Andromeda.Canvas;
using Andromeda2D.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andromeda.Canvas
{
    public class AndromedaCanvasApplication : Application
    {
        private BackgroundWorker _renderWorker;
        private AndromedaCanvas _control;
        public delegate void CanvasFrameEvent();

        public event CanvasFrameEvent OnUpdate;
        public event CanvasFrameEvent OnRender;

        internal AndromedaCanvasApplication(AndromedaCanvas handle) : base(handle.Handle)
        {
            _renderWorker = new BackgroundWorker();
            handle._controller = this;
            _control = handle;
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
            InitializeApplication();
            _renderWorker.DoWork += WorkProcess;
            _renderWorker.RunWorkerAsync(_control);
        }

        private void WorkProcess(object sender, DoWorkEventArgs e)
        {
            while (Window.IsOpen)
            {
                UpdateDeltaClock();

                UpdateEvents();

                UpdateRendering();
            }
        }
    }
}
