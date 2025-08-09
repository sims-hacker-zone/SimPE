using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SimPe.Sims2.Models.Resource.Bhav;

public partial class BhavInstruction(Bhav parent) : ObservableObject
{
	[ObservableProperty] private Bhav parent = parent;

	[ObservableProperty] private ushort opcode;

	[ObservableProperty] private ushort goToTrue;

	[ObservableProperty] private ushort goToFalse;

	[ObservableProperty] private byte nodeVersion;

	[ObservableProperty] private byte[] operands = new byte[16];

	public static BhavInstruction Unserialize(BinaryReader reader, Bhav parent)
	{
		BhavInstruction instruction = new(parent)
		{
			Opcode = reader.ReadUInt16(),
			GoToTrue = parent.Version >= 0x8007 ? reader.ReadUInt16() : reader.ReadByte(),
			GoToFalse = parent.Version >= 0x8007 ? reader.ReadUInt16() : reader.ReadByte()
		};
		if (parent.Version >= 0x8005)
		{
			instruction.NodeVersion = reader.ReadByte();
		}

		instruction.Operands = parent.Version >= 0x8003
			? reader.ReadBytes(16)
			: [.. reader.ReadBytes(8), 0, 0, 0, 0, 0, 0, 0, 0];
		return instruction;
	}

	public void Serialize(BinaryWriter writer)
	{
		writer.Write(Opcode);
		if (Parent.Version >= 0x8007)
		{
			writer.Write(GoToTrue);
			writer.Write(GoToFalse);
		}
		else
		{
			writer.Write((byte)GoToTrue);
			writer.Write((byte)GoToFalse);
		}

		if (Parent.Version >= 0x8005)
		{
			writer.Write(NodeVersion);
		}

		writer.Write(Parent.Version >= 0x8003 ? Operands : Operands[..8]);
	}

	public override string ToString()
	{
		return
			$"{Parent.Instructions.IndexOf(this)}: 0x{Opcode:X4}({string.Join(", ", Parent.Version >= 0x8003 ? Operands : Operands[..8])}); True: {GoToTrue}; False: {GoToFalse}";
	}
}
