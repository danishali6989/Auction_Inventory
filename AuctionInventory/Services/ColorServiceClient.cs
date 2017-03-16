using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuctionInventory.Models;
using AuctionInventoryDAL.Repositories;
using AuctionInventoryDAL.Entity;

namespace AuctionInventory.Services
{
    public class ColorServiceClient
    {
        public List<Color> GetAllColors()
        {
            List<Color> listcolors = new List<Color>();
            ColorRepository repo = new ColorRepository();
            dynamic color = repo.GetAll();
            listcolors = ParserGetAllColors(color);
            return listcolors;
        }
        public bool SaveData(Color color)
        {
            bool status = true;
            Color colors = new Color();
            ColorRepository repo = new ColorRepository();
            status = repo.SaveEdit(ParserAddColors(color));
            return status;
        }

        public Color GetColor(int id)
        {

            Color color = new Color();
            ColorRepository repo = new ColorRepository();
            if (color != null)
            {
                color = ParserColor(repo.Get(id));
            }
            return color;

        }

        public bool Delete(int id)
        {
            bool status = false;
            ColorRepository repo = new ColorRepository();
            status = repo.Delete(id);
            return status;
        }

        #region Parser

        private MColor ParserAddColors(Color color)
        {
            MColor mColors = new MColor();

            if (color != null)
            {
                mColors.iColorID = color.iColorID;
                mColors.strColorName = color.strColorName ?? " ";
            }
            return mColors;
        }

        private List<Color> ParserGetAllColors(dynamic responseData)
        {
            List<Color> listColor = new List<Color>();

            foreach (var data in responseData)
            {
                if (data != null)
                {
                    Color color = new Color();
                    color.iColorID = data.iColorID ?? -1;
                    color.strColorName = data.strColorName ?? " ";
                    listColor.Add(color);
                }
            }
            return listColor;
        }


        private Color ParserColor(dynamic data)
        {
            Color color = new Color();

            if (data != null)
            {
                color.iColorID = data.iColorID ?? -1;
                color.strColorName = data.strColorName ?? " ";
            }
            return color;
        }

        #endregion
    }
}