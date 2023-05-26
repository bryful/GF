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
	public partial class Functions : Control
	{
		// ******************************************************
		public new Font Font
		{
			get { return base.Font; }
			set
			{
				base.Font = value;
				if (this.Controls.Count > 0)
				{
					foreach (Control c in this.Controls)
					{
						c.Font = value;
					}
				}
			}

		}
		// ******************************************************
		public int BtnCount { get {  return this.Controls.Count; } }
		// ******************************************************
		private int m_BtnWidth = 50;
		private int m_BtnHeight = 50;
		private bool m_IsHor = true;
		public bool IsHor
		{
			get { return m_IsHor; }
			set
			{
				if(m_IsHor != value)
				{
					m_IsHor = value;
					ChkControl();
				}
			}
		}
		// ******************************************************
		public string[] Captions
		{
			get
			{
				string [] ret = new string[this.Controls.Count];
				for(int i=0; i<this.Controls.Count;i++)
				{
					ret[i] = this.Controls[i].Text;
				}
				return ret;
			}
			set
			{
				List<string> list = new List<string>();
				foreach(string s in value)
				{
					string ss = s.Trim();
					if(ss!="") list.Add(ss);
				}

				InitControl(list.Count);
				if(this.Controls.Count > 0)
				{
					for (int i = 0; i < this.Controls.Count; i++)
					{
						this.Controls[i].Text = list[i];
					}
				}
			}

		}
		// ******************************************************
		public void Add(string cap,int idx =-1)
		{
			Button btn = new Button();
			btn.Text = cap;
			this.Controls.Add(btn);
			if (idx >= 0)
			{
				this.Controls.SetChildIndex(btn, idx);
			}
			ChkControl();
		}
		// ******************************************************
		public Functions()
		{
			InitializeComponent();
			ChkControl();
		}
		// ******************************************************
		private void InitControl(int sz)
		{
			if (this.Controls.Count == sz) 
			{
				return;
			}
			else if (this.Controls.Count > sz) 
			{
				for(int i= this.Controls.Count-1; i>= sz;i--)
				{
					this.Controls.RemoveAt(i);
				}
			}
			else
			{
				int idx = this.Controls.Count;
				for (int i = idx; i <sz; i++)
				{
					Button btn = new Button();
					btn.Size = new Size(m_BtnWidth, m_BtnHeight);
					btn.Text = $"{i}";
					this.Controls.Add(btn);
				}
			}
			ChkControl();
		}
		// ******************************************************
		private void ChkControl()
		{
			if (this.Controls.Count == 0) return;
			for(int i=0; i<this.Controls.Count; i++) 
			{
				if (m_IsHor)
				{
					this.Controls[i].Location = new Point(i*m_BtnWidth, 0);
				}
				else
				{
					this.Controls[i].Location = new Point(0,i * m_BtnHeight);
				}
				this.Controls[i].Tag = i;
			}
		}
		// ******************************************************

	}
}
