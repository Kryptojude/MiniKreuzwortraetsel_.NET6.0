namespace KreuzworträtselGenerator
{
    abstract class PaintObject
    {
        //
        //  <--- static --->
        //
        public static List<PaintObject> PaintObjectList { get; }

        static PaintObject()
        {
            PaintObjectList = new List<PaintObject>();
        }

        //
        //  <--- instance --->
        //
        protected Rectangle Bounds_global { get; }
        Rectangle Bounds_local { get; }
        public bool RepaintFlag { get; set; }

        public PaintObject(Rectangle bounds_global)
        {
            Bounds_global = bounds_global;
            Bounds_local = new Rectangle(0, 0, bounds_global.Width, bounds_global.Height);
            RepaintFlag = true;
        }
        public void Paint(Graphics g)
        {
            BeginPaint(g);
            PaintOperations(g);
            EndPaint(g);
        }
        void BeginPaint(Graphics g)
        {
            // Block painting out of bounds
            g.SetClip(Bounds_global);
            // Set coordinate system origin to this location
            g.TranslateTransform(Bounds_global.Location.X, Bounds_global.Location.Y);
            // Clear
            g.FillRectangle(Brushes.White, Bounds_local);

        }
        protected abstract void PaintOperations(Graphics g);
        void EndPaint(Graphics g)
        {
            g.ResetTransform();
            g.ResetClip();
        }
    }
}
