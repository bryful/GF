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
	public enum BtnKind
	{
		Copy,
		Move,
		Delete,
		Jump,
		History,
		Drive,
		Root,
		BackSpace,
		Select,
		SelectAll,
		Enter,
	}
	public partial class FuncPanel : Control
	{
		public readonly string[] FuncNames = new string[]
		{
			"c",
			"m",
			"d",
			"j",
			"h",
			"d",
			"r",
			"b",
			"S",
			"a",
			"x",
		};
		// ******************************************************
		public new Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				if(m_Btns.Length>0)
				{
					for (int i = 0; i < m_Btns.Length; i++)
					{
						if(m_Btns[i] !=null)
							m_Btns[i].Font = value;
					}
				}
			}

		}
		// ******************************************************
		public readonly int BtnHeight = 50;
		// ******************************************************
		private Button[] m_Btns = new Button[11];
		// ******************************************************
		public Button BtnRoot { get; } = new Button();
		public Button BtnJump { get; } = new Button();
		public Button BtnHistory { get; } = new Button();
		public Button BtnCopy { get; } = new Button();
		public Button BtnMove { get; } = new Button();
		public Button BtnDrive { get; } = new Button();
		public Button BtnDelete { get; } = new Button();
		public Button BtnBackSpace { get; } = new Button();
		public Button BtnEnter { get; } = new Button();
		public Button BtnSel { get; } = new Button();
		public Button BtnSal { get; } = new Button();
		// ******************************************************
		public FuncPanel()
		{
			int v = 0;
			m_Btns[v] = BtnCopy; v++;
			m_Btns[v] = BtnMove; v++;
			m_Btns[v] = BtnDelete; v++;
			m_Btns[v] = BtnJump; v++;
			m_Btns[v] = BtnHistory; v++;
			m_Btns[v] = BtnDrive; v++;
			m_Btns[v] = BtnRoot; v++;
			m_Btns[v] = BtnBackSpace; v++;
			m_Btns[v] = BtnEnter; v++;
			m_Btns[v] = BtnSel ; v++;
			m_Btns[v] = BtnSal; v++;
			v = 0;
			string[] cp = Enum.GetNames(typeof(BtnKind));
			int w = this.Width / m_Btns.Length;
			foreach (Button item in m_Btns)
			{
				item.AutoSize = false;
				item.Location = new Point(v * w, 0);
				item.Size = new Size(w, BtnHeight);
				item.Text = FuncNames[v];
				//item.FlatStyle = FlatStyle.Flat;
				v++;
			}
			foreach (Button item in m_Btns)
			{
				this.Controls.Add(item);
			}

			this.Location = new Point(0,0);
			this.Size = new Size(200, BtnHeight);
			this.MinimumSize = new Size(50, BtnHeight);
			this.MaximumSize = new Size(2560, BtnHeight);

			InitializeComponent();

		}
		public void ChkControls()
		{
			int w = this.Width / m_Btns.Length;
			int x = 0;
			foreach (Button item in m_Btns)
			{
				if (item != null)
				{
					item.Location = new Point(x * w, 0);
					item.Size = new Size(w, BtnHeight);
				}
				x++;
			}
		}
		protected override void OnResize(EventArgs e)
		{
			ChkControls();
			//base.OnResize(e);
		}
	}
}
