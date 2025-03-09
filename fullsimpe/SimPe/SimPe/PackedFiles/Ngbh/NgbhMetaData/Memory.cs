using System.Collections;

namespace SimPe.PackedFiles.Ngbh.NgbhMetaData
{
	internal sealed class Memory
	{
		Memory()
		{
		}

		/// <summary>
		/// A memory's subject can be of three different types
		/// </summary>
		const ushort Sim = 0,
			Food = 1,
			Career = 2;

		static Hashtable memorySubjectType = BuildMemorySubjectTypeCache();
		static ArrayList spamGuid = BuildSpamMemoryList();

		static Hashtable BuildMemorySubjectTypeCache()
		{
			Hashtable ret = new Hashtable
			{
				// reached top of $career
				[0x2323232] = Career,
				// learned how to make $food
				[0x3248932] = Food,
				// burned $food
				[0x2378482] = Food
			};

			return ret;
		}

		static ArrayList BuildSpamMemoryList()
		{
			ArrayList ret = new ArrayList
				{
					// Had family reunion
					0x2DD3B15Fu,

					// got A+
					0x4CAB11D3u,

					// subject got A+
					0x8DB6545Du,

					// got D
					0xEDB65A89u,

					// subject got D
					0X6DB654ACu,

					// subject got abducted
					0xEDD35A61u,

					// vermin!
					0x6CAB0E82u
				};

			return ret;
		}

		/// <summary>
		/// Returns an identifier for the type of Subject the memory refers to.
		/// </summary>
		public static ushort GetSubjectType(NgbhItem item)
		{
			return GetSubjectType(item.Guid);
		}

		public static ushort GetSubjectType(uint itemGuid)
		{
			return memorySubjectType.ContainsKey(itemGuid) ? (ushort)memorySubjectType[itemGuid] : (ushort)0;
		}

		public static bool IsSpamMemory(NgbhItem item)
		{
			return IsSpamMemory(item.Guid);
		}

		public static bool IsSpamMemory(uint guid)
		{
			return spamGuid.Contains(guid);
		}
	}

	internal enum FoodType : uint
	{
		Unknown = 0x0000,
		InstantMeal,

		//breakfast
		Cereal,
		Pancake,
		Omelette,

		// lunch
		TVDinner,
		LunchSandwich,
		GrilledCheese,
		Hamburger,
		Hotdog,
		MacAndCheese,
		Chilli,

		//dinner
		Spaghetti,
		Lobster,
		PorkChop,
		Salmon,
		Turkey,

		// dessert
		Gelatin,
	}
}
