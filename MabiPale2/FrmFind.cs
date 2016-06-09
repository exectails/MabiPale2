using MabiPale2.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MabiPale2
{
	/// <summary>
	/// Container struct for defining how a search operation will be performed.
	/// </summary>
	public struct SearchParametres
	{
		/// <summary>
		/// Specifies identifiers to indicate the type of search query being performed. Mutually exclusive.
		/// </summary>
		public enum SearchModes
		{
			/// <summary>
			/// Do nothing.
			/// </summary>
			NoOp = 0,
			String, 
			Hexadecimal,
		}

		/// <summary>
		/// Bitwise set.
		/// </summary>
		[Flags]
		public enum LookAtCandidates
		{
			Ops = (1 << 0), 
			Ids = (1 << 1), 
			Data_String = (1 << 2),
		}

		/// <summary>
		/// Specifies whether to search through sent and/or received packets. Bitwise set.
		/// </summary>
		[Flags]
		public enum SendOrRecv
		{
			Send = (1 << 0), 
			Recv = (1 << 1),
		}

		public string StringQuery { get; set; }
		public SearchModes SearchMode { get; set; }
		public SearchDirectionHint SearchDirection { get; set; }
		public LookAtCandidates LookAt { get; set; }
		public SendOrRecv PacketBounds { get; set; }

		/*
		public SearchParametres()
		{
			this.StringQuery = "";
			this.SearchMode = SearchModes.NoOp;
			this.SearchDirection = SearchDirectionHint.Down;
			this.LookAt = 0;
			this.PacketBounds = 0;
		}
		*/

		public SearchParametres(SearchParametres spCopy) : this()
		{
			this.StringQuery = spCopy.StringQuery;
			this.SearchMode = spCopy.SearchMode;
			this.SearchDirection = spCopy.SearchDirection;
			this.LookAt = spCopy.LookAt;
			this.PacketBounds = spCopy.PacketBounds;
		}

		/// <param name="packet">Packet to test.</param>
		/// <param name="opNames">Definitions pairing opcodes with their human-readable name.</param>
		/// <returns>Whether <paramref name="packet"/> matches against this SearchParametres object.</returns>
		/// <exception cref="InvalidOperationException">Thrown if this SearchParametres object has its search mode set to 'NoOp'.</exception>
		public bool IsMatch(PalePacket packet, Dictionary<int, string> opNames)
		{ 
			// Handle obvious mismatches
			if (this.SearchMode == SearchModes.NoOp)
			{
				throw new InvalidOperationException("This object has its search mode set to 'NoOp'. Cannot evaluate packet.");
				return false;
			}

			if (!this.PacketBounds.HasFlag(packet.Received ? SendOrRecv.Recv : SendOrRecv.Send))
				return false;



			// Begin probing packet
			if (this.SearchMode == SearchModes.Hexadecimal)
				return HexTool.ToString(packet.Packet.GetBuffer()).Contains(this.StringQuery);
			else //if (this.SearchMode == SearchModes.String)
			{
				if (this.LookAt.HasFlag(LookAtCandidates.Ops))
					if (opNames.ContainsKey(packet.Op) && opNames[packet.Op].Contains(this.StringQuery))
						return true;

				if (this.LookAt.HasFlag(LookAtCandidates.Ids))
					if (packet.Id.ToString("X16").Contains(this.StringQuery.ToUpper()))
						return true;

				if (this.LookAt.HasFlag(LookAtCandidates.Data_String))
					if (packet.ToString().Contains(this.StringQuery))
						return true;

				return false;
			}
		}
	}

	/// <summary>
	/// Find dialogue box. If DialogResult is set to OK, new search parametres are stored in this form's Tag property.
	/// </summary>
    public partial class FrmFind : Form
    {
		[Flags]
		private enum ValidatingControls 
		{
			GrpLookAt = (1 << 0), 
			TxtSearchQuery = (1 << 1),
		}
		private ValidatingControls invalidControls;
		
        public FrmFind(SearchParametres searchParams)
        {
            InitializeComponent();

			// Load provided searchParams
			TxtSearchQuery.Text = searchParams.StringQuery;
			if (searchParams.SearchMode == SearchParametres.SearchModes.Hexadecimal)
			{
				RadSearchModeHex.Checked = true;
				// (and all LookAtCandidates will be autochecked via CheckedChanged event)
			}
			else
			{
				LblHexNotice.Visible = false;
				ChkSearchInOps.Checked = searchParams.LookAt.HasFlag(SearchParametres.LookAtCandidates.Ops);
				ChkSearchInIds.Checked = searchParams.LookAt.HasFlag(SearchParametres.LookAtCandidates.Ids);
				ChkSearchInData.Checked = searchParams.LookAt.HasFlag(SearchParametres.LookAtCandidates.Data_String);
			}

			ChkSearchInSends.Checked = searchParams.PacketBounds.HasFlag(SearchParametres.SendOrRecv.Send);
			ChkSearchInRecvs.Checked = searchParams.PacketBounds.HasFlag(SearchParametres.SendOrRecv.Recv);
        }

        private void RadSearchModeStr_CheckedChanged(object sender, EventArgs e)
        {
			bool isStringSearchMode = RadSearchModeStr.Checked;

			LblHexNotice.Visible = !isStringSearchMode;
			ChkSearchInOps.Enabled = isStringSearchMode;
			ChkSearchInIds.Enabled = isStringSearchMode;
			ChkSearchInData.Enabled = isStringSearchMode;

			// If switching to Hexadecimal search mode, 
			// visually indicate that the program will search through the entire packet, per packet.
			if (!isStringSearchMode)
			{
				ChkSearchInOps.Checked = true;
				ChkSearchInIds.Checked = true;
				ChkSearchInData.Checked = true;
			}
        }
		
		private void GrpLookAt_Validating(object sender, CancelEventArgs e)
		{
			// Valid if at least one checkbox from each category is checked.
			if ((ChkSearchInSends.Checked || ChkSearchInRecvs.Checked) // Category 1
				&& (ChkSearchInOps.Checked || ChkSearchInIds.Checked || ChkSearchInData.Checked)) // Category 2
				invalidControls &= ~ValidatingControls.GrpLookAt; // Clear bit
			else
				invalidControls |= ValidatingControls.GrpLookAt; // Set bit
		}

		private void FrmFindCommon_Validated(object sender, EventArgs e)
		{
			bool isValid = (invalidControls == 0);
			BtnFindNext.Enabled = isValid;
			BtnFindPrev.Enabled = isValid;
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void FrmFindCommon_TriggerValidation(object sender, EventArgs e)
		{
			this.ValidateChildren();
		}

		private void TxtSearchQuery_Validating(object sender, CancelEventArgs e)
		{
			// Valid if at least one character is entered.
			if (TxtSearchQuery.TextLength > 0)
				invalidControls &= ~ValidatingControls.TxtSearchQuery; // Clear bit
			else
				invalidControls |= ValidatingControls.TxtSearchQuery; // Set bit
		}

		private void BtnFind_Click(object sender, EventArgs e)
		{
			// Verify that the search query is hex if searching by hex.
			if (RadSearchModeHex.Checked)
			{
				// (MabiPale saves packets in uppercase.)
				TxtSearchQuery.Text = TxtSearchQuery.Text.ToUpper();

				Regex hexPattern = new Regex("^[0-9A-F]+$");
				if (!hexPattern.IsMatch(TxtSearchQuery.Text))
				{
					MessageBox.Show("Invalid hexadecimal string.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}



			DialogResult = DialogResult.OK;
			// Encode search parametres
			// Generate LookAtCandidates, set appropriate bits
			SearchParametres.LookAtCandidates lookAt = 0;
			if (ChkSearchInOps.Checked)
				lookAt |= SearchParametres.LookAtCandidates.Ops; // Set bit
			if (ChkSearchInIds.Checked)
				lookAt |= SearchParametres.LookAtCandidates.Ids; // Set bit
			if (ChkSearchInData.Checked)
				lookAt |= SearchParametres.LookAtCandidates.Data_String; // Set bit

			// Generate PacketBounds, set appropriate bits
			SearchParametres.SendOrRecv packetBounds = 0;
			if (ChkSearchInSends.Checked)
				packetBounds |= SearchParametres.SendOrRecv.Send; // Set bit
			if (ChkSearchInRecvs.Checked)
				packetBounds |= SearchParametres.SendOrRecv.Recv; // Set bit

			SearchParametres searchParams = new SearchParametres()
			{
				StringQuery = TxtSearchQuery.Text,
				SearchMode = RadSearchModeStr.Checked
					? SearchParametres.SearchModes.String
					: SearchParametres.SearchModes.Hexadecimal,
				SearchDirection = ((Button)sender).Name == BtnFindPrev.Name
					? SearchDirectionHint.Up
					: SearchDirectionHint.Down,
				LookAt = lookAt,
				PacketBounds = packetBounds,
			};

			this.Tag = searchParams;
			this.Close();
		}
    }
}
