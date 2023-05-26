using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WF
{
	public partial class FileList : Control
	{
		private int m_LineHeight = 30;
		public int LineHeight
		{
			get { return m_LineHeight; }
			set
			{
				m_LineHeight = value;
				if (m_LineHeight < 8) m_LineHeight = 8;
				ChkControl();
				this.Invalidate();
			}
		}

		private int m_DispYMax = 0; private DirectoryInfo m_dir = new DirectoryInfo(Directory.GetCurrentDirectory());	
		private List<DFInfo?> m_DFInfos = new List<DFInfo?>();
		private VScrollBar VScroll = new VScrollBar();
		private int m_DispStartLine = 0;
		private int m_SelectedIndex = -1;
		public int SelectedIndex
		{
			get { return m_SelectedIndex; }
			set
			{
				m_SelectedIndex = value;
				this.Invalidate();
			}
		}
		private Color m_SelectedColor = Color.LightGray;
		public Color SelectedColor
		{
			get { return m_SelectedColor; }
			set
			{
				m_SelectedColor = value;
				this.Invalidate();
			}
		}
		private Color m_SelectedIndexColor = Color.Gray;
		public Color SelectedIndexColor
		{
			get { return m_SelectedIndexColor; }
			set
			{
				m_SelectedIndexColor = value;
				this.Invalidate();
			}
		}

		// *****************************************************************
		public string Dir
		{
			get { return m_dir.FullName; }
			set
			{
				DirectoryInfo dir = new DirectoryInfo(value);
				if(dir.Exists)
				{
					m_dir = dir;
					Listup();
				}
			}
		}
		// *****************************************************************
		public FileList()
		{
			InitializeComponent();
			this.Controls.Add(VScroll);
			ChkControl();
			Listup();
		}
		// *****************************************************************
		private void ChkControl()
		{
			VScroll.Location = new Point(this.Width - VScroll.Width, 0);
			VScroll.Size = new Size(VScroll.Width, this.Height);

			int maxHeight = m_DFInfos.Count * m_LineHeight - this.Height;
			if (maxHeight < 0) maxHeight = 0;
			
			if(VScroll.Maximum != maxHeight)
			{
				VScroll.Maximum = maxHeight;
			}
			m_DispStartLine = VScroll.Value / m_LineHeight;
		}
		// *****************************************************************
		private void Listup()
		{
			m_DFInfos.Clear();
			if (m_dir.Exists == false) return;
			var dirs =
				m_dir.EnumerateDirectories("*", SearchOption.TopDirectoryOnly).ToList();
			var files =
				m_dir.EnumerateFiles("*", SearchOption.TopDirectoryOnly).ToList();

			if(dirs.Count>0)
			{
				foreach( var dir in dirs)
				{
					m_DFInfos.Add( new DFInfo(dir));
				}
			}
			if (files.Count > 0)
			{
				foreach (var f in files)
				{
					m_DFInfos.Add(new DFInfo(f));
				}
			}
			this.Invalidate();

		}
		// *****************************************************************
		private bool DrawLine(Graphics g,SolidBrush sb, Pen p,StringFormat sf, int idx)
		{
			bool ret = false;
			int y = idx * m_LineHeight - VScroll.Value;
			if ((y >= this.Height)||(idx>=m_DFInfos.Count)|| (m_DFInfos[idx] == null)) return ret;
			Rectangle r = new Rectangle(0, y, this.Width - VScroll.Width, m_LineHeight);
			
			if(m_SelectedIndex == idx)
			{
				sb.Color = m_SelectedIndexColor;
				g.FillRectangle(sb, r);
			}else if(m_DFInfos[idx].Selected == true)
			{
				sb.Color = m_SelectedColor;
				g.FillRectangle(sb, r);
			}
			r = new Rectangle(r.Left + 5, r.Top, r.Width - 7, r.Height);
			sb.Color = ForeColor;
			g.DrawString(m_DFInfos[idx].Caption, this.Font,sb, r, sf);
			ret = true;
			return ret;
		}
		// *****************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{
			//base.OnPaint(e);
			using (SolidBrush sb = new SolidBrush(BackColor))
			using (Pen p = new Pen(ForeColor))
			using (StringFormat sf = new StringFormat())
			{
				Graphics g = e.Graphics;
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				g.Clear(BackColor);

				if(m_DFInfos.Count > 0)
				{
					int idx = m_DispStartLine;
					for (int i = m_DispStartLine;i< m_DFInfos.Count;i++)
					{
						DrawLine(g,sb,p,sf,i);
					}
				}


			}
		}
		protected override void OnResize(EventArgs e)
		{
			//base.OnResize(e);
			ChkControl();
		}

		private bool m_MD = false;
		private int m_MDY = 0;
		// *************************************************************
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (m_MD==false) 
			{
				m_MD = true;
				m_MDY = e.Y;
			}
			int idx = (e.Y + VScroll.Value) / m_LineHeight;
			if(idx>=m_DFInfos.Count)
			{
				idx = -1;
			}
			if(m_SelectedIndex != idx)
			{
				m_SelectedIndex = idx;
			}
			this.Invalidate();
			//base.OnMouseDown(e);
		}
		// *************************************************************
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
		}
		// *************************************************************
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
		}
		// *************************************************************
	}

	public class DFInfo
	{
		private string m_Dir = "";
		public string Dir { get { return m_Dir; } }
		public string Name { get { return Path.GetFileName(m_Dir); } }
		private bool m_IsDirectory = false;
		public bool Selected { get; set; }=false;
		public bool IsDirectory
		{
			get { return m_IsDirectory; }
		}
		public string Caption
		{
			get
			{
				string ret = "";
				if(m_IsDirectory)
				{
					ret = $"< {Name} >";
				}
				else
				{
					ret = $"{Name}";
				}
				return ret;
			}
		}
		public bool Exists
		{
			get 
			{
				bool ret = false;
				if(m_Dir=="") return ret;
				if(m_IsDirectory)
				{
					ret = Directory.Exists(m_Dir);
				}
				else
				{
					ret = File.Exists(m_Dir);
				}
				return ret; 
			}
		}
		public DFInfo(string p)
		{
			if(Directory.Exists(p))
			{
				m_Dir = p;
				m_IsDirectory = true;
			}else if (Directory.Exists(p))
			{
				m_Dir = p;
				m_IsDirectory = false;
			}
		}
		public DFInfo(DirectoryInfo? di)
		{
			m_Dir = "";
			if ((di!=null)&&(di.Exists))
			{
				m_Dir = di.FullName;
				m_IsDirectory = true;
			}
		}
		public DFInfo(FileInfo? fi)
		{
			m_Dir = "";
			if ((fi != null) && (fi.Exists))
			{
				m_Dir = fi.FullName;
				m_IsDirectory = false;
			}
		}
	}
}
