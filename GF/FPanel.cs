using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF
{

	public partial class FPanel : Control
	{
		public new Font Font
		{
			get { return base.Font; }
			set 
			{
				base.Font = value;
				FuncPanel.Font = value;
				FileList.Font = value;
			}

		}

		public FuncPanel FuncPanel { get; } = new FuncPanel();
		public PageNav PageNav { get; } = new PageNav();
		public FileList FileList { get; } = new FileList();
		public FPanel()
		{
			InitializeComponent();
			this.Controls.Add(FuncPanel);
			this.Controls.Add(PageNav);
			this.Controls.Add(FileList);
			ChkControls();
		}
		public void ChkControls()
		{
			FuncPanel.Location = new Point(0,0);
			FuncPanel.Size = new Size(this.Width, FuncPanel.Height);

			FileList.Location = new Point(0, FuncPanel.Height);
			FileList.Size = new Size(this.Width- PageNav.Width, this.Height- FuncPanel.Height);
			
			PageNav.Location = new Point(this.Width - PageNav.Width, FuncPanel.Height);
			PageNav.Size = new Size(PageNav.Width, this.Height - FuncPanel.Height);
		}
		protected override void OnResize(EventArgs e)
		{
			ChkControls();
			//base.OnResize(e);
		}
	}
}
