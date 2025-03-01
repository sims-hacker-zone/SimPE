// SPDX-FileCopyrightText: © SimPE contributors
// SPDX-License-Identifier: GPL-2.0-or-later
using System;
using System.Collections;

namespace SimPe.Plugin.Anim
{
	/// <summary>
	/// Enumerates possible action for a Joint Animation
	/// </summary>
	public enum AnimImporterAction : byte
	{
		/// <summary>
		/// Ignore the Animation
		/// </summary>
		Nothing = 0x00,

		/// <summary>
		/// Replace the existing Animation <see cref="ImportedFrameBlock.Target"/> with the one stored in the <see cref="ImportedFrameBlock.FrameBlock"/> Member
		/// </summary>
		Replace = 0x01,

		/// <summary>
		/// Add the Animation stored in the <see cref="ImportedFrameBlock.FrameBlock"/> Member
		/// </summary>
		Add = 0x02,
	}

	/// <summary>
	/// This class contains all Data Needed to import one <see cref="AnimationFrameBlock"/>
	/// </summary>
	public class ImportedFrameBlock
	{
		/// <summary>
		/// Returns/Sets the action that should be performed
		/// </summary>
		public AnimImporterAction Action
		{
			get; set;
		}

		/// <summary>
		/// The name of the Imported Bone
		/// </summary>
		public string ImportedName => FrameBlock.Name;

		/// <summary>
		/// The Animation that should get Replaced
		/// </summary>
		public AnimationFrameBlock Target
		{
			get; set;
		}

		/// <summary>
		/// true if the First Frame (TimeCode 0) should be ignored during the Import
		/// </summary>
		public bool DiscardZeroFrame
		{
			get; set;
		}

		/// <summary>
		/// Remove all Keyframes that are not needed by the Animation?
		/// </summary>
		public bool RemoveUnneeded
		{
			get; set;
		}

		/// <summary>
		/// The new Bone
		/// </summary>
		public AnimationFrameBlock FrameBlock
		{
			get;
		}

		/// <summary>
		/// Returns the color that should be used to display this Group in the "Import Groups" ListView
		/// </summary>
		public System.Drawing.Color MarkColor => Action == AnimImporterAction.Nothing
					? System.Drawing.Color.Silver
					: Target == null ? System.Drawing.Color.Red : System.Drawing.Color.DarkBlue;

		/// <summary>
		/// Create a new Instance
		/// </summary>
		/// <param name="afb">The <see cref="AnimationFrameBlock"/> that was Imported</param>
		public ImportedFrameBlock(AnimationFrameBlock afb)
		{
			DiscardZeroFrame = false;
			RemoveUnneeded = true;
			FrameBlock = afb;
			Action = AnimImporterAction.Nothing;
		}

		/// <summary>
		/// Tries to find a <see cref="AnimationFrameBlock"/>  with the same Name in the passed <see cref="AnimationMeshBlock" />.
		/// </summary>
		public void FindTarget(AnimationMeshBlock amb)
		{
			Action = AnimImporterAction.Nothing;
			foreach (AnimationFrameBlock afb in amb.Part2)
			{
				if (afb.Name == ImportedName)
				{
					Action = AnimImporterAction.Replace;
					Target = afb;
					break;
				}
			}
		}

		/// <summary>
		/// Replaces the Frames within <see cref="Target"/>, with the ones stored in <see cref="FrameBlock"/>
		/// </summary>
		public void ReplaceFrames()
		{
			if (Target == null)
			{
				return;
			}

			Target.ClearFrames();
			Target.CreateBaseAxisSet(AnimationTokenType.SixByte);

			for (int i = 0; i < Math.Min(Target.AxisCount, FrameBlock.AxisCount); i++)
			{
				Target.AxisSet[i].Locked = FrameBlock.AxisSet[i].Locked;
			}

			Target.TransformationType = FrameBlock.TransformationType;
			foreach (AnimationFrame af in FrameBlock.Frames)
			{
				if (!DiscardZeroFrame || af.TimeCode != 0)
				{
					Target.AddFrame(af.TimeCode, af.X, af.Y, af.Z, af.Linear);
				}
			}

			if (RemoveUnneeded)
			{
				Target.RemoveUnneededFrames();
			}

			Target.Duration = Target.GetDuration();
		}

		/// <summary>
		/// Add the <see cref="FrameBlock"/> to the passed <see cref="AnimationMeshBlock"/>.
		/// </summary>
		public void AddFrameBlock(AnimationMeshBlock amb)
		{
			if (amb == null)
			{
				return;
			}

			amb.Part2 = (AnimationFrameBlock[])Helper.Add(amb.Part2, FrameBlock);

			if (RemoveUnneeded)
			{
				FrameBlock.RemoveUnneededFrames();
			}

			FrameBlock.Duration = FrameBlock.GetDuration();
		}
	}

	#region Container
	/// <summary>
	/// Typesave ArrayList for <see cref="ImportedGroup"/> Objects
	/// </summary>
	public class ImportedFrameBlocks : ArrayList
	{
		public bool AuskelCorrection
		{
			get; set;
		}

		/// <summary>
		/// Integer Indexer
		/// </summary>
		public new ImportedFrameBlock this[int index]
		{
			get => (ImportedFrameBlock)base[index];
			set => base[index] = value;
		}

		/// <summary>
		/// unsigned Integer Indexer
		/// </summary>
		public ImportedFrameBlock this[uint index]
		{
			get => (ImportedFrameBlock)base[(int)index];
			set => base[(int)index] = value;
		}

		/// <summary>
		/// add a new Element
		/// </summary>
		/// <param name="item">The object you want to add</param>
		/// <returns>The index it was added on</returns>
		public int Add(ImportedFrameBlock item)
		{
			return base.Add(item);
		}

		/// <summary>
		/// insert a new Element
		/// </summary>
		/// <param name="index">The Index where the Element should be stored</param>
		/// <param name="item">The object that should be inserted</param>
		public void Insert(int index, ImportedFrameBlock item)
		{
			base.Insert(index, item);
		}

		/// <summary>
		/// remove an Element
		/// </summary>
		/// <param name="item">The object that should be removed</param>
		public void Remove(ImportedFrameBlock item)
		{
			base.Remove(item);
		}

		/// <summary>
		/// Checks wether or not the object is already stored in the List
		/// </summary>
		/// <param name="item">The Object you are looking for</param>
		/// <returns>true, if it was found</returns>
		public bool Contains(ImportedFrameBlock item)
		{
			return base.Contains(item);
		}

		/// <summary>
		/// Number of stored Elements
		/// </summary>
		public int Length => Count;

		/// <summary>
		/// Create a clone of this Object
		/// </summary>
		/// <returns>The clone</returns>
		public override object Clone()
		{
			ImportedFrameBlocks list = new ImportedFrameBlocks();
			foreach (ImportedFrameBlock item in this)
			{
				list.Add(item);
			}

			return list;
		}
	}
	#endregion
}
