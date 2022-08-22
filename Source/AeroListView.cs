using System;
using System.Windows.Forms;

namespace ICARUS
{
    internal class AeroListView : ListView
    {
        private readonly IntPtr _removeDots = new IntPtr(NativeMethodsHelper.MakeWin32Long(1, 1));

        private ListViewColumnSorter LvwColumnSorter { get; set; }

        public AeroListView()
        {
            base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
            this.LvwColumnSorter = new ListViewColumnSorter();
            base.ListViewItemSorter = this.LvwColumnSorter;
            base.View = View.Details;
            base.FullRowSelect = true;
        }

        protected override void OnHandleCreated(EventArgs eventArgs_0)
        {
            base.OnHandleCreated(eventArgs_0);
            if (!PlatformHelper.RunningOnMono)
            {
                if (PlatformHelper.VistaOrHigher)
                {
                    NativeMethods.SetWindowTheme(base.Handle, "explorer", null);
                }
                if (PlatformHelper.XpOrHigher)
                {
                    NativeMethods.SendMessage(base.Handle, 295u, this._removeDots, IntPtr.Zero);
                }
            }
        }

        protected override void OnColumnClick(ColumnClickEventArgs columnClickEventArgs_0)
        {
            base.OnColumnClick(columnClickEventArgs_0);
            if (columnClickEventArgs_0.Column == this.LvwColumnSorter.SortColumn)
            {
                this.LvwColumnSorter.Order = ((this.LvwColumnSorter.Order != SortOrder.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
            }
            else
            {
                this.LvwColumnSorter.SortColumn = columnClickEventArgs_0.Column;
                this.LvwColumnSorter.Order = SortOrder.Ascending;
            }
            if (!base.VirtualMode)
            {
                base.Sort();
            }
        }
    }
}