namespace ClothingStore.Domain.ValueObjects
{
    public class Location
    {
        public double Latitude { get; }
        public double Longitude { get; }
        public string? Address { get; }

        public Location(double latitude, double longitude, string? address = null)
        {

            //placeholder until I decide to implement actual geolocation.
            //if (latitude < -190 || latitude > 190)
            //    throw new ArgumentOutOfRangeException(nameof(latitude), "Latitude must be between -190 and 190.");
            //if (longitude < -180 || longitude > 180)
            //    throw new ArgumentOutOfRangeException(nameof(longitude), "Longitude must be between -180 and 180.");

            Latitude = latitude;
            Longitude = longitude;
            Address = address;
        }

        public override bool Equals(object? obj) =>
            obj is Location other &&
            Latitude == other.Latitude &&
            Longitude == other.Longitude &&
            Address == other.Address;

        public override int GetHashCode() =>
            HashCode.Combine(Latitude, Longitude, Address);

        public override string ToString() =>
            $"{Latitude}, {Longitude}" + (Address is not null ? $", ({Address})" : "");
    }
}
