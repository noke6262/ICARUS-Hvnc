using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ICARUS.HVNC.Controls
{
    public class RJDropdownMenu : ContextMenuStrip
    {
        private bool isMainMenu;

        private int menuItemHeight = 25;

        private Color menuItemTextColor = Color.Empty;

        private Color primaryColor = Color.Empty;

        private Bitmap menuItemHeaderSize;

        [Category("RJ Code Advance")]
        public bool IsMainMenu
        {
            get
            {
                return this.isMainMenu;
            }
            set
            {
                this.isMainMenu = value;
            }
        }

        [Category("RJ Code Advance")]
        public int MenuItemHeight
        {
            get
            {
                return this.menuItemHeight;
            }
            set
            {
                this.menuItemHeight = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color MenuItemTextColor
        {
            get
            {
                return this.menuItemTextColor;
            }
            set
            {
                this.menuItemTextColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color PrimaryColor
        {
            get
            {
                return this.primaryColor;
            }
            set
            {
                this.primaryColor = value;
            }
        }

        public RJDropdownMenu(IContainer container)
            : base(container)
        {
        }

        private void LoadMenuItemHeight()
        {
            if (this.isMainMenu)
            {
                this.menuItemHeaderSize = new Bitmap(25, 45);
            }
            else
            {
                this.menuItemHeaderSize = new Bitmap(20, this.menuItemHeight);
            }
            foreach (ToolStripMenuItem item in this.Items)
            {
                item.ImageScaling = ToolStripItemImageScaling.None;
                if (item.Image == null)
                {
                    item.Image = this.menuItemHeaderSize;
                }
                foreach (ToolStripMenuItem dropDownItem in item.DropDownItems)
                {
                    dropDownItem.ImageScaling = ToolStripItemImageScaling.None;
                    if (dropDownItem.Image == null)
                    {
                        dropDownItem.Image = this.menuItemHeaderSize;
                    }
                    foreach (ToolStripMenuItem dropDownItem2 in dropDownItem.DropDownItems)
                    {
                        dropDownItem2.ImageScaling = ToolStripItemImageScaling.None;
                        if (dropDownItem2.Image == null)
                        {
                            dropDownItem2.Image = this.menuItemHeaderSize;
                        }
                        foreach (ToolStripMenuItem dropDownItem3 in dropDownItem2.DropDownItems)
                        {
                            dropDownItem3.ImageScaling = ToolStripItemImageScaling.None;
                            if (dropDownItem3.Image == null)
                            {
                                dropDownItem3.Image = this.menuItemHeaderSize;
                            }
                        }
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs eventArgs_0)
        {
            base.OnHandleCreated(eventArgs_0);
            if (!base.DesignMode)
            {
                base.Renderer = new MenuRenderer(this.isMainMenu, this.primaryColor, this.menuItemTextColor);
                this.LoadMenuItemHeight();
            }
        }
    }
}
