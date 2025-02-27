namespace SimPe.PackedFiles.Wrapper.SCOR
{
	class ScorItemTokenDefault : IScorItemToken
	{
		public byte[] UnserializeToken(ScorItem si, System.IO.BinaryReader reader)
		{
			return ScorItem.UnserializeDefaultToken(reader);
		}

		public AScorItem ActivatedGUI => null;
	}
}
