namespace SimPe.PackedFiles.Wrapper.SCOR
{
	interface IScorItemToken
	{
		byte[] UnserializeToken(ScorItem si, System.IO.BinaryReader reader);

		SCOR.AScorItem ActivatedGUI
		{
			get;
		}
	}
}
