using System.Collections.Generic;

namespace xc.Handbook
{
    [wxb.Hotfix]
    public class HandbookHelper
    {
        public static List<Goods> GetSortedGoodsList()
        {
            List<Goods> result = new List<Goods>();
            foreach (var goods in ItemManager.Instance.HandbookGoodsOids)
            {
                result.Add(goods.Value);
            }
            result.Sort((a, b) =>
            {
                if (a.sort_id < b.sort_id)
                    return -1;
                else if (a.sort_id > b.sort_id)
                    return 1;
                if (a.id < b.id)
                    return -1;
                else if (a.id > b.id)
                    return 1;
                return 0;
            });
            return result;
        }
    }
}
