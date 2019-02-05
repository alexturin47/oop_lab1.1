using System.Drawing;

namespace oop_lab1
{
    class tPoint
    {
        private int _x;
        private int _y;
        private Color _color;
        private const int _sizePoint = 2;

        // конструкторы
        public tPoint() :  this(0,0, Color.Black) {} // по умолчанию
        public tPoint(int x, int y, Color color) // со всеми параметрами
        {
            _x = x;
            _y = y;
            _color = color;    
        }       
        
        public void SetX(int newX)
        {
            _x = newX;
        }

        public int GetX()
        {
            return _x;
        }

        public void SetY( int newY)
        {
            _y = newY;
        }

        public int GetY()
        {
            return _y;
        }

        public void setColor( Color color)
        {
            _color = color;
        }
        public Color getColor()
        {
            return _color;
        }

        //медот отрисовки точки
        public void Draw(Graphics gfx)
        {
            Brush brush = new SolidBrush(getColor());
            gfx.FillRectangle(brush, _x, _y, _sizePoint, _sizePoint);
        }

        public void Hide(Graphics gfx)
        {
            Brush brush = new SolidBrush(Color.White);
            gfx.FillRectangle(brush, _x, _y, _sizePoint, _sizePoint);
        }

        public void Move(int stepX, int stepY, int width, int heigth )
        {
            if (_x + stepX < 0) _x = width;
            if (_x + stepX > width) _x = 1;
            if (_y + stepY < 0) _y = heigth;
            if (_y + stepY > heigth) _y = 1;
            _x += stepX;
            _y += stepY;
        }

       
    }
   
}

