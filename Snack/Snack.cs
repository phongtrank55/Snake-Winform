using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Snack
{
    class Snack
    {
        private Rectangle[] snackrec;
        public Rectangle[] Snackrec
        {
            get
            {
                return snackrec;
            }
        }
        private SolidBrush slb;
        private int x,y, width, height;
        public Snack(int x = 20, int y = 0, int width = 10, int height = 10)
        {
            slb=new SolidBrush(Color.Red);
            this.x = x; this.y = y; this.width = width; this.height = height;
            snackrec = new Rectangle[3];
            for(int i=0; i<snackrec.Length; i++)
            {
                snackrec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }
        public void DrawSnack(Graphics paper)
        {
            for (int i = 1; i < snackrec.Length; i++)
                paper.FillEllipse(slb, snackrec[i]);
            paper.FillEllipse(new SolidBrush(Color.Green), snackrec[0]);
        }
        public void Drawrun()
        {
            for(int i = snackrec.Length - 1; i > 0; i--)
                snackrec[i] = snackrec[i - 1];
        }
        public void moveDown()
        {
            Drawrun();
            snackrec[0].Y += 10;
        }
        public void moveUp()
        {
            Drawrun();
            snackrec[0].Y -= 10;
        }
        public void moveLeft()
        {
            Drawrun();
            snackrec[0].X -= 10;
        }
        public void moveRight()
        {
            Drawrun();
            snackrec[0].X += 10;
        }
        public void growsnack()
        {
            int n = snackrec.Length-1; 
            //snackrec[n] = new Rectangle(snackrec[n-1].X, snackrec[n-1].Y, width, height);
            List<Rectangle> rec = snackrec.ToList();
            rec.Add(new Rectangle(snackrec[n].X, snackrec[n].Y, width, height));
            snackrec=rec.ToArray();
        }
    }
}   
