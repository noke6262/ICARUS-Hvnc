using System.Collections;
using System.Windows.Forms;

namespace ICARUS
{
    public class ListViewColumnSorter : IComparer
    {
        private int _columnToSort;

        private SortOrder _orderOfSort;

        private readonly CaseInsensitiveComparer _objectCompare;

        public int SortColumn
        {
            get
            {
                return this._columnToSort;
            }
            set
            {
                this._columnToSort = value;
            }
        }

        public SortOrder Order
        {
            get
            {
                return this._orderOfSort;
            }
            set
            {
                this._orderOfSort = value;
            }
        }

        public ListViewColumnSorter()
        {
            this._columnToSort = 0;
            this._orderOfSort = SortOrder.None;
            this._objectCompare = new CaseInsensitiveComparer();
        }

        public int Compare(object object_0, object object_1)
        {
            ListViewItem listViewItem = (ListViewItem)object_0;
            ListViewItem listViewItem2 = (ListViewItem)object_1;
            if (!(listViewItem.SubItems[0].Text == "..") && !(listViewItem2.SubItems[0].Text == ".."))
            {
                int num = this._objectCompare.Compare(listViewItem.SubItems[this._columnToSort].Text, listViewItem2.SubItems[this._columnToSort].Text);
                if (this._orderOfSort == SortOrder.Ascending)
                {
                    return num;
                }
                if (this._orderOfSort == SortOrder.Descending)
                {
                    return -num;
                }
                return 0;
            }
            return 0;
        }
    }
}