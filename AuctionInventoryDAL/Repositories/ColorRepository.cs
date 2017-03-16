using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionInventoryDAL.Entity;

namespace AuctionInventoryDAL.Repositories
{
    public class ColorRepository
    {
        #region CRUD
        private AuctionInventoryEntities auctionContext = new AuctionInventoryEntities();

        public List<MColor> GetAll()
        {
            List<MColor> listcolor = new List<MColor>();
            listcolor = (from r in auctionContext.MColors select r).OrderBy(a => a.strColorName).ToList();
            return listcolor;
        }

        public MColor Get(int id)
        {
            MColor color = new MColor();
            color = auctionContext.MColors.Where(a => a.iColorID == id).FirstOrDefault();
            return color;
        }

        public bool SaveEdit(MColor color)
        {
            bool status = false;
            if (color.iColorID > 0)
            {
                //Edit Existing Record
                var colr = auctionContext.MColors.Where(a => a.iColorID == color.iColorID).FirstOrDefault();
                if (colr != null)
                {
                    colr.strColorName = color.strColorName;
                }
            }
            else
            {
                //Save
                auctionContext.MColors.Add(color);
            }
            auctionContext.SaveChanges();
            status = true;
            return status;
        }


        public bool Delete(int id)
        {
            bool status = false;
            var colr = auctionContext.MColors.Where(a => a.iColorID == id).FirstOrDefault();
            if (colr != null)
            {
                auctionContext.MColors.Remove(colr);
                auctionContext.SaveChanges();
                status = true;
            }
            return status;
        }
        #endregion
    }
}
