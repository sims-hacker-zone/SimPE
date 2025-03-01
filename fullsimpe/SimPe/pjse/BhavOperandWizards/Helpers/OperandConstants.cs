/*
 * SimpePrimitiveWizards - additional primitive wizards for SimPe
 *                       - see https://www.picknmixmods.com/Sims2/Notes/SimpePrimitiveWizards/SimpePrimitiveWizards.html
 *
 * William Howard - 2023-2023
 *
 * Permission granted to use this code in any way, except to claim it as your own or sell it
 *
 * NOTE: Code should not be "using Simpe;" or "using pjse;" but fully qualifying classes in those high level namespaces
 *
 */

namespace whse.PrimitiveWizards
{
    public static class OperandConstants
    {
        public const int Operand0 = 0;
        public const int Operand1 = 1;
        public const int Operand2 = 2;
        public const int Operand3 = 3;
        public const int Operand4 = 4;
        public const int Operand5 = 5;
        public const int Operand6 = 6;
        public const int Operand7 = 7;
        public const int Operand8 = 0;
        public const int Operand9 = 1;
        public const int Operand10 = 2;
        public const int Operand11 = 3;
        public const int Operand12 = 4;
        public const int Operand13 = 5;
        public const int Operand14 = 6;
        public const int Operand15 = 7;

        public const int Bit1 = 0;
        public const int Bit2 = 1;
        public const int Bit3 = 2;
        public const int Bit4 = 3;
        public const int Bit5 = 4;
        public const int Bit6 = 5;
        public const int Bit7 = 6;
        public const int Bit8 = 7;
    }

    // See https://modthesims.info/wiki.php?title=Sims_2_Variables
    public static class DataOwner
    {
        public const byte Literal = 0x07;
        public const byte Temp = 0x08;
        public const byte Parameter = 0x09;
        public const byte Local = 0x19;
    }
}
