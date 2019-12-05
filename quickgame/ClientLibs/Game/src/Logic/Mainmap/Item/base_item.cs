namespace twp
{
	namespace app
	{
		namespace item
		{
			// 掉落物品
			public class DropItem
			{
				public uint		item_type_idx;
				public ushort	item_amount;
				
				public void FromBin(Net.ByteArray bin)
				{
					bin.Get_(out item_type_idx);
					bin.Get_(out item_amount);
				}
			}
		}
	}
}

