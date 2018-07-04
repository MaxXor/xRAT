using System;
using System.Windows.Forms;
using xServer.Core.Helper;
using xServer.Core.Utilities;

namespace xServer.Controls
{
    internal class AeroListView : ListView
    {
        private const uint WM_CHANGEUISTATE = 0x127;

        private const int UIS_SET = 1;
        private const int UISF_HIDEFOCUS = 0x1;

        public ListViewColumnSorter LvwColumnSorter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AeroListView"/> class.
        /// </summary>
        public AeroListView()
            : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.LvwColumnSorter = new ListViewColumnSorter();
            this.ListViewItemSorter = LvwColumnSorter;
            this.View = View.Details;
            this.FullRowSelect = true;
        }

        /// <summary>
        /// Raises the <see cref="E:HandleCreated" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (PlatformHelper.RunningOnMono) return;

            if (PlatformHelper.VistaOrHigher)
            {
                // set window theme to explorer
                NativeMethods.SetWindowTheme(this.Handle, "explorer", null);
            }

            if (PlatformHelper.XpOrHigher)
            {
                // removes the ugly dotted line around focused item
                NativeMethods.SendMessage(this.Handle, WM_CHANGEUISTATE,
                    NativeMethodsHelper.MakeLong(UIS_SET, UISF_HIDEFOCUS), 0);
            }
        }
        
        /// <summary>
        /// Raises the <see cref="E:ColumnClick" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ColumnClickEventArgs"/> instance containing the event data.</param>
        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == this.LvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                this.LvwColumnSorter.Order = (this.LvwColumnSorter.Order == SortOrder.Ascending)
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                this.LvwColumnSorter.SortColumn = e.Column;
                this.LvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.Sort();
        }
    }
}