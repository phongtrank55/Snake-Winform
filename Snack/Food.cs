using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snack
{
    class Food
    {
        private int x, y, width, height;
        private SolidBrush slb;
        private Rectangle foodrec;
        public Rectangle Foodrec
        {
            get
            {
                return foodrec;
            }
        }
        public Food(Random randfood, int w=10, int h=10)
        {
            foodLocation(randfood);
            slb = new SolidBrush(Color.Black);
            width = w; height = h;
            foodrec = new Rectangle(x,y,width,height);
        }
        public void foodLocation(Random randfood)
        {
            x = randfood.Next(0, 30) * 10;
            y = randfood.Next(0, 30) * 10;
        }
        public void Drawfood(Graphics paper)
        {
            foodrec.X = x;
            foodrec.Y = y;
            paper.FillEllipse(slb, foodrec);
        }
        public void zoomout(int dw)
        {
            foodrec = new Rectangle(x, y, width-= dw, height -=dw);
        }
        public int sumscore(int ds)
        {
            int sc, w, ns;
            switch(ds)
            {
                case 1: sc=150; ns=7; break;
                case 2: sc=300; ns=12; break;
                case 3: sc=500; ns=18; break;
                case 4: sc=650; ns=22; break;
                default: sc=800; ns=26; break;
            }
             
            if(foodrec.Width==10)
                return ns;
            if(foodrec.Width >= 28)
                return sc;
            w = 28;
            while (foodrec.Width != w)
            {
                w -= 2;
                sc -= 20;
            }
            return sc;           
        }
    }
}
