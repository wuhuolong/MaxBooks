using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Net;

namespace xc.TreasureHunt
{
    [wxb.Hotfix]
    public class TreasureHuntHelper
    {
        public static List<Goods> GetSortedGoodsList()
        {
            List<Goods> result = new List<Goods>();
            foreach (var goods in ItemManager.Instance.TreasureHuntGoodsOids)
            {
                result.Add(goods.Value);
            }
            result.Sort((a, b) =>
            {
                if (a.is_equipUp && b.is_equipUp == false)
                    return -1;
                else if (a.is_equipUp == false && b.is_equipUp)
                    return 1;
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
