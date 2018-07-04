using System.Collections;
using System.Windows.Forms;
using xServer.Core.Data;

namespace xServer.Core.Utilities
{
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int _columnToSort;

        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder _orderOfSort;

        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private readonly CaseInsensitiveComparer _objectCompare;

        private bool _needNumberCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            _columnToSort = 0;

            // Initialize the sort order to 'none'
            _orderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            _objectCompare = new CaseInsensitiveComparer();

            _needNumberCompare = false;

        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            // Cast the objects to be compared to ListViewItem objects
            var listviewX = (ListViewItem)x;
            var listviewY = (ListViewItem)y;

            if (listviewX.SubItems[0].Text == ".." || listviewY.SubItems[0].Text == "..")
                return 0;

            // Compare the two items
            int compareResult = 0;

            if (_needNumberCompare)
            {
                long a, b;

                if (listviewX.Tag is FileManagerListTag)
                {
                    // fileSize to be compared
                    a = (listviewX.Tag as FileManagerListTag).fileSize;
                    b = (listviewY.Tag as FileManagerListTag).fileSize;
                    compareResult = a >= b ? (a == b ? 0 : 1) : -1;

                }
                else
                {
                    if (long.TryParse(listviewX.SubItems[_columnToSort].Text, out a)
                        && long.TryParse(listviewY.SubItems[_columnToSort].Text, out b))
                    {
                        compareResult = a >= b ? (a == b ? 0 : 1) : -1;
                    }
                    else
                    {
                        compareResult = _objectCompare.Compare(listviewX.SubItems[_columnToSort].Text,
                     listviewY.SubItems[_columnToSort].Text);
                    }
                }
            }
            else
            {
                compareResult = _objectCompare.Compare(listviewX.SubItems[_columnToSort].Text,
                    listviewY.SubItems[_columnToSort].Text);
            }

            // Calculate correct return value based on object comparison
            if (_orderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (_orderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set { _columnToSort = value; }
            get { return _columnToSort; }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set { _orderOfSort = value; }
            get { return _orderOfSort; }
        }

        public bool NeedNumberCompare
        {
            set { _needNumberCompare = value; }
            get { return _needNumberCompare; }
        }


    }
}