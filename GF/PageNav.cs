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
	public enum PageNavExe
	{
		Parent,
		PageTop,
		PageUp,
		PageDown,
		PageBottom,
		Enter
	}
	public partial class PageNav : Control
	{
		public readonly string[] captions = new string[]
		{
			"B",
			"Tp",
			"Up",
			"Dw",
			"Bt",
			"X"
		};
		// ******************************************************
		public new Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				for (int i = 0; i < m_Btns.Length; i++) m_Btns[i].Font = value;
			}

		}
		// ******************************************************
		private Button[] m_Btns = new Button[6];
		// ******************************************************
		public readonly int BtnWidth = 50;
		public Button BtnParent { get; } = new Button();
		public Button BtnPageTop { get; } = new Button();
		public Button BtnPageUp { get; } = new Button();
		public Button BtnPageDown { get; } = new Button();
		public Button BtnPageBottom { get; } = new Button();
		public Button BtnEnter { get; } = new Button();

		public PageNav()
		{
			int v = 0;
			m_Btns[v] = BtnParent;v++;
			m_Btns[v] = BtnPageTop; v++;
			m_Btns[v] = BtnPageUp; v++;
			m_Btns[v] = BtnPageDown; v++;
			m_Btns[v] = BtnPageBottom; v++;
			m_Btns[v] = BtnEnter; v++;
			v = 0;
			for(int i=0; i<m_Btns.Length;i++)
			{
				switch((PageNavExe)i)
				{
					case PageNavExe.PageUp:
					case PageNavExe.PageDown:
						m_Btns[i].Size = new Size(BtnWidth, BtnWidth*2);
						break;
					default:
						m_Btns[i].Size = new Size(BtnWidth, BtnWidth);
						break;
				}
				m_Btns[i].Text = captions[i];
				m_Btns[i].Location = new Point(0, v);
				v += m_Btns[i].Height;
				this.Controls.Add(m_Btns[i]);
			}
			this.Size=new Size(BtnWidth, 200);
			this.MinimumSize = new Size(BtnWidth, 50);
			this.MaximumSize = new Size(BtnWidth, 2560);

			InitializeComponent();
			ChkControls();
		}
		private void ChkControls()
		{
			BtnEnter.Size = new Size(BtnWidth,this.Height- BtnEnter.Top);
		}
		protected override void OnResize(EventArgs e)
		{
			//base.OnResize(e);
			ChkControls();
		}
	}
}
