using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.DesktopEdition;

namespace CustomTrackLine
{
    class CustomTrackInteractiveOverlay : TrackInteractiveOverlay
    {
        public CustomTrackInteractiveOverlay()
            : base()
        {
            this.TrackMode = TrackMode.Line;
        }

        protected override InteractiveResult MouseDownCore(InteractionArguments interactionArguments)
        {
            
            if (interactionArguments.MouseButton != MapMouseButton.Right)
                return base.MouseDownCore(interactionArguments);
            else
                RemoveLastVertexAdded();
                return new InteractiveResult();
        }

        private void RemoveLastVertexAdded()
        {
            int minVertex = 2;
            if (this.Vertices.Count > minVertex)
            {
                this.Lock.EnterWriteLock();
                try
                {
                    Vertex lastVertex = this.Vertices[this.Vertices.Count - 2];
                    this.Vertices.Remove(lastVertex);
                }
                finally
                {
                    this.Lock.ExitWriteLock();
                }
            }
       }
    }
}
