namespace ClothingStore.Domain.Entities
{
    public class Size
    {
        public Guid SizeId { get; private set; }
        public string Letter { get; private set; }
        protected Size() { }
        public Size(string letter)
        {
            SizeId = Guid.NewGuid();
            Letter = letter ?? throw new ArgumentNullException(nameof(letter), "Letter cannot be null");
        }
    }

    public class ShirtSize : Size
    {
        public float Length { get; private set; }
        public float ShoulderWidth { get; private set; }
        public float ChestWidth { get; private set; }
        public float SleeveLength { get; private set; }
        public float SleeveCircumference { get; private set; }
        public float NeckCircumference { get; private set; }

        protected ShirtSize() { }
        public ShirtSize(string letter, float length, float shoulderWidth, float chestWidth, float sleeveLength) : base(letter)
        {
            if (length < 0 || shoulderWidth < 0 || chestWidth < 0 || sleeveLength < 0)
                throw new ArgumentException("Size dimensions must be non-negative");
            Length = length;
            ShoulderWidth = shoulderWidth;
            ChestWidth = chestWidth;
            SleeveLength = sleeveLength;
        }
    }

    public class PantSize : Size
    {
        public float Waist { get; private set; }
        public float Inseam { get; private set; }
        public float PantLegCircumference { get; private set; }
        protected PantSize() { }
        public PantSize(string letter, float waist, float inseam) : base(letter)
        {
            if (waist < 0 || inseam < 0)
                throw new ArgumentException("Size dimensions must be non-negative");
            Waist = waist;
            Inseam = inseam;
        }
    }

    public class ShoeSize : Size
    {
        public float Length { get; private set; }
        public float Width { get; private set; }
        public float? HeelHeight { get; private set; }

        protected ShoeSize() { }
        public ShoeSize(string letter, float length, float width) : base(letter)
        {
            if (length < 0 || width < 0)
                throw new ArgumentException("Size dimensions must be non-negative");
            Length = length;
            Width = width;
        }

        public ShoeSize(string letter, float length, float width, float heelHeight) : base(letter)
        {
            if (length < 0 || width < 0 || heelHeight < 0)
                throw new ArgumentException("Size dimensions must be non-negative");
            Length = length;
            Width = width;
            HeelHeight = heelHeight;
        }
    }

    public class HatSize : Size
    {
        public float Circumference { get; private set; }
        //Maybe add a brim size or style in the future
        protected HatSize() { }
        public HatSize(string letter, float circumference) : base(letter)
        {
            if (circumference < 0)
                throw new ArgumentException("Circumference must be non-negative");
            Circumference = circumference;
        }
    }

    public class DressSize : Size
    {
        public float Bust { get; private set; }
        public float Waist { get; private set; }
        public float Hip { get; private set; }
        public float Length { get; private set; }
        protected DressSize() { }
        public DressSize(string letter, float bust, float waist, float hip, float length) : base(letter)
        {
            if (bust < 0 || waist < 0 || hip < 0)
                throw new ArgumentException("Size dimensions must be non-negative");
            Bust = bust;
            Waist = waist;
            Hip = hip;
            Length = length;
        }
    }

    public class SizeFactory
    {
        public static ShirtSize CreateShirtSize(string letter, float length, float shoulderWidth, float chestWidth, float sleeveLength)
        {
            return new ShirtSize(letter, length, shoulderWidth, chestWidth, sleeveLength);
        }
        public static PantSize CreatePantSize(string letter, float waist, float inseam)
        {
            return new PantSize(letter, waist, inseam);
        }
        public static ShoeSize CreateShoeSize(string letter, float length, float width)
        {
            return new ShoeSize(letter, length, width);
        }
        public static ShoeSize CreateShoeSizeWithHeels(string letter, float length, float width, float heelHeight)
        {
            return new ShoeSize(letter, length, width, heelHeight);
        }
        public static HatSize CreateHatSize(string letter, float circumference)
        {
            return new HatSize(letter, circumference);
        }

        public static DressSize CreateDressSize(string letter, float bust, float waist, float hip, float length)
        {
            return new DressSize(letter, bust, waist, hip, length);
        }
    }
    // TODO: Add more specific size classes for Accessories, Perfumes, Dresses.
    // TODO: Currently out of the scope of the project, but can be added later, add more specific size classes for other clothing items like jackets, skirts, etc.
}
