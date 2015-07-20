using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Formicant;
using Teclado.Common;
using Teclado.Parsing;
using Teclado.WinApi;

namespace Teclado
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//Start();
			Test();
		}

		void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Stop();
		}

		void Print(string text)
		{
			textBox.Text += text + Environment.NewLine;
			textBox.SelectionLength = 0;
			textBox.SelectionStart = textBox.Text.Length;
		}

		void Print(string format, params object[] args)
		{
			textBox.Text += format.Fmt(args) + Environment.NewLine;
			textBox.SelectionLength = 0;
			textBox.SelectionStart = textBox.Text.Length;
		}

		void Start()
		{
			Hooks.LowLevelKeyboardHookEvent += Hooks_LowLevelKeyboardHookEvent;
			Hooks.LowLevelKeyboardStart();
		}

		void Stop()
		{
			Hooks.LowLevelKeyboardStop();
		}

		bool Hooks_LowLevelKeyboardHookEvent(bool down, Common.Scancode scancode, Common.VirtKey virtKey)
		{
			if(!_isInside)
			{
				_isInside = true;
				if(down)
					Print($"{scancode.Code:X2}\t{virtKey.Code:X2}");
				_isInside = false;
			}
			return true;
		}

		bool _isInside = false;

		void Test()
		{
		}
	}
}
