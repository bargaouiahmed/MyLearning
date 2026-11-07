namespace MyLearning.Domain.CopyBook.Page.PageItem;

public record struct Transform
{
    private Transform(float x, float y, float width, float height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public static Transform From(float x, float y, float width, float height)
    {
        if (width <= 0)
        {
            throw new ArgumentException("Width must be greater than zero", nameof(width));
        }
        if (height <= 0)
        {
            throw new ArgumentException("Height must be greater than zero", nameof(height));
        }
        if (x < 0)
        {
            throw new ArgumentException("X must be greater than or equal to zero", nameof(x));
        }
        if (y < 0)
        {
            throw new ArgumentException("Y must be greater than or equal to zero", nameof(y));
        }

        return new Transform(x, y, width, height);
    }

    //builder pattern
    public static TransformBuilder Builder()
    {
        return new TransformBuilder();
    }
    public record struct TransformBuilder
    {
        private float XAttr;
        private float YAttr;
        private float WidthAttr;
        private float HeightAttr;

        public TransformBuilder X(float x)
        {
            if (x < 0)
            {
                throw new ArgumentException("X must be greater than or equal to zero", nameof(x));
            }
            XAttr = x;

            return this;
        }
        public TransformBuilder Y(float y)
        {
            if (y < 0)
            {
                throw new ArgumentException("Y must be greater than or equal to zero", nameof(y));
            }
            YAttr = y;
            return this;
        }
        public TransformBuilder Width(float width)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Width must be greater than zero", nameof(width));
            }
            WidthAttr = width;
            return this;
        }
        public TransformBuilder Height(float height)
        {
            if (height <= 0)
            {
                throw new ArgumentException("Height must be greater than zero", nameof(height));
            }
            HeightAttr = height;
            return this;
        }


        public Transform Build()
        {
            return new Transform(XAttr, YAttr, WidthAttr, HeightAttr);
        }
    }

}